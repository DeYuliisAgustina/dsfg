using Entidades;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System.Collections.ObjectModel;


namespace Controladora
{
    public class ControladoraLaboratorio
    {
        Context context;

        private ControladoraLaboratorio()
        {
            context = new Context();
        }

        private static ControladoraLaboratorio instancia;
        public static ControladoraLaboratorio Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraLaboratorio();
                return instancia;
            }
        }

        public ReadOnlyCollection<Laboratorio> RecuperarLaboratorios()
        {
            try
            {
                Context.Instancia.Laboratorios.ToList().AsReadOnly();
                return Context.Instancia.Laboratorios.ToList().AsReadOnly();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReadOnlyCollection<Laboratorio> RecuperarLaboratoriosPorSede(string nombreSede)
        {
            try
            {
                Context.Instancia.Laboratorios.ToList().AsReadOnly();
                return Context.Instancia.Laboratorios.Where(l => l.Sede.NombreSede == nombreSede).ToList().AsReadOnly();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AgregarLaboratorio(Laboratorio laboratorio)
        {
            try
            {
                //se verifica que no exista un laboratorio con el mismo nombre en la misma sede
                var listaLaboratorios = Context.Instancia.Laboratorios.ToList().AsReadOnly();
                var laboratorioEncontrado = listaLaboratorios.FirstOrDefault(l => l.NombreLaboratorio.ToLower() == laboratorio.NombreLaboratorio.ToLower() && l.Sede.NombreSede == laboratorio.Sede.NombreSede); //busco el laboratorio por nombre y sede para verificar que no exista un laboratorio con el mismo nombre en la misma sede
                if (laboratorioEncontrado == null)
                {
                    Context.Instancia.Laboratorios.Add(laboratorio);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El laboratorio se agregó correctamente";
                    }
                    else return $"El laboratorio no se ha podido agregar";
                }
                else return $"El laboratorio ya existe";
               
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el laboratorio", ex);
            }
        }

        public string ModificarLaboratorio(Laboratorio laboratorio)
        {
            try
            {
                var listaLaboratorios = Context.Instancia.Laboratorios.ToList().AsReadOnly();
                var laboratorioEncontrado = listaLaboratorios.FirstOrDefault(l => l.NombreLaboratorio.ToLower() == laboratorio.NombreLaboratorio.ToLower() && l.Sede.NombreSede == laboratorio.Sede.NombreSede); //busco el laboratorio por nombre y sede para verificar que no exista un laboratorio con el mismo nombre en la misma sede
                if (laboratorioEncontrado != null)
                {
                    Context.Instancia.Laboratorios.Update(laboratorio);
                    int modificados = Context.Instancia.SaveChanges();
                    if (modificados > 0)
                    {
                        return $"El laboratorio se modificó correctamente";
                    }
                    else return $"El laboratorio no se ha podido modificar";
                }
                else return $"El laboratorio no existe";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el laboratorio", ex);
            }
        }


        public string EliminarLaboratorio(Laboratorio laboratorio)
        {
            try
            {
                var listaLaboratorios = Context.Instancia.Laboratorios.ToList().AsReadOnly();
                var laboratorioEncontrado = listaLaboratorios.FirstOrDefault(l => l.LaboratorioId == laboratorio.LaboratorioId && l.NombreLaboratorio.ToLower() == laboratorio.NombreLaboratorio.ToLower());
                if (laboratorioEncontrado != null)
                {
                    Context.Instancia.Laboratorios.Remove(laboratorioEncontrado);
                    int eliminados = Context.Instancia.SaveChanges();
                    if (eliminados > 0)
                    {
                        return $"El laboratorio se eliminó correctamente";
                    }
                    else return $"El laboratorio no se ha podido eliminar";
                }
                else return $"El laboratorio no existe";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el laboratorio", ex);
            }
        }
    }
}
