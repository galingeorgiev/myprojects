namespace WorkingWithDataMvc.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using WorkingWithDataMvc.Data;
    using WorkingWithDataMvc.Models;

    public class HomeController : BaseController
    {
        public HomeController(IUowData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var blogPost = new BlogPost { Title = "My first blog post", Content = "Blog post content" };
            this.Data.BlogPosts.Add(blogPost);

            if (User.Identity.IsAuthenticated)
            {
                var user = this.Data.Users.All().FirstOrDefault(x => x.UserName == User.Identity.Name);
                this.Data.Comments.Add(new Comment { Author = user, BlogPost = blogPost, Content = "Spam!" });
            }

            this.Data.SaveChanges();

            return this.View();
        }
    }
}