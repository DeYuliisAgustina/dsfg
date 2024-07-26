using Entidades;
using Modelo;

namespace VISTA
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var context = new Context())
            {
                // Verificar si la universidad "UAI" ya existe
                var uai = context.Universidades.FirstOrDefault(u => u.NombreUniversidad == "UAI");

                if (uai == null)
                {
                    // Si no existe, crear una nueva universidad
                    uai = new Universidad { NombreUniversidad = "UAI" };

                    // Agregar la nueva universidad al DbContext
                    context.Universidades.Add(uai);

                    // Guardar los cambios en la base de datos
                    context.SaveChanges();
                }
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new Menu());
            }
        }
    }
}