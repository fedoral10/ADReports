using System;
using System.Text;
using System.Collections.Generic;


namespace ADReports.Dominio {
    
    public class EntidadAplicacion {
        public virtual long idEntidadAplicacion { get; set; }
        public virtual long idEntidad { get; set; }
        public virtual long idAplicacion { get; set; }
    }
}
