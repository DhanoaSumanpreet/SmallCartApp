using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            IEnumerable<User> users;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57606/api/");

                var responseTask = client.GetAsync("user");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<User>>();
                    readTask.Wait();

                    users = readTask.Result;
                }
                else
                {
                    users = Enumerable.Empty<User>();
                    ModelState.AddModelError(string.Empty, "Server error");
                }
            }

            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            user.DateCreated = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57606/api/");

                var postTask = client.PostAsJsonAsync<User>("user", user);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server error");
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            User user = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57606/api/");

                var responseTask = client.GetAsync($"user?id={id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<User>();
                    readTask.Wait();

                    user = readTask.Result;
                }
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57606/api/");

                var postTask = client.PutAsJsonAsync<User>($"user?id={id}", user);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server error");
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            User user = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57606/api/");

                var responseTask = client.GetAsync($"user?id={id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<User>();
                    readTask.Wait();

                    user = readTask.Result;
                }
            }
            return View(user);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57606/api/");

                var deleteTask = client.DeleteAsync($"user/{id}");
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}