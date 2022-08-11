using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsRowDeleted { get; set; }
        public string MakeBy { get; set; } = string.Empty;
        public DateTime MakeDate { get; set; } = DateTime.Parse("1/1/1753");
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedDate { get; set; }
    }
}
