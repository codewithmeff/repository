using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repositorio.Entidades;
using Repositorio.DAL.Contexto;
using Repositorio.DAL;

namespace Repositorio.MVC.Controllers
{
    public class ClientesController : Controller
    {
        //private BancoContexto db = new BancoContexto();
        private readonly ClienteRepositorio repCli = new ClienteRepositorio();

        // GET: /Clientes/
        public ActionResult Index()
        {
            //return View(db.Cliente.ToList());
            return View(repCli.GetAll().ToList());
        }

        // GET: /Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cliente cliente = db.Cliente.Find(id);
            Cliente cliente = repCli.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: /Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ClienteID,Nome,CNPJ,Endereco,Telefone,Ativo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                repCli.Adicionar(cliente);
                //db.Cliente.Add(cliente);
                //db.SaveChanges();
                repCli.SalvarTodos();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: /Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
//            Cliente cliente = db.Cliente.Find(id);
            Cliente cliente = repCli.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: /Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ClienteID,Nome,CNPJ,Endereco,Telefone,Ativo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(cliente).State = EntityState.Modified;
                //db.SaveChanges();

                repCli.Atualizar(cliente);
                repCli.SalvarTodos();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: /Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
//            Cliente cliente = db.Cliente.Find(id);
            Cliente cliente = repCli.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: /Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Cliente cliente = db.Cliente.Find(id);
            //db.Cliente.Remove(cliente);
            //db.SaveChanges();

            Cliente cliente = repCli.Find(id);
            repCli.Excluir(c=> c == cliente);
            repCli.SalvarTodos();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                repCli.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
