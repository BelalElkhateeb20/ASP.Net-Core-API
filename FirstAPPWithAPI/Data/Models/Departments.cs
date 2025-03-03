using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAPPWithAPI.Data.Models
{
    [Table("Department",Schema ="Departments")]
    public class Departments
    {
        public int Id { get; set; }
        public string? ShortName { get; set; }
        public string? LongName { get; set; }
        public List<Employee>? emp { get; set; }
    }
}
