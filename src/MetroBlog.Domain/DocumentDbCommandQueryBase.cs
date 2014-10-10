namespace MetroBlog.Domain
{
    using Microsoft.Azure.Documents.Client;
    using Microsoft.Azure.Documents.Linq;
    using System.Linq;
    using System.Threading.Tasks;


    /// <summary>
    /// Defines a base class for all queries
    /// </summary>
    public abstract class DocumentDbCommandQueryBase
    {
        private readonly DocumentDbOptions options;
        protected readonly DocumentClient DocumentClient;

        /// <summary>
        /// Creates a new instance of the <see cref="DocumentDbCommandQueryBase"/> class.
        /// </summary>
        /// <param name="options">The DocumentDB options</param>
        public DocumentDbCommandQueryBase(DocumentDbOptions options)
        {
            this.options = options;
            this.DocumentClient = new DocumentClient(new System.Uri(options.EndpointUrl), options.AuthorizationKey);
        }

        /// <summary>
        /// Gets the document DB database and creates it if it does not exists, asynchronously
        /// </summary>
        /// <returns>The database, wrapped in a Task, for asynchronous execution</returns>
        protected async Task<Microsoft.Azure.Documents.Database> GetDatabaseAndCreateIfNotExists()
        {
            var database = this.DocumentClient.CreateDatabaseQuery()
                .Where(d => d.Id == this.options.DatabaseId)
                .AsEnumerable()
                .FirstOrDefault();

            if (database == null)
            {
                database = await this.DocumentClient.CreateDatabaseAsync(
                    new Microsoft.Azure.Documents.Database()
                    {
                        Id = this.options.DatabaseId
                    });
            }

            return database;
        }

        /// <summary>
        /// Gets the document collection by its id and creates it if it does not exists
        /// </summary>
        /// <param name="collectionId">The collection identifier</param>
        /// <returns>The document collection wrapped in a Task for asynchronous execution</returns>
        protected async Task<Microsoft.Azure.Documents.DocumentCollection> GetDocumentCollectionAndCreateIfNotExists(string collectionId)
        {
            var database = await this.GetDatabaseAndCreateIfNotExists();

            var documentCollection = this.DocumentClient.CreateDocumentCollectionQuery(database.SelfLink)
                .Where(d => d.Id == collectionId)
                .AsEnumerable()
                .FirstOrDefault();

            if(documentCollection == null)
            {
                documentCollection = await this.DocumentClient.CreateDocumentCollectionAsync(
                    database.SelfLink,
                    new Microsoft.Azure.Documents.DocumentCollection()
                    {
                        Id = collectionId
                    });
            }

            return documentCollection;
        }
    }
}
