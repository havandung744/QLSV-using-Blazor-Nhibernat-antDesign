using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using ISession = NHibernate.ISession;

namespace QLSV.Data
{
    public static class FluentNHibernateHelper
    {
        public static ISessionFactory _sessionFactory;
        public static ISessionFactory SessionFactory
        {
            get { return _sessionFactory == null ? _sessionFactory = OpenConect() : _sessionFactory; }
        }

    public static ISessionFactory OpenConect()
        {
            string connectionString = "Data Source=LAPTOP-EHJCF543\\SQLEXPRESS;Initial Catalog=QuanLiSV;User ID=sa;Password=123456;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        var sessionFactory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.
            ConnectionString(connectionString))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Student>()).
            ExposeConfiguration(cfg => new SchemaExport(cfg)
            .Create(false, false))
            .BuildSessionFactory();
        return sessionFactory;
        }
        public static ISession OpenSession()
        {
            try
            {
                return SessionFactory.OpenSession();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
