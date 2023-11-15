using System.Xml.Linq;

namespace Weather_app
{
    internal static class Program
    {
    
        [STAThread]
        static void Main()
        {
            
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            


        }



    }
}