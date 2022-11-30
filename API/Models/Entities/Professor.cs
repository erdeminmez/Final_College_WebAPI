using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Entities
{
    public enum EmploymentTypes 
    {
        FullTime,
        PartTime
    }
    public class Professor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EmploymentTypes EmploymentType { get; set; }
        public List<Course> Courses { get; set; }
    }
}