using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedirectConvert.Helpers;

namespace RedirectConvert
{
    internal class Program
    {
        static private void showUsage() { Console.Out.WriteLine("usage : redirectinputs <infile> <outfile>"); }
        static void Main(string[] args)
        {
            string filein = "";
            string fileout = "";

            switch (args.Length)
            {
                case 2:
                    filein = args[0];
                    fileout = args[1];
                    Exporter exp = new Exporter(filein,fileout);
                    exp.Export();
                    break;
                default :
                    showUsage();
                    break;

            }
              
        }
    }
}
