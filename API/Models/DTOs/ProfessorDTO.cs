using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Entities;

namespace API.Models.DTOs
{
    public class ProfessorDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EmploymentTypes EmploymentType { get; set; }
    }
}