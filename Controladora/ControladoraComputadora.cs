using Entidades;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraComputadora
    {
        Context context;

        private ControladoraComputadora()
        {
            context = new Context();
        }

        private static ControladoraComputadora instancia;

        public static ControladoraComputadora Instancia
        {

            get
            {
                if (instancia == null)
                    instancia = new ControladoraComputadora();
                return instancia;
            }
        }

        public ReadOnlyCollection<Computadora> RecuperarComputadoras()
        {
            try
            {
                Context.Instancia.Computadoras.Include(c => c.Laboratorio).ToList().AsReadOnly();
                return Context.Instancia.Computadoras.Include(c => c.Laboratorio).ToList().AsReadOnly();

            }
            catch (Exception ex)
            {
                throw ex;   
            }
        }

        public string AgregarComputadora(Computadora computadora)
        {
            try
            {
                var listaLaboratorios = Context.Instancia.Laboratorios.ToList().AsReadOnly();
                var laboratorioEncontrado = listaLaboratorios.FirstOrDefault(l => l.LaboratorioId == computadora.LaboratorioId); //busco el laboratorio por id para verificar que exista
                if (laboratorioEncontrado != null)
                {
                    if (laboratorioEncontrado.Computadoras.Count < laboratorioEncontrado.CapacidadMaxima)
                    {
                        var listaComputadoras = Context.Instancia.Computadoras.ToList().AsReadOnly();
                        var computadoraEncontrada = listaComputadoras.FirstOrDefault(c => c.CodigoComputadora.ToLower() == computadora.CodigoComputadora.ToLower() && c.LaboratorioId == computadora.LaboratorioId); //busco la computadora por codigo y laboratorio para verificar que no se repita
                        if (computadoraEncontrada == null)
                        {
                            Context.Instancia.Computadoras.Add(computadora);
                            int insertados = Context.Instancia.SaveChanges();
                            if (insertados > 0)
                            {
                                return $"La computadora se agregó correctamente";
                            }
                            else return $"La computadora no se ha podido agregar";
                        }
                        else
                        {
                            return $"La computadora ya existe";
                        }
                    }
                    else
                    {
                        return $"Capacidad superada, la capacidad maxima es de {laboratorioEncontrado.CapacidadMaxima} computadoras";
                    }
                }
                else
                {
                    return $"El laboratorio no existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido" + ex;
            }
        }

        //hacer el metodo de modificar computadora
        public string ModificarComputadora(Computadora computadora)
        {
            try
            {
                var listaComputadoras = Context.Instancia.Computadoras.ToList().AsReadOnly();
                var computadoraEncontrada = listaComputadoras.FirstOrDefault(c => c.CodigoComputadora.ToLower() == computadora.CodigoComputadora.ToLower() && c.LaboratorioId == computadora.LaboratorioId); //busco la computadora por codigo y laboratorio para verificar que exista
                if (computadoraEncontrada != null)
                {
                    Context.Instancia.Computadoras.Update(computadora);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"La computadora se modificó correctamente";
                    }
                    else return $"La computadora no se ha podido modificar";
                }
                else
                {
                    return $"La computadora no existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido" + ex;
            }
        }

        public string EliminarComputadora(Computadora computadora)
        {
            try
            {
                var listaComputadoras = Context.Instancia.Computadoras.ToList().AsReadOnly();
                var computadoraEncontrada = listaComputadoras.FirstOrDefault(c => c.CodigoComputadora.ToLower() == computadora.CodigoComputadora.ToLower() && c.LaboratorioId == computadora.LaboratorioId); //busco la computadora por codigo y laboratorio para verificar que exista
                if (computadoraEncontrada != null) //si la computadora existe, la elimino
                {
                    Context.Instancia.Computadoras.Remove(computadora);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"La computadora se eliminó correctamente";
                    }
                    else return $"La computadora no se ha podido eliminar";
                }
                else
                {
                    return $"La computadora no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public bool ComprobarComputadora(Computadora computadora)
        {
            var listaComputadoras = Context.Instancia.Computadoras.ToList().AsReadOnly();
            var computadoraEncontrada = listaComputadoras.FirstOrDefault(c => c.CodigoComputadora.ToLower() == computadora.CodigoComputadora.ToLower() && c.CodigoComputadora == computadora.Laboratorio.NombreLaboratorio); //busco la computadora por codigo y laboratorio para verificar que no se repita
            if (computadoraEncontrada == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
