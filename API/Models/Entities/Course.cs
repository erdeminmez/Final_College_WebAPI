using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int NumberOfCredits { get; set; }
        public List<Professor> Professors { get; set; }
    }
}