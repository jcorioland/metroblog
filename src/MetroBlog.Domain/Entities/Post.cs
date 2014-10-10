namespace MetroBlog.Domain.Entities
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;


    /// <summary>
    /// Represents a blog post
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Creates a new instance of the class <see cref="MetroBlog.Domain.Entities.Post"/> class;
        /// </summary>
        public Post()
        {
            this.Tags = new Collection<string>();
        }

        /// <summary>
        /// Gets or sets the post identifier
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the publication date
        /// </summary>
        [JsonProperty("publishDate")]
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// Gets or sets the title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the permalink
        /// </summary>
        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        /// <summary>
        /// Gets or sets the summary
        /// </summary>
        [JsonProperty("summary")]
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the content of the post
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the collection of tags
        /// </summary>
        [JsonProperty("tags")]
        public Collection<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets a boolean that indicates if the post is published
        /// </summary>
        [JsonProperty("isPublished")]
        public bool IsPublished { get; set; }

        /// <summary>
        /// Gets or sets the username of the author
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }
    }
}