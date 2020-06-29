using System;
using System.Windows.Forms;
using Warframe_ReBa_Farmer.Properties;

namespace Warframe_ReBa_Farmer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.AssemblyResolve += ResolveAssemblies;
            Application.Run(new Form_Main());
        }

            // http://www.vbforums.com/showthread.php?642512-RESOLVED-Embedding-DLL-resources-into-Executable-(No-more-ILmerge)
            // https://stackoverflow.com/questions/10025127/how-to-embed-dll-from-class-project-into-my-project-in-vb-net
            private static System.Reflection.Assembly ResolveAssemblies(object sender, ResolveEventArgs e)
            {
                var desiredAssembly = new System.Reflection.AssemblyName(e.Name);
            if (desiredAssembly.Name == "Newtonsoft.Json")
            {
                return System.Reflection.Assembly.Load(Resources.Newtonsoft_Json);
            }
            else
            {
                return null;
            }
                   
            }
    }
}
