using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebAPI.Models
{
    public class BookStore
    {
        public List<Book> Books => new List<Book>
        {
            new Book
            {
                Id = 1,
                Author = "1",
                Title = "1",
                Price = 1
            },
            new Book
            {
                Id = 2,
                Author = "2",
                Title = "2",
                Price = 2
            },new Book
            {
                Id = 3,
                Author = "3",
                Title = "3",
                Price = 3
            },new Book
            {
                Id = 4,
                Author = "4",
                Title = "4",
                Price = 4
            }
        };

        public Dictionary<int, int[]> Orders => new Dictionary<int, int[]>
        {
            {1, new int[] { 1,3 } },
            {2, new int[] { 2,3,4 } }
        };
    }
}
