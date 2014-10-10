namespace MetroBlog.Domain.Commands
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Summary description for CreatePostCommand
    /// </summary>
    public class CreatePostCommand : DocumentDbCommandQueryBase
    {
        private readonly Domain.Entities.Post post;

        /// <summary>
        /// Creates a new instance of the <see cref="CreatePostCommand"/> class.
        /// </summary>
        /// <param name="options">The document db options</param>
        /// <param name="post">The post to create</param>
        /// <exception cref="System.ArgumentNullException">The post can't be null</exception>
	    public CreatePostCommand(DocumentDbOptions options, Domain.Entities.Post post)
            : base(options)
        {
            if(post == null)
            {
                throw new ArgumentNullException("post");
            }

            this.post = post;
        }

        /// <summary>
        /// Executes the command, asynchronously
        /// </summary>
        /// <returns>A Task, for asynchronous execution</returns>
        public async Task ExecuteAsync()
        {
            var documentCollection = await this.GetDocumentCollectionAndCreateIfNotExists("Posts");
            await this.DocumentClient.CreateDocumentAsync(documentCollection.SelfLink, this.post);
        }
    }
}