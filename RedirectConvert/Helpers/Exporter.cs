using System;
using System.IO;
using System.Collections.Generic;
using RedirectConvert.Interfaces;
using RedirectConvert.Models;
using System.Text;

namespace RedirectConvert.Helpers
{
    public class Exporter : IExporter
    {
        private static string _filein;
        private static string _fileout;
        public void Export() {            
            var Lines = File.ReadLines(_filein);
            List<RedirectInput> ris = new List<RedirectInput>();
            foreach (var line in Lines) {
                var fields = line.Split(' ');
                ris.Add(new RedirectInput(fields[0], Convert.ToInt32(fields[1]), fields[2], fields[3]));
            }
            Save(ris);
        }
        private bool Save(List<RedirectInput> ris) {
            StringBuilder sb = new StringBuilder();
            string line1 = @"RewriteCond %{QUERY_STRING} ^FROM_URL$";
            string line2 = "RewriteRule ^/*$ TO_URL? [NC,R=301,L]";
            foreach (RedirectInput ri in ris)
            {
                sb.AppendLine(line1.Replace("FROM_URL", ri.oldurl));
                sb.AppendLine(line2.Replace("TO_URL", ri.newurl));
                sb.AppendLine("#");
            }
            StreamWriter sw = new StreamWriter(_fileout);

            sw.WriteLine(sb.ToString());
            sw.Close();
            return true;
        }
        public Exporter(string filein, string fileout)
        {
            _filein = filein;
            _fileout = fileout;            
        }
    }
}
