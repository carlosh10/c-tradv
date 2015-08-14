using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeAdvisor.Models
{
    public static class StaticNCM
    {
        public static List<sNCM> ncms = new List<sNCM>();
        
        public static string getNCMDesc(string ncm)
        {
            foreach (sNCM tNCM in ncms)
                if (tNCM.ncm.Equals(ncm))
                    return tNCM.ncm_desc;
            return "";
        }
    }

    public class sNCM
    {
        public string ncm;
        public string ncm_desc;

        public sNCM(string tncm, string tncm_desc)
        {
            this.ncm = tncm;
            this.ncm_desc = tncm_desc;
        }

    }
}