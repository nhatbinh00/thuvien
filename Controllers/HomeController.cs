using LiteLibrary.BusinessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Search(string searchValue="" , int page=1)
        {
            ViewBag.pageCurrent = page;
            int pageSize = 2;
            int rowCount = ShopManagementBLL.Sach_Count(searchValue);
            int pageCount = rowCount/pageSize;
            ViewBag.pageCount = rowCount / pageSize;
            if (rowCount % pageSize > 0)
            {
                ViewBag.pageCount = rowCount / pageSize + 1;
                pageCount = rowCount / pageSize + 1;
            }
            if(page  > pageCount)
            {
                page = pageCount;
            }
            if (page <= 0)
            {
                page = 1;
            }
            ViewBag.Sach = ShopManagementBLL.List_Search(searchValue , page, pageSize);
            return View(ViewBag.Sach);
        }
    }
}