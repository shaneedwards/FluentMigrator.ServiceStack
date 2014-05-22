﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.OrmLite;
using System.Data.SQLite;
using System.IO;

namespace FluentMigrator.ServiceStack.TestV3
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        public class AppHost : AppHostBase
        {
            public AppHost() : base("Fluent Migrator Web Services", typeof(AppHost).Assembly) { }

            public override void Configure(Funq.Container container)
            {
                var dbPath = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "test.db");
                //File.Delete(dbPath);

                //SQLiteConnection.CreateFile(dbPath);
                Plugins.Add(new MigrationFeature(typeof(TestMigrations.Mig_01).Assembly));
                
                container.Register<IDbConnectionFactory>(new OrmLiteConnectionFactory("Data Source=" + dbPath + ";Version=3;", false, SqliteDialect.Provider));
            }
        }

        protected void Application_Start()
        {
            new AppHost().Init();
        }
    }
}