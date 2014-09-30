using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Threading;
using System.Configuration;
using SkyFramework.Facade;

namespace SkyFramework.Facade
{
    public class Dispatcher
    {
        #region Private Area
        private string configFileName = "Facade_Config.xml";
        private string binPath = "";
        private Hashtable CommandList;
        private int SystemId = 0;
        private decimal UserId = 0;
        private string connString = "";
        private SkyFramework.Connection.SkyConnection _skyConn = null;

        private static Dispatcher uniqueInstance;

        /// <summary>
        /// Constructor interno, No accesible desde afuera
        /// </summary>
        private Dispatcher()
        {
            configure();
        }

        ///<summary>
        ///<para>PRE: Xml en formato correcto</para>POS:Leera cada configuracion del xml, y lo agregregara a la lista de acciones / servicios a ejecutar
        ///<para>HELP: </para>Exeptions: XmlNotInCorrectFormat
        ///</summary> 	
        /// <param name="xmlDocument">Documento de configuracion abierto</param>
        //Ref: Nhibernate , NHibernate.Cfg.AssemblyHbmOrderer,  public IList GetHbmFiles()
        private void ReadXml(XmlDocument xmlDocument)
        {
            //por defecto 100,  van a haber mas pero mejora la performance una inicializacion aproximada 
            CommandList = new Hashtable(100);


            try
            {
                Command oCommand;
                string assembly;
                string _namespace;

                XmlNodeList myXmlActionsList = xmlDocument.SelectNodes("/facade-Config/Actions");
                foreach (XmlNode actionsNode in myXmlActionsList)
                {
                    assembly = actionsNode.Attributes["assembly"].Value;
                    _namespace = actionsNode.Attributes["namespace"].Value;

                    foreach (XmlNode actioNode in actionsNode.ChildNodes)
                    {
                        if (actioNode.NodeType != XmlNodeType.Element)
                        {
                            continue;
                        }

                        oCommand = new Command();

                        oCommand.Assembly = assembly;
                        oCommand.Namespace = _namespace;

                        oCommand.ActionName = actioNode.Attributes["name"].Value;
                        oCommand.RequireSecurity = actioNode.Attributes["requireSecurity"].Value.ToLower().Equals("true");
                        oCommand.makeLog = actioNode.Attributes["logger"].Value.ToLower().Equals("true");

                        oCommand.CloseTransaction = actioNode.Attributes["closeTransaction"].Value.ToLower().Equals("true");
                        oCommand.OpenedConnection = actioNode.Attributes["openedConnection"].Value.ToLower().Equals("true");

                        foreach (XmlNode subNode in actioNode.ChildNodes)
                        {
                            if (subNode.NodeType != XmlNodeType.Element)
                            {
                                continue;
                            }

                            //No pueden no tener los atributos de service
                            if (subNode.Name == "Service")
                            {
                                oCommand.ServiceClass = subNode.Attributes["class"].Value;
                                oCommand.ServiceMethod = subNode.Attributes["method"].Value;
                            }

                            //pueden no tener los atributos logs
                            if (subNode.Name == "Logs")
                            {
                                if (subNode.Attributes["ErrorLogText"] != null)
                                {
                                    oCommand.ErrorLog = subNode.Attributes["ErrorLogText"].Value;
                                }
                                if (subNode.Attributes["SuccefullLogText"] != null)
                                {
                                    oCommand.SuccefullLog = subNode.Attributes["SuccefullLogText"].Value;
                                }
                                if (subNode.Attributes["NotPermisionLogText"] != null)
                                {
                                    oCommand.NotPermisionLog = subNode.Attributes["NotPermisionLogText"].Value;
                                }

                            }
                        }

                        CommandList.Add(oCommand.ActionName, oCommand);

                    }//fin p/c  action
                }//fin p/c actions

            }

            catch (Exception ex)
            {
                throw new SkyFramework.Exceptions.XmlNotInCorrectFormat("Error parseando la configuracion de facade.", ex);
            }

        }

        ///<summary>
        ///<para>PRE: cmd no null           </para>POS:ejecuta el servicio pedido
        ///<para>HELP:                      </para>Exeptions: ServiceNotFound, Y excepciones por problemas de la carga de Assembly
        ///</summary> 	 
        private SkyFramework.Entities.Mensaje InvoqueProcesses(Command cmd, object[] argumentos)
        {
            try
            {
                List<object> _argumentos = argumentos.ToList();

                //Assembly assembly = getAssembly(cmd);
                //Type myType = assembly.GetType(cmd.Namespace + "." + cmd.ServiceClass);
                Type myType = Type.GetType(cmd.Namespace + "." + cmd.ServiceClass);
                if (myType == null)
                {
                    throw new SkyFramework.Exceptions.ServiceNotFound(
                       " No se encuentra la clase del servicio: " + cmd.Namespace + "." + cmd.ServiceClass + "." + cmd.ServiceMethod +
                       " Llamada desde el servicio : " + cmd.ActionName
                       );
                }
                MethodInfo mymethod = myType.GetMethod(cmd.ServiceMethod);

                if (mymethod == null)
                {
                    throw new SkyFramework.Exceptions.ServiceNotFound(
                        " No se encuentra el servicio: " + cmd.Namespace + "." + cmd.ServiceClass + "." + cmd.ServiceMethod +
                        " Llamada desde el servicio : " + cmd.ActionName
                        );
                }

                //OpenedConnection indica si le tengo que pasar una conexión abierta
                if (cmd.OpenedConnection)
                {
                    _argumentos.Add(this._skyConn = new SkyFramework.Connection.SkyConnection("Data Source=localhost;Initial Catalog=binDGSLD;Integrated Security=True", true));
                }


                List<ParameterInfo> parameters = mymethod.GetParameters().ToList<ParameterInfo>();
                if (_argumentos.Count != parameters.Count)
                {
                    throw new Exceptions.TargetParameterCountException("El conteo de parámetros de la llamada, no coincide con el del método: " + Exceptions.TargetParameterCountException.GetParameters(parameters), parameters);
                }

                return (SkyFramework.Entities.Mensaje)mymethod.Invoke(null, _argumentos.ToArray());
            }
            catch (Exceptions.TargetParameterCountException tpcEx) 
            {
                throw tpcEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this._skyConn != null)
                {
                    this._skyConn.CloseConnection();
                }
            }

        }

        ///<summary>
        ///<para>PRE: </para>POS:
        ///<para>HELP: </para>Exeptions: ThreadAbortException , StackOverflowException , OutOfMemoryException
        ///</summary> 	 
        /// <param name="cmd"></param>
        /// <returns>Assembly </returns>
        private static Assembly getAssembly(Command cmd)
        {
            Assembly assembly = null;
            string assemblyName = cmd.Assembly;
            string path = Path.GetFullPath(assemblyName).ToLower();

            if (File.Exists(path))
            {
                assembly = Assembly.LoadFrom(path);
            }
            else
            {
                try
                {
                    assembly = Assembly.Load(assemblyName);
                }
                catch (Exception e)
                {
                    if (e is ThreadAbortException || e is StackOverflowException || e is OutOfMemoryException)
                    {
                        throw e;
                    }
                }
                if (assembly == null)
                {
                    string justName = Path.GetFileNameWithoutExtension(assemblyName);
                    try
                    {
                        assembly = Assembly.Load(justName);
                    }
                    catch (Exception e)
                    {
                        if (e is ThreadAbortException || e is StackOverflowException || e is OutOfMemoryException)
                        {
                            throw e;
                        }
                    }
                }
            }
            return assembly;
        }

        ///<summary>
        ///<para>PRE: Archivo de xml de configuracion "Facade_Config.xml" en el bin de la aplicacion, y correcto formato</para>POS:Cargara la lista de acciones posibles a ejecutar
        ///<para>Si no se quiere reiniciar la aplicacion y se agregan servicios, este metodo actualizara la configuracion del dispatcher </para>Exeptions: XmlNotInCorrectFormat
        ///</summary> 	 
        private void configure()
        {
            //Cargo el path y Archivo de configuracion
            // configFile  = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Replace(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".DLL", "") + configFileName;
            binPath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Replace(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".DLL", "").Replace("bin/","Config/");
            
            XmlTextReader reader = null;

            try
            {
                XmlDocument myXmlDocument = new XmlDocument();
                myXmlDocument.Load(binPath + configFileName);
                ReadXml(myXmlDocument);
            }

            catch (Exception e)
            {
                throw new SkyFramework.Exceptions.XmlConfiguration("Error configurando el Dispatcher. ", e);
            }
            finally
            {
                // Finished with XmlTextReader
                if (reader != null)
                    reader.Close();
            }

        }

        private bool verifyPermissions(String permiso)
        {
            object[] p = { UserId, permiso };
            return (bool)(SendService("verifyPermissions", p).Obj);
        }


        #endregion

        //----------------------------------------------------------------------------------------------

        /// <summary>
        /// manejo con singleton, para leer configuracion unicamente una vez
        /// </summary>
        /// <returns>Instancia Dispacher</returns>
        public static Dispatcher GetInstance(decimal userId)
        {

            if (uniqueInstance == null)
            {
                uniqueInstance = new Dispatcher();
            }

            uniqueInstance.UserId = userId;
            return uniqueInstance;
        }

        ///<summary>
        ///<para>PRE: comando/servicio configurado en xml</para>POS:ejecuta el servicio pedido.
        ///<para>HELP: SendService(clientSave, id=1 );</para>Exeptions: ServiceNotFound, ThreadAbortException ,StackOverflowException, OutOfMemoryException
        ///</summary> 
        /// <param name="metodo">String nombre del metodo</param>
        /// <param name="argumentos">Parametros que necesite el servicio</param>
        /// <returns>Object , Cualquier cosa que devuelva el servicio</returns>
        public SkyFramework.Entities.Mensaje SendService(string metodo, object[] argumentos)
        {
            SkyFramework.Entities.Mensaje result = null;

            SkyFramework.LogManager.LogHelper logger = new SkyFramework.LogManager.LogHelper(SystemId);
            // logger.SetLog(0, "Enviando servicio para el metodo : " + metodo, SkyFramework.LogManager.LogHelper.eErrorLevel.Debug, null);

            try
            {
                //Trae el comando a ejecutar (Encapsula clase y metodo)
                Command cmd = (Command)CommandList[metodo];
                //Si no lo encontro (No esta configurado en el xml)
                if (cmd == null)
                {
                    throw new SkyFramework.Exceptions.ServiceNotFound(" No se encuentra el servicio pedido \"" + metodo + "\" , revise la configuracion por favor ");
                }


                //Verificacion de permiso 
                if (cmd.RequireSecurity)
                {
                    //    logger.SetLog(0, "Servicio para el metodo : " + metodo +" con seguridad ", SkyFramework.LogManager.LogHelper.eErrorLevel.Debug, null);

                    //VERIFICAR SEGURIDAD ANTES DE EJECUTAR
                    bool tienePermiso = true;// verificarPermiso(cmd.ActionName);

                    if (!tienePermiso)
                    {
                        throw new SkyFramework.Exceptions.SecurityExceptions("El usuario no tiene permiso");
                        string log = cmd.NotPermisionLog;

                        if (String.IsNullOrEmpty(log))
                        {
                            log = metodo + " requiere permiso de ejecucion y el usuario que intenta ejecutarlo no lo tiene ";
                        }
                        else
                        {
                            //   log.Replace("__IDENTIFICATION__", "" );
                        }

                        logger.SetLog(0, log, SkyFramework.LogManager.LogHelper.eErrorLevel.Warn, null);

                    }
                }

                result = InvoqueProcesses(cmd, argumentos);

                if (cmd.makeLog)
                {
                    String parametros = "";

                    if (argumentos != null)
                    {
                        foreach (object o in argumentos)
                        {
                            parametros += o.ToString() + ", ";
                        }
                    }

                    logger.SetLog(this.UserId, "Se ejecuto la acción :" + metodo + " con los sig. parámetros : " + parametros, SkyFramework.LogManager.LogHelper.eErrorLevel.Info, null);
                }
            }
            catch (Exception ex)
            {
                logger.SetLog(0, "Excepcion " + ex.Message + " Despachando el servicio", SkyFramework.LogManager.LogHelper.eErrorLevel.Fatal, null);
                throw ex;
            }

            return result;
        }
    }
}
