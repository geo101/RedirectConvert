using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedirectConvert.Models
{
    public class RedirectInput
    {
        public string directive { get; set; }
        public int code { get; set; }
        public string oldurl { get; set; }
        public string newurl { get; set; }
        public RedirectInput(string pDir, int pCode, string pOldUrl, string pNewUrl) {
            directive = pDir;
            code = pCode;
            oldurl = pOldUrl;
            newurl = pNewUrl;
        }
    }
    
}
