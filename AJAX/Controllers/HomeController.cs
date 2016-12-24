using AJAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJAX.Controllers
{
	public class HomeController : Controller
	{
		private readonly List<Book> _books = new List<Book>
		{
			new Book { Id = 1, Name = "Война и мир", Author = "Толстой", Price = 220 },
			new Book { Id = 2, Name = "Анна Каренина", Author = "Толстой", Price = 220 },
			new Book { Id = 3, Name = "Муму", Author = "Тургенев", Price = 110 },
			new Book { Id = 4, Name = "Отцы и дети", Author = "Тургенев", Price = 180 },
			new Book { Id = 5, Name = "Дуэль", Author = "Чехов", Price = 150 },
			new Book { Id = 6, Name = "Каштанка", Author = "Чехов", Price = 150 },
			new Book { Id = 7, Name = "Чайка", Author = "Чехов", Price = 150 }
		};

		public ActionResult Index()
		{
			return View();
		}
				
		public ActionResult BookSearch(string name)
		{
			var allbooks = _books.Where(a => a.Author.Contains(name)).ToList();
			if (allbooks.Count <= 0)
			{
				return HttpNotFound();
			}
			return PartialView("_BookSearch", allbooks);
		}
		
		public ActionResult BestBook()
		{
			Book book = _books.First();
			return PartialView("_BestBook", book);
		}

		public JsonResult JsonSearch(string name)
		{
			var jsondata = _books.Where(a => a.Author.Contains(name)).ToList<Book>();
			return Json(jsondata, JsonRequestBehavior.AllowGet);
		}
	}
}