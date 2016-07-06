using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADReports
{
    class clsRepo
    {
        #region Genericos
        public void Insertar<TClase>(TClase Objeto)
        {
            try
            {
                using (ISession session = NHelper.GetCurrentSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(Objeto);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void Eliminar<TClase>(TClase Objeto)
        {
            try
            {
                using (ISession session = NHelper.GetCurrentSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(Objeto);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void Actualizar<TClase>(TClase Objeto)
        {
            try
            {
                using (ISession session = NHelper.GetCurrentSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(Objeto);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public IList<TClase> Seleccionar<TClase>() where TClase : class
        {
            using (ISession session = NHelper.GetCurrentSession())
            {
                return session.CreateCriteria<TClase>().List<TClase>();
            }
        }
        public DataTable Seleccionar(string sql)
        {
            DataTable dt;
            using (ISession session = NHelper.GetCurrentSession())
            {

               using (IDbConnection sql_con =  session.Connection) 
               {
                   dt = new DataTable();
                   IDbCommand cmd = sql_con.CreateCommand();
                   
                   cmd.CommandText = sql;

                   var reader = cmd.ExecuteReader();

                   dt = GetDataTableFromDataReader(reader);                  
               }
            }
            return dt;
        }
        public DataTable GetDataTableFromDataReader(IDataReader dataReader)
        {
            DataTable schemaTable = dataReader.GetSchemaTable();
            DataTable resultTable = new DataTable();

            foreach (DataRow dataRow in schemaTable.Rows)
            {
                DataColumn dataColumn = new DataColumn();
                dataColumn.ColumnName = dataRow["ColumnName"].ToString().ToUpper();
                dataColumn.DataType = Type.GetType(dataRow["DataType"].ToString());
                //dataColumn.ReadOnly = (bool)dataRow["IsReadOnly"];
                //dataColumn.AutoIncrement = (bool)dataRow["IsAutoIncrement"];
                //dataColumn.Unique = (bool)dataRow["IsUnique"];

                resultTable.Columns.Add(dataColumn);
            }

            while (dataReader.Read())
            {
                DataRow dataRow = resultTable.NewRow();
                for (int i = 0; i < resultTable.Columns.Count; i++)
                {
                    dataRow[i] = dataReader[i];
                }
                resultTable.Rows.Add(dataRow);
            }

            return resultTable;
        } 
        public int Actualizacion(string sql)
        {
 
            int i = 0;
            using (ISession session = NHelper.GetCurrentSession())
            {

                using (IDbConnection sql_con = session.Connection)
                {
                   
                    IDbCommand cmd = sql_con.CreateCommand();

                    cmd.CommandText = sql;

                    i=cmd.ExecuteNonQuery();
                }
            }
            return i;
        }
        public int ContadorRows<TClase>() where TClase : class 
        {
            int rows = 0;
            using (ISession session = NHelper.GetCurrentSession())
            {

                rows= session.QueryOver<TClase>()
                       .Select(Projections.RowCount())
                       .FutureValue<int>()
                       .Value;

                
            }

            return rows;
        }
        #endregion
        #region ENTIDAD

        public int getCountEntidad(string samaccountname)
        {
            using (ISession session = NHelper.GetCurrentSession())
            {
                IList<Dominio.Entidad> lista = session.QueryOver<Dominio.Entidad>()
                    .Where(x => x.samaccountname == samaccountname).List<Dominio.Entidad>();

                /*Dominio.Entidad ex = session.CreateCriteria<Dominio.Entidad>().
                    Add(Restrictions.Eq("samaccountname", samaccountname))
                    .UniqueResult<Dominio.Entidad>();*/
                 return lista.Count;
            }
        }

        public int getIdEntidad(string samaccountname)
        {
            using (ISession session = NHelper.GetCurrentSession())
            {
                IList<Dominio.Entidad> lista = session.QueryOver<Dominio.Entidad>()
                    .Where(x => x.samaccountname == samaccountname).List<Dominio.Entidad>();

                /*Dominio.Entidad ex = session.CreateCriteria<Dominio.Entidad>().
                    Add(Restrictions.Eq("samaccountname", samaccountname))
                    .UniqueResult<Dominio.Entidad>();*/
                return (int)lista[0].idEntidad;
            }
        }

        public Dominio.Entidad getEntidadfromIDAD(String samaccountname)
        {
            using (ISession session = NHelper.GetCurrentSession())
            {
                IList<Dominio.Entidad> lista = session.QueryOver<Dominio.Entidad>()
                    .Where(x => x.samaccountname == samaccountname).List<Dominio.Entidad>();

                /*Dominio.Entidad ex = session.CreateCriteria<Dominio.Entidad>().
                    Add(Restrictions.Eq("samaccountname", samaccountname))
                    .UniqueResult<Dominio.Entidad>();*/
                if (lista.Count > 0)
                {
                    return lista[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public Dominio.EntidadAplicacion getEntidadAppValue(string samaccountname, long idApp)
        {
            using (ISession session = NHelper.GetCurrentSession())
            {
                Dominio.Entidad entidad = getEntidadfromIDAD(samaccountname);
                
                Dominio.EntidadAplicacion entapp = session.CreateCriteria<Dominio.EntidadAplicacion>()
                        .Add(Restrictions.Eq("idEntidad", entidad.idEntidad))
                        .Add(Restrictions.Eq("idAplicacion",idApp))
                        .UniqueResult<Dominio.EntidadAplicacion>();

                return entapp;   
            }
        }

        public IList<Dominio.EntidadAplicacion> getEntidadAppValues(string samaccountname)
        {
            using (ISession session = NHelper.GetCurrentSession())
            {
                Dominio.Entidad entidad = getEntidadfromIDAD(samaccountname);

                IList<Dominio.EntidadAplicacion> entapp = session.CreateCriteria<Dominio.EntidadAplicacion>()
                        .Add(Restrictions.Eq("idEntidad", entidad.idEntidad))
                        .List<Dominio.EntidadAplicacion>();

                return entapp;
            }
        }

        public Dominio.Aplicacion getApplicacion(string appname)
        {
            using (ISession session = NHelper.GetCurrentSession())
            {
                Dominio.Aplicacion app = session.CreateCriteria<Dominio.Aplicacion>()
                    .Add(Restrictions.Eq("nombre", appname))
                    .UniqueResult<Dominio.Aplicacion>();
                return app;
            }
        }
        
        public Dominio.Aplicacion getApplicacion(long appid)
        {
            using (ISession session = NHelper.GetCurrentSession())
            {
                Dominio.Aplicacion app = session.CreateCriteria<Dominio.Aplicacion>()
                    .Add(Restrictions.Eq("idAplicacion", appid))
                    .UniqueResult<Dominio.Aplicacion>();
                return app;
            }
        }

        public Dominio.Aplicacion getApplicacion1(long appid)
        {
            using (ISession session = NHelper.GetCurrentSession())
            {
                Dominio.Aplicacion app = session.CreateCriteria<Dominio.Aplicacion>()
                    .Add(Restrictions.Eq("idAplicacion", appid))
                    .UniqueResult<Dominio.Aplicacion>();
                return app;
            }
        }

        public int deleteEntidad_id(string id_ent)
        {
            using (ISession session = NHelper.GetCurrentSession())
            {
                using(ITransaction trans = session.BeginTransaction())
                {
                    IQuery q = session.CreateQuery("delete Entidad where idEntidad = :idEnt");
                    q.SetParameter("idEnt", id_ent);
                    return q.ExecuteUpdate();
                }
            }
        }

        public int executeNonQuery(string sql)
        {
            int result=0;
            using (ISession session = NHelper.GetCurrentSession())
            {
                using (ITransaction trans = session.BeginTransaction())
                {
                    IQuery q = session.CreateSQLQuery(sql);
                    result = q.ExecuteUpdate();
                    trans.Commit();
                }
            }
            return result;
        }

        public int deleteEntidad_samaccountname(string samaccountname)
        {
            using (ISession session = NHelper.GetCurrentSession())
            {
                using (ITransaction trans = session.BeginTransaction())
                {
                    IQuery q = session.CreateQuery("delete Entidad where samaccountname = :samaccountname");
                    q.SetParameter("samaccountname", samaccountname);
                    int i = q.ExecuteUpdate();
                    try
                    {                        
                        trans.Commit();
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        trans.Rollback();
                        
                    }

                    return i;
                }
            }
        }
        #endregion

        #region APLICACION
        public IList<Dominio.Aplicacion> getAplicacionesXPais(string pais)
        {
            using (ISession session = NHelper.GetCurrentSession())
            {
                IList<Dominio.Aplicacion> lista = session.QueryOver<Dominio.Aplicacion>()
                    .Where(x => x.pais == pais).List<Dominio.Aplicacion>();
                return lista;
            }
        }
        public int getCountAppPais(string pais)
        {
            int rows = 0;
            using (ISession session = NHelper.GetCurrentSession())
            {

                rows = session.QueryOver<Dominio.Aplicacion>()
                       .Select(Projections.RowCount())
                       .Where(x=> x.pais == pais)
                       .FutureValue<int>()
                       .Value;


            }

            return rows;
        }
        public IList<Dominio.Aplicacion> getAppInEntApp(string id_entidad)
        {
            using (ISession session = NHelper.GetCurrentSession())
            {
                IList<Dominio.EntidadAplicacion> lista = session.QueryOver<Dominio.EntidadAplicacion>()
                    .Where(x => x.idEntidad.ToString() == id_entidad).List<Dominio.EntidadAplicacion>();

                IList<Dominio.Aplicacion> apps = new List<Dominio.Aplicacion>();
                foreach (Dominio.EntidadAplicacion entapp in lista)
                {
                    apps.Add(this.getApplicacion1(entapp.idAplicacion));
                }

                return apps;
            }
        }
        #endregion
    }
    static class clsRepoConvertidor
    {
        public static DataTable Seleccionar_Datatable<TClase>() where TClase : class
        {
            clsRepo repo = new clsRepo();
            return ToDataTable<TClase>(repo.Seleccionar<TClase>());
        }
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        public static DataTable ToDataTable<T>(this List<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
