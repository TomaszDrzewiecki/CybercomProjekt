using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace TomaszDrzewieckiCybercom2017.Models
{
    public class DBLibrary : DbContext
    {
        public DbSet<Book> tabBooks { get; set; }
        public DbSet<Author> tabAuthors { get; set; }
        public void TestDate()
        {
            Book s1 = new Models.Book() { Title = "Pan Tadeusz", ReleaseDate = 1834,  ISBN= 1, AuthorId = 1};
            this.tabBooks.Add(s1);
            this.tabBooks.Add(new Models.Book() { Title = "Grażyna", ReleaseDate = 1823, ISBN = 2, AuthorId = 1 });
            this.tabBooks.Add(new Models.Book() { Title = "Dziady Część III", ReleaseDate = 1832, ISBN = 3, AuthorId = 1});
            this.tabBooks.Add(new Models.Book() { Title = "Ballady i Romanse", ReleaseDate = 1822, ISBN = 4, AuthorId = 1});
            this.tabBooks.Add(new Models.Book() { Title = "Ogniem i Mieczem", ReleaseDate = 1884, ISBN = 5, AuthorId = 2});
            this.tabBooks.Add(new Models.Book() { Title = "Kordian", ReleaseDate = 1834, ISBN = 6, AuthorId = 3 });
            this.tabBooks.Add(new Models.Book() { Title = "Balladyna", ReleaseDate = 1839, ISBN = 7, AuthorId = 3 });
            this.tabAuthors.Add(new Models.Author(){Name = "Adam", Surname = "Mickiewicz" });
            this.tabAuthors.Add(new Models.Author() { Name = "Juliusz", Surname = "Słowacki" });
            this.SaveChanges();
        }
    }

}
