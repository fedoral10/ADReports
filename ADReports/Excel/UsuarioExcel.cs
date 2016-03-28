using SimpleExcelImport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADReports.Excel
{
    class UsuarioExcel
    {
        [ExcelImport("ID", order = 1)]
        public string ID { get; set; }

        [ExcelImport("Nombre", order = 2)]
        public string Nombre { get; set; }

        [ExcelImport("Puesto", order = 3)]
        public string Puesto { get; set; }

        [ExcelImport("Area", order = 4)]
        public string Area { get; set; }

        [ExcelImport("Correo", order = 5)]
        public string Correo { get; set; }

        [ExcelImport("Empresa", order = 6)]
        public string Empresa { get; set; }

        public Dominio.Entidad getEntidad()
        { 
            Dominio.Entidad e = new Dominio.Entidad();

            e.samaccountname = this.ID;
            e.cn = this.Nombre;
            e.displayname = this.Nombre;
            e.description = this.Puesto;
            e.department = this.Area;
            e.physicalDeliveryOfficeName = this.Area;
            e.mail = this.Correo;
            e.company = this.Empresa;

            return e;
        }

    }
}
