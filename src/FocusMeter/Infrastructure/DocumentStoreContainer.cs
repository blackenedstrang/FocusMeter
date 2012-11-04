using System.Diagnostics;
using System.Net;
using Raven.Client.Document;
using Raven.Client.Embedded;

namespace FocusMeter.Infrastructure
{
    public static class DocumentStoreContainer
    {
		public static DocumentStore DocumentStore { get; set; }

        public static bool CanShowDatabase { get; private set; }

        public static void Initialize(bool useEmbeddedMode)
        {
			if (useEmbeddedMode)
			{
				DocumentStore = new EmbeddableDocumentStore
				                	{
				                		DataDirectory = "Data",
				                		UseEmbeddedHttpServer = true
				                	};
			}
			else
			{
				DocumentStore = new DocumentStore
					                {
						                ConnectionStringName = "FocusMeterDB"
					                };
			}

			DocumentStore.Initialize();
			CanShowDatabase = useEmbeddedMode;
        }

        public static void ShowDatabase()
        {
            if (CanShowDatabase)
            {
            	var embeddedDocumentStore = DocumentStore as EmbeddableDocumentStore;
                Process.Start(embeddedDocumentStore.HttpServer.Configuration.ServerUrl);
            }
        }
    }
}