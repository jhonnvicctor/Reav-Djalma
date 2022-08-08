using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class EmpresasPController : Controller
    {
        // GET: Cadastro
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cadastro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cadastro/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            EmpresasP EmpresasP = new EmpresasP();
            EmpresasP.nomeProprietario = form["nomeProprietario"];
            EmpresasP.email = form["email"];
            EmpresasP.CNPJ = form["CNPJ"];
            EmpresasP.NomeEmpresa = form["NomeEmpresa"];


            if (ModelState.IsValid)
            {

                using (Conexao conexao = new Conexao())
                {
                    var StrQuery = "INSERT INTO Cadastro(nomeProprietario, email, CNPJ, NomeEmpresa) values (@nomeProprietario, @email, @CNPJ, @NomeEmpresa)";
                    SqlCommand comando = new SqlCommand(StrQuery, conexao.conn);
                    comando.Parameters.AddWithValue("@nome", EmpresasP.nomeProprietario);
                    comando.Parameters.AddWithValue("@email", EmpresasP.email);
                    comando.Parameters.AddWithValue("@senha", EmpresasP.CNPJ);
                    comando.Parameters.AddWithValue("@Empresa", EmpresasP.NomeEmpresa);
                    Console.WriteLine(StrQuery);
                    comando.ExecuteNonQuery();
                    return RedirectToAction("Index");
                }
            }
            return View(EmpresasP);


        }
        // GET: Cadastro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cadastro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cadastro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cadastro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}