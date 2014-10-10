namespace MetroBlog.Domain.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.Documents.Linq;

    /// <summary>
    /// Defines a query used to get the blog posts from the data store
    /// </summary>
    public class GetPostsQuery : DocumentDbCommandQueryBase
    {
        private string postPermalink;

        /// <summary>
        /// Creates a new instance of the <see cref="GetPostsQuery"/> class.
        /// </summary>
        /// <param name="options"></param>
        public GetPostsQuery(DocumentDbOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Configures the query to take only one post by its id
        /// </summary>
        /// <param name="postPermalink">The post identifier</param>
        /// <returns>The query configured</returns>
        public GetPostsQuery ForId(string postPermalink)
        {
            this.postPermalink = postPermalink;
            return this;
        }

        /// <summary>
        /// Executes the query asynchronously
        /// </summary>
        /// <returns>The collection of posts that match the query, wrapped in a Task for asynchronous execution</returns>
        public async Task<IEnumerable<Domain.Entities.Post>> ExecuteAsync()
        {
            var documentCollection = await this.GetDocumentCollectionAndCreateIfNotExists("Posts");

            var postsQuery = this.DocumentClient
                .CreateDocumentQuery<Domain.Entities.Post>(documentCollection.DocumentsLink)
                .Where(p => p.IsPublished)
                .AsQueryable();

            if (!string.IsNullOrEmpty(postPermalink))
            {
                postsQuery = postsQuery.Where(p => p.Permalink == postPermalink);
            }

            var documentQuery = postsQuery.AsDocumentQuery();

            var posts = new List<Domain.Entities.Post>();
            var result = await documentQuery.ExecuteNextAsync<Domain.Entities.Post>();
            posts.AddRange(result);
            while (documentQuery.HasMoreResults)
            {
                result = await documentQuery.ExecuteNextAsync<Domain.Entities.Post>();
                posts.AddRange(result);
            }

            return posts;
        }
    }
}