using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDesk2.Models
{
    public class Desk
    {
        public enum DesktopMaterial
        {
            Oak,
            Laminate,
            Pine,
            Rosewood,
            Veneer
        }

        public int ID {get; set;}

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }

        [Display(Name = "Number of Drawers")]
        public int NumDrawers { get; set; }
        public string Shipping { get; set; }
        public DesktopMaterial Material { get; set; }

        [Display(Name = "Quote Date")]
        [DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public int Total { get; set; }
    }
}
