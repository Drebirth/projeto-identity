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
        {   var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //string us = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var produtos =_context.Inventario.ToList().Where(x => x.Dono == userId);
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
           //string us = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
           if(produto.Quantidade < 0)
                {
                    ModelState.AddModelError("Quantidade", "A quantidade não pode ser vazia!");
                }
            if(ModelState.IsValid)
            {        
                produto.Dono = userId;
                _context.Inventario.Add(produto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public IActionResult Details(int id)
        {
            var item = _context.Inventario.Find(id);
            if(item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            var item = _context.Inventario.Find(id);
            if(item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Produto produto)
        {
            var item = _context.Inventario.Find(produto.Id);
            if(ModelState.IsValid)
            {
                item.Nome = produto.Nome;
                item.Descricao = produto.Descricao;
                item.Quantidade = produto.Quantidade;
                _context.Inventario.Update(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public IActionResult Delete(int id)
        {
            var item = _context.Inventario.Find(id);
            if(item == null)
            {
                ModelState.AddModelError("Nome","Id não encontrado!");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(Produto produto)
        {
            var item = _context.Inventario.Find(produto.Id);
            _context.Inventario.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    
}