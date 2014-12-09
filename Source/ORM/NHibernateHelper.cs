using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfOrm;
using ConfOrm.NH;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Tool.hbm2ddl;
using ConfOrm.Patterns;
using System.Reflection;

namespace XTHospital.ORM
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        static NHibernateHelper()
        {
            _sessionFactory = GetSessionFactory();
        }
        private static ISessionFactory GetSessionFactory()
        {
            return (new Configuration()).Configure().BuildSessionFactory();
        }
        public static ISession GetSession()
        {
            return _sessionFactory.OpenSession();
        }

        public static HbmMapping GetEntityMapping<T>() where T : class
        {
            var orm = new ObjectRelationalMapper();
            //指定Domain中的主键列名，如果没有自动生成一个列名为id的guid类型的主键
            orm.Patterns.Poids.Add(new PoidPropertyAsIdClassName("Id"));
            //指定生成策略
            orm.Patterns.PoidStrategies.Add(new IdentityPoidPattern());//Identity
            //orm.Patterns.PoidStrategies.Add(new AssignedPoidPattern());//Assigned
            orm.TablePerClass<T>();
            var mapper = new Mapper(orm);
            var mapping = mapper.CompileMappingFor(new[] { typeof(T) });
            //Console.Write(mapping.AsString());
            return mapping;
        }
    }
}
