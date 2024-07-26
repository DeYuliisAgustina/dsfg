using Entidades;
using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraSede
    {
        Context context;

        private ControladoraSede()
        {
            context = new Context();
        }

        private static ControladoraSede instancia;

        public static ControladoraSede Instancia
        {

            get
            {
                if (instancia == null)
                    instancia = new ControladoraSede();
                return instancia;
            }
        }

        public ReadOnlyCollection<Sede> RecuperarSedes()
        {
            try
            {
                Context.Instancia.Sedes.ToList().AsReadOnly();
                return Context.Instancia.Sedes.ToList().AsReadOnly();
            }
            catch (Exception)
            {
                throw;
            }
        }        

        public Universidad RecuperarUniversidad()
        {
            try
            {
                Context.Instancia.Universidades.FirstOrDefault(u => u.NombreUniversidad == "UAI");
                return Context.Instancia.Universidades.FirstOrDefault(u => u.NombreUniversidad == "UAI");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AgregarSede(Sede sede)
        {
            try
            {
                var listaSedes = Context.Instancia.Sedes.ToList().AsReadOnly();
                var sedeEncontrada = listaSedes.FirstOrDefault(s => s.NombreSede.ToLower() == sede.NombreSede.ToLower());
                if (sedeEncontrada == null)
                {
                    Context.Instancia.Sedes.Add(sede);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"La sede se agregó correctamente";
                    }
                    else return $"La sede no se ha podido agregar";
                }
                else
                {
                    return $"La sede ya existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
       
        public string ModificarSede(Sede sede)
        {
            try
            {
                var listaSedes = Context.Instancia.Sedes.ToList().AsReadOnly();
                var sedeEncontrada = listaSedes.FirstOrDefault(s => s.SedeId == sede.SedeId || s.NombreSede.ToLower() == sede.NombreSede.ToLower());
                if (sedeEncontrada != null)
                {
                    Context.Instancia.Sedes.Update(sede);
                    sedeEncontrada.NombreSede = sede.NombreSede;
                    sedeEncontrada.DireccionSede = sede.DireccionSede;

                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"La sede se modificó correctamente";
                    }
                    else return $"La sede no se ha podido modificar";
                }
                else
                {
                    return $"La sede no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }

        }

        public string EliminarSede(Sede sede)
        {
            try
            {
                var listaSedes = Context.Instancia.Sedes.ToList().AsReadOnly();
                var sedeEncontrada = listaSedes.FirstOrDefault(s => s.NombreSede.ToLower() == sede.NombreSede.ToLower());
                if (sedeEncontrada != null) //si la sede existe, la elimino
                {
                    Context.Instancia.Sedes.Remove(sede);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"La sede se eliminó correctamente";
                    }
                    else return $"La sede no se ha podido eliminar";
                }
                else
                {
                    return $"La sede no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
    }
}
