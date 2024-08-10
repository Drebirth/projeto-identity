using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using inventario.Context;
using inventario.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace asp.net_identity.Controllers
{
    [Authorize]
    public class InventariosController : Controller
    {
     
        private readonly InventarioDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public InventariosController(InventarioDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _contextAccessor = httpContextAccessor;
        }
        
        public IActionResult Index()
        {
            string us = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
             var produtos =_context.Inventario.ToList().Where(x => x.Dono == us);
            return View(produtos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produto produto)
        {
           var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
           string us = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            if(ModelState.IsValid)
            {   
             
                produto.Dono = us;
                _context.Inventario.Add(produto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }
    }
    
}