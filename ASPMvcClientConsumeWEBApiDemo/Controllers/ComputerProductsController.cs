﻿using ASPMvcClientConsumeWEBApiDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASPMvcClientConsumeWEBApiDemo.Controllers
{
    public class ComputerProductsController : Controller
    {
        // GET: ComputerProductsController
        //http://localhost:7652/api/Products
        public async Task<IActionResult> Index()
        {
            List<Product> products = new List<Product>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:7652/"); //copy this url from swagger get method (web api project)
            HttpResponseMessage response = await client.GetAsync("api/Products");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(result); // for JSONConvert install newtonsoft nuget package

            }

            return View(products);
        }

        // GET: ComputerProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComputerProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComputerProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComputerProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComputerProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComputerProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComputerProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
