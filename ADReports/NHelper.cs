using ADReports.Dominio;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADReports
{
    class NHelper
    {

        private static string connection_string;

        public static void setConnectionString(string user, string pass, string host, string port)
        {
            string texto = "Server={0};Port={1};database={2};user id={3};password={4}";
            connection_string = String.Format(texto, host, port, "AD", user, pass);
        }

        private static void ExportarEsquema(Configuration cfg)
        {

            var lol = new SchemaUpdate(cfg);
            lol.Execute(false, true);
            //lol.Execute(true, false);

        }

        
        public static ISession GetCurrentSession()
        {
            if (SessionFactory == null)
                NHelper.OpenSession();


            return SessionFactory.OpenSession();
        }


        public static void CloseSessionFactory()
        {
            if (SessionFactory != null)
                SessionFactory.Close();
        }



        private static ISessionFactory _sessionFactory;
        //private static ISession _sesion;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    //configuration.Configure();
                    Dictionary<string, string> propiedades = new Dictionary<string, string>();

                    propiedades.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
                    propiedades.Add("connection.driver_class", "NHibernate.Driver.NpgsqlDriver");
                    propiedades.Add("connection.connection_string", connection_string);
                    propiedades.Add("dialect", "NHibernate.Dialect.PostgreSQLDialect");
                    //propiedades.Add("adonet.batch_size", "0");
                    //propiedades.Add("show_sql", "true");

                    configuration.AddProperties(propiedades);
                    //configuration.AddAssembly(typeof(EntidadAplicacion).Assembly);
                    configuration.AddAssembly(typeof(Entidad).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                    ExportarEsquema(configuration);
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }

}