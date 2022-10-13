using Client_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Client_1.Controllers
{
    public class MarksController : Controller
    {
        // GET: Marks
        public ActionResult Index()
        {
            List<mark1> emplist = new List<mark1>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44300//api/");

                var responseTask = client.GetAsync("Values");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readData = result.Content.ReadAsAsync<mark1[]>();
                    readData.Wait();
                    var empdata = readData.Result;
                    foreach (var item in empdata)
                    {
                        emplist.Add(new mark1
                        {
                            Id = item.Id,
                            Name = item.Name,
                            subject_marks = item.subject_marks
                        });

                    }
                }
            }
            return View(emplist);

        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]

        public ActionResult Create(mark1 empmodel)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44300//api/Values");

                var emp = new mark1
                {
                   Id = empmodel.Id,
                    Name = empmodel.Name,
                    subject_marks = empmodel.subject_marks
                };

                var postTask = client.PostAsJsonAsync<mark1>(client.BaseAddress, emp);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtaskResult = result.Content.ReadAsAsync<mark1>();

                    readtaskResult.Wait();
                    var dataInserted = readtaskResult.Result;
                }


            }

            return RedirectToAction("Index");
        }
    }
}