using AngularJsWebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace AngularJsWebapi.Controllers
{
    public class BooksController : ApiController
    {
        BookDbContext db = new BookDbContext();
        // GET api/books  
        [ActionName("get"), HttpGet]
        public IEnumerable<Book> Emps()
        {
            return db.Books.ToList();
        }
        // GET api/employee/5  
        public Book Get(int id)
        {
            return db.Books.Find(id);
        }
        // POST api/employee  
        public HttpResponseMessage Post(Book model)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(model);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        // PUT api/Books/5  
        public HttpResponseMessage Put(Book model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        // DELETE api/Books/5  
        public HttpResponseMessage Delete(int id)
        {
            Book bk = db.Books.Find(id);
            if (bk == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Books.Remove(bk);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, bk);
        }
    }
}
