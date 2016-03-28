using System;
using System.Text;
using System.Collections.Generic;


namespace ADReports.Dominio {
    
    public class Entidad {
        public virtual long idEntidad { get; set; }
        public virtual string department { get; set; }
        public virtual string surname { get; set; }
        public virtual string whencreated { get; set; }
        public virtual string cn { get; set; }
        public virtual string givenname { get; set; }
        public virtual string mail { get; set; }
        public virtual string displayname { get; set; }
        public virtual string objectclass { get; set; }
        public virtual string samaccountname { get; set; }
        public virtual string telephonenumber { get; set; }
        public virtual string whenchanged { get; set; }
        public virtual string description { get; set; }
        public virtual string title { get; set; }
        public virtual string topou { get; set; }
        public virtual string distinguishedname { get; set; }
        public virtual string company { get; set; }
        public virtual string physicalDeliveryOfficeName { get; set; }
        public virtual DateTime lastLogonDT { get; set; }
        public virtual DateTime whenCreatedDT { get; set; }
        public virtual DateTime whenChangedDT { get; set; }
        public virtual DateTime pwdLastSetDT { get; set; }
        public virtual ISet<EntidadAplicacion> EntidadAplicaciones { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Entidad objAsPart = obj as Entidad;

            if (objAsPart.samaccountname == this.samaccountname)
                return true;
            else
                return false;

        }
        public override int GetHashCode()
        {
            int hash = 1;
            hash = hash + this.samaccountname.GetHashCode();
            
            return hash;
        }
        
    }
}
