using Microsoft.AspNet.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MetroBlog.vNext.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var postsQuery = new Domain.Queries.GetPostsQuery("https://aspnetvnextblog.documents.azure.com:443/", "WYx/OWfZmCAS87RuI91BT82nF89ZSazo7QmVVJZFmP6QFg8FAwj9dSaSNAxBvMfZP/rhxZGLYCGJBnzkmEI6uQ==", "MetroBlogDatabase");
            var posts = await postsQuery.ExecuteAsync();

            return View(posts);
        }

        [HttpGet]
        public async Task<IActionResult> CreateNew()
        {
            var thePost = new Domain.Entities.Post();
            thePost.Content = "<p>Hello World !<p>";
            thePost.Id = Guid.NewGuid();
            thePost.IsPublished = true;
            thePost.Permalink = "hello-world";
            thePost.PublishDate = DateTime.UtcNow;
            thePost.Summary = "<p>Hello</p>";
            thePost.Tags.Add("Azure");
            thePost.Tags.Add("ASP.NET vNext");
            thePost.Tags.Add("DocumentDB");
            thePost.Title = "Sample post at " + DateTime.UtcNow.ToShortTimeString();
            thePost.Username = "jcorioland";

            var createPostCommand = new Domain.Commands.CreatePostCommand(
                "https://aspnetvnextblog.documents.azure.com:443/",
                "WYx/OWfZmCAS87RuI91BT82nF89ZSazo7QmVVJZFmP6QFg8FAwj9dSaSNAxBvMfZP/rhxZGLYCGJBnzkmEI6uQ==",
                "MetroBlogDatabase",
                thePost);

            await createPostCommand.ExecuteAsync();

            return RedirectToAction("Index");
        }
    }
}
