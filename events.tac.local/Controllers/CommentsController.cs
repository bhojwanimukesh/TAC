﻿using events.tac.local.Models;
using Glass.Mapper.Sc.Web.Mvc;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class CommentsController : Controller
    {

        public IMvcContext MvcContext { get; private set; }

        public CommentsController()
        {
            MvcContext = new MvcContext();
        }
        // GET: Test
        public ActionResult Index()
        {
            var comments = MvcContext.GetContextItem<IEventDetails>().Comments;
            return View(comments);
        }
    }
}