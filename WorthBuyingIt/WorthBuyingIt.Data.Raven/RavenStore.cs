using System;
using System.Collections.Concurrent;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Linq;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;
using Raven.Client.Indexes;
using WorthBuyingIt.Controllers;

namespace WorthBuyingIt.Data.Raven
{
    /// <summary>
    /// This class manages the state of objects that desire a document session. We aren't relying on an IoC container here
    /// because this is the sole case where we actually need to do injection.
    /// </summary>
    public class RavenStore
    {
        private static IDocumentStore _documentStore;

        /// <summary>
        /// Singleton implementation to prevent multiple stores instantiating
        /// </summary>
        public static IDocumentStore DocumentStore
        {
            get
            {
                if (_documentStore != null)
                    return _documentStore;

                lock (typeof(RavenController))
                {
                    if (_documentStore != null)
                        return _documentStore;

                    _documentStore = new DocumentStore
                    {
                        ConnectionStringName = "RavenDb",
                    }
                    .Initialize();

                    //_documentStore.Conventions.IdentityPartsSeparator = "-";


                    if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["RavenDb.DefaultDatabase"]))
                        _documentStore.DatabaseCommands.EnsureDatabaseExists(
                          ConfigurationManager.AppSettings["RavenDb.DefaultDatabase"]);


                }

                return _documentStore;
            }
        }

        public static IDocumentSession GetSession()
        {
            return DocumentStore.OpenSession(ConfigurationManager.AppSettings["RavenDb.DefaultDataBase"]);
        }
    }
}