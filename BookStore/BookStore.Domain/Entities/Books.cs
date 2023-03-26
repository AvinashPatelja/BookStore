using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Books 
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
    }
}
