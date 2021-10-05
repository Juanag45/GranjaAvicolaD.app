using System.Collections.Generic;
using System.Linq;
using GranjaAvicolaD.app.Dominio;

namespace GranjaAvicolaD.app.Persistencia
{
    public class RepositorioInicioSesion:IRepositorioInicioSesion 
    {
        /// <summary>
        /// Referencia al contexto de Paciente
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//

        public RepositorioInicioSesion(AppContext appContext)
        {
            _appContext = appContext;
        }

        DatosInicioSesion IRepositorioInicioSesion.AddDatosInicioSesion(DatosInicioSesion datosInicioSesion)
        {
            var datosInicioSesionAdicionado=_appContext.DatosInicioSesion.Add(datosInicioSesion);
            _appContext.SaveChanges();
            return datosInicioSesionAdicionado.Entity;
        }

        void IRepositorioInicioSesion.DeleteDatosInicioSesion(int idDatosInicioSesion)
        {
            var datosInicioSesionEncontrado=_appContext.DatosInicioSesion.FirstOrDefault(d=>d.Id==idDatosInicioSesion);
            if (datosInicioSesionEncontrado==null)
                return;
            _appContext.DatosInicioSesion.Remove(datosInicioSesionEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<DatosInicioSesion> IRepositorioInicioSesion.GetAllDatosInicioSesion()
        {
            return _appContext.DatosInicioSesion;

        }

        DatosInicioSesion IRepositorioInicioSesion.GetDatosInicioSesion(int  idDatosInicioSesion)
        {
            return _appContext.DatosInicioSesion.FirstOrDefault(d=>d.Id==idDatosInicioSesion);
            
        }

        DatosInicioSesion IRepositorioInicioSesion.UpdateDatosInicioSesion(DatosInicioSesion datosInicioSesion)
        {
            var datosInicioSesionEncontrado=_appContext.DatosInicioSesion.FirstOrDefault(d=> d.Id==datosInicioSesion.Id);
            if (datosInicioSesionEncontrado!=null)
            {
                datosInicioSesionEncontrado.UserName=datosInicioSesion.UserName;
                datosInicioSesionEncontrado.Pasword=datosInicioSesion.Pasword;

                _appContext.SaveChanges();
            }
            return datosInicioSesionEncontrado;
        }
    }
}