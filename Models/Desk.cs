﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public int Width { get; set; }
        public int Depth { get; set; }
        public int NumDrawers { get; set; }
        public string Shipping { get; set; }
        public DesktopMaterial Material { get; set; }
        [DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }
    }
}
