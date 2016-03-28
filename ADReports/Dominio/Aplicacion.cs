using System;
using System.Text;
using System.Collections.Generic;


namespace ADReports.Dominio {
    
    public class Aplicacion {


        public virtual long idAplicacion { get; set; }
        public virtual string nombre { get; set; }
        public virtual ISet<EntidadAplicacion> EntidadAplicaciones { get; set; }
        public override string ToString()
        {
            return this.nombre;
        }
    }
}
