using System.Dynamic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Net;
using TomaszDrzewieckiCybercom2017.Models;

namespace TomaszDrzewieckiCybercom2017.Controllers
{
    public class ListaMieszanaController : Controller
    {

        private DBLibrary db = new DBLibrary();
        public ActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.Book = GetBooks();
            model.Author = GetAuthors();           
            return View(model);
        }
       
        private static List<Author> GetAuthors()
        {            
            DBLibrary db = new Models.DBLibrary();          
            var  authors = (from item in db.tabAuthors
                         orderby item.Name
                         select item).ToList();
            return authors;
        }
        // GET: ListaAutorow/Edit/5?rodzaj=
        public ActionResult Edit(int? id, string rodzaj )
        {            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (rodzaj != null)
            { 
                if (rodzaj == "ksiazka")
                {
                   Book book = db.tabBooks.Find(id);
                    if (book == null)
                    {
                        return HttpNotFound();
                    }
                    return View("EditBook", book);
                }
                else
                {                                  
                    Author author = db.tabAuthors.Find(id);
                    if (author == null)
                    {
                        return HttpNotFound();
                    }
                    return View("EditAuthor",author);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }            
        }
        // POST: ListaAutorow/Edit/5?rodzaj=
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "Id,Name,Surname")] Author author, [Bind(Include = "Id,Title,ISBN,ReleaseDate,AuthorId")] Book book, string rodzaj)
        {            
                if (rodzaj == "ksiazka")
                {
                    db.Entry(book).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                { 
                    db.Entry(author).State = EntityState.Modified;
                    db.SaveChanges();
                }             
            
            return RedirectToAction("Index");
        }

        private static List<Book> GetBooks()
        { 
            List<Book> books = new List<Book>();
            string query = "SELECT  Id, Title, AuthorId, ReleaseDate, ISBN  FROM Books";
            string constr = ConfigurationManager.ConnectionStrings["DBLibrary"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            books.Add(new Book
                            {
                                Id = Convert.ToInt32( sdr["Id"].ToString()),
                                Title = sdr["Title"].ToString(),
                              // ISBN = Convert.ToInt32(sdr["ISBN"].ToString()),
                              // ReleaseDate = Convert.ToInt32(sdr["ReleaseDate"].ToString()),
                            });
                        }
                    }
                    con.Close();
                    return books;
                }
            }
        }
    }
}