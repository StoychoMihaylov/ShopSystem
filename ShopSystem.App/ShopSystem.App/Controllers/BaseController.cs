using Microsoft.AspNet.Identity.EntityFramework;
using ShopSystem.Data.UnitOfWork;
using ShopSystem.Models.EntityModels;
using System.Web.Mvc;
using System;
using System.Web.Routing;
using System.Linq;

namespace ShopSystem.App.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IShopSystemData data)
        {
            this.Data = data;
        }

        public BaseController(IShopSystemData data, ApplicationUser user)
            :this(data)
        {
            this.UserProfile = user;
        }

        public IShopSystemData Data { get; private set; }

        public ApplicationUser UserProfile { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;
            }
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}