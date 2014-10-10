namespace MetroBlog.Web.ViewModels
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a view model for the post summaries list
    /// </summary>
    public class PostSummaryListViewModel
    {
        private readonly List<PostSummaryViewModel> postsList = new List<PostSummaryViewModel>();

        /// <summary>
        /// Gets the list of posts
        /// </summary>
        public IEnumerable<PostSummaryViewModel> PostsList
        {
            get
            {
                return this.postsList;
            }
        }

        /// <summary>
        /// Adds a post in the collection of posts
        /// </summary>
        /// <param name="post">The post to add</param>
        public void AddPost(Domain.Entities.Post post)
        {
            this.postsList.Add(new PostSummaryViewModel(post));
        }
    }
}