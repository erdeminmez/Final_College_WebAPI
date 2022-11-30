using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.DTOs
{
    public class CoursesDTO
    {
        public Guid Id {get; set;}

        public string Title {get; set;}

        public int NumberOfCredits {get; set;}
    }
}