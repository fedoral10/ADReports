using System;
using System.Text;
using System.Collections.Generic;


namespace ADReports.Dominio {
    
    public class Aplicacion {
        

        public virtual long idAplicacion { get; set; }
        public virtual string nombre { get; set; }
        public virtual ISet<EntidadAplicacion> EntidadAplicaciones { get; set; }
        public virtual string pais { get; set; }

        public override string ToString()
        {
            return this.nombre+"-"+this.pais;
        }
    }

    public class PAIS
    {
        public static string NICARAGUA = "NI";
        public static string PANAMA = "PA";
        public static string EL_SALVADOR = "SV";
        public static string GUATEMALA = "GT";
        public static string COSTA_RICA = "CR";
        public static string MEXICO = "MX";

        public static string[] paises = {NICARAGUA,PANAMA,EL_SALVADOR,GUATEMALA,COSTA_RICA,MEXICO };
    }
}
