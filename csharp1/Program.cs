using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace csharp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // open app
            SldWorks app;
            app = (SldWorks)Activator.CreateInstance(Type.GetTypeFromProgID("SldWorks.Application"));
            string filename = "C:\\Users\\Public\\Documents\\SOLIDWORKS\\SOLIDWORKS 2020\\samples\\tutorial\\api\\arm2.sldasm";

            Console.WriteLine("Filename:");
            Console.WriteLine(filename);

            MatesHandler handler = new MatesHandler((SldWorks)app, (string)filename);
            handler.Run();

            app.ExitApp();
            app = null;
        }
    }
}
