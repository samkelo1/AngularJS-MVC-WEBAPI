using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularJsWebapi.Models
{
    public class Book
    {
        [Key]
        public int Id
        {
            get;
            set;
        }
        [Required]
        [StringLength(20)]
        public string ISBN
        {
            get;
            set;
        }
        [Required]
        [StringLength(20)]
        public string Title
        {
            get;
            set;
        }
        [Required]
        [StringLength(100)]
         public string Subtitle
        {
            get;
            set;
        }
        [Required]
        [StringLength(255)]
        public string Description
        {
            get;
            set;
        }
        [Required]
        [StringLength(50)]
        public string Contributors
        {
            get;
            set;
        }
        public string Language
        {
            get;
            set;
        }
        public DateTime PublicationDate
        {
            get;
            set;
        }
        
    }
    public class BookDbContext : DbContext
    {
        public BookDbContext() : base()
        {
            //Database.SetInitializer<BookDbContext>(newBookDbContextInitializer());
        }

        //private IDatabaseInitializer<BookDbContext> newBookDbContextInitializer()
        //{
        //    throw new NotImplementedException();
        //}

        public DbSet<Book> Books
        {
            get;
            set;
        }
    }
    public class BookDbContextInitializer : DropCreateDatabaseIfModelChanges<BookDbContext>
    {
        protected override void Seed(BookDbContext context)
        {
            var list = new List<Book>
        {
            new Book
            {
                ISBN = "IDS-B455", Title = "Mane", Subtitle = "MHkihi", Description = "Rohit Mane", PublicationDate = DateTime.Now.AddYears(-24), Contributors = "IN", Language = "English"
            },
            new Book
            {
               ISBN = "IDS-B455-4444", Title = "Maneisl", Subtitle = "MHhyl", Description = "Rohit Mane", PublicationDate = DateTime.Now.AddYears(-24), Contributors = "IN", Language = "English"
            }
            ,
            new Book
            {
               ISBN = "IDS-B455-22", Title = "Maneisl", Subtitle = "MHhyl", Description = "Rohit Mane", PublicationDate = DateTime.Now.AddYears(-24), Contributors = "IN", Language = "English"
            }
            ,
            new Book
            {
               ISBN = "IDS-B455-44552", Title = "Maneisl", Subtitle = "MHhyl", Description = "Rohit Mane", PublicationDate = DateTime.Now.AddYears(-24), Contributors = "IN", Language = "English"
            }
            ,
            new Book
            {
               ISBN = "IDS-B455-45782", Title = "Maneisl", Subtitle = "MHhyl", Description = "Rohit Mane", PublicationDate = DateTime.Now.AddYears(-24), Contributors = "IN", Language = "English"
            }
        };
            list.ForEach(m =>
            {
                context.Books.Add(m);
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
