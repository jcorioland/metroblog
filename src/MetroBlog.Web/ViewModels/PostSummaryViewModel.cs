namespace MetroBlog.Web.ViewModels
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a view model for post summaries
    /// </summary>
    public class PostSummaryViewModel
    {
        /// <summary>
        /// Creates a new instance of the <see cref="PostSummaryViewModel"/> class.
        /// </summary>
        /// <param name="post">The post to encaplusate</param>
        public PostSummaryViewModel(MetroBlog.Domain.Entities.Post post)
        {
            if(post == null)
            {
                throw new ArgumentNullException("post");
            }

            this.PostId = post.Id;
            this.Permalink = post.Permalink;
            this.Tags = post.Tags;
            this.Title = post.Title;
            this.Summary = post.Summary;
            this.PublishDate = post.PublishDate;
            this.Username = post.Username;
        }

        /// <summary>
        /// Gets the post identifier
        /// </summary>
        public Guid PostId { get; private set; }

        /// <summary>
        /// Gets the post permalink
        /// </summary>
        public string Permalink { get; private set; }

        /// <summary>
        /// Gets the post tags
        /// </summary>
        public IEnumerable<string> Tags { get; private set; }

        /// <summary>
        /// Gets the post title
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets the post summary
        /// </summary>
        public string Summary { get; private set; }

        /// <summary>
        /// Gets the post publish date
        /// </summary>
        public DateTime PublishDate { get; private set; }

        /// <summary>
        /// Gets the post username
        /// </summary>
        public string Username { get; private set; }
    }
}