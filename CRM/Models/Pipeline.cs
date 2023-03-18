using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CRM.Models
{
    public class Pipeline
    {
        public int ID { get; set; }

        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal ExpectedRevenue { get; set; }

        public int? ContactID { get; set; }
        public Contact? Contact { get; set; }//navigation property
        public int? SalespersonID { get; set; }
        public Salesperson? Salesperson { get; set; }//navigation property
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public string LogNote { get; set; }
        public string TaskName { get; set; }
        public DateTime TaskDeadline { get; set; }
    }
}
