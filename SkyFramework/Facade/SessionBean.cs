using System;
using SkyFramework.Entities;

/// <summary>
/// SessionBean, Variables de Session en este objeto
/// </summary>

[Serializable]
public class SessionBean
{
    #region Propiedades Privadas

    private Usuario _Usuario;

    private int _idEtapaCampania;

    private int _campaniaId;

    private int nroOrden;

    private int _idConfiguracionCapania;

    private int _idCampaniaTemp;

    private int _IdEtapaPlantilla;

    private string _nombreArchivo;

    private string _PathCompleto;

    private string _postulanteEtapaAdjArchivo;

    private int _sucesoId;

    private int _postulanteSeleccionadoId;

    private string _nombreCampania;
    #endregion

    #region Propiedades Publicas

    public Usuario Usuario
    {
        get { return _Usuario; }
        set { _Usuario = value; }
    }

    #endregion

    public SessionBean()
    {
    }   
  
}
