using System.Diagnostics;
using System.Net;
using Raven.Client.Document;
using Raven.Client.Embedded;

namespace FocusMeter.Infrastructure
{
    public class DocumentStoreContainer
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
				//TODO: configure cloud-based settings
			}

        	try
            {
                DocumentStore.Initialize();
                CanShowDatabase = useEmbeddedMode;
            }
            catch (HttpListenerException)
            {
                DocumentStore = new EmbeddableDocumentStore
                {
                    DataDirectory = "Data"
                };
                DocumentStore.Initialize();
                CanShowDatabase = false;
            }
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