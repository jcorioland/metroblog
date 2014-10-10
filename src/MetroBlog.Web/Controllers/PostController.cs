namespace MetroBlog.Web.Controllers
{
    using Microsoft.AspNet.Mvc;
    using MetroBlog.Domain;
    using MetroBlog.Domain.Queries;
    using MetroBlog.Web.ViewModels;
    using System.Threading.Tasks;

    public class PostController : Controller
    {
        private readonly DocumentDbOptions documentDbOptions;

        public PostController(DocumentDbOptions documentDbOptions)
        {
            this.documentDbOptions = documentDbOptions;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = new GetPostsQuery(this.documentDbOptions);
            var posts = await query.ExecuteAsync();

            var viewModel = new PostSummaryListViewModel();

            foreach(var post in posts)
            {
                viewModel.AddPost(post);
            }

            return View(viewModel);
        }
    }
}
