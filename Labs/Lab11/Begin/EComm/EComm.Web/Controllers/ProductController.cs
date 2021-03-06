﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComm.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EComm.Web.Controllers
{
    public class ProductController : Controller
    {
        private ECommDataContext _dataContext;

        public ProductController(ECommDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [Route("product/{id:int}")]
        public IActionResult Detail(int id)
        {
            var product = _dataContext.Products.Include(p => p.Supplier).SingleOrDefault(p => p.Id == id);
            return View(product);
        }
    }
}