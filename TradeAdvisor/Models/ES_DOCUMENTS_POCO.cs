using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeAdvisor.Models
{
    public class ES_DOCUMENTS_POCO
    {
        //Match Fields
        public string tx_descricaoMercadoria { get; set; }  //DI
        public string txmercadoria { get; set; }            //CE
            
        //Aggregation Fields
        public string tx_cnpj { get; set; }                 //DI
        public string cdconsignatario { get; set; }         //CE

        //Date fields
        public Nullable<System.DateTime> dt_registro { get; set; } //DI
        public Nullable<System.DateTime> dtemissaoce { get; set; } //CE

    }
}