using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPRPoc.Entities
{
    public class Car : BaseEntity
    {
        public required string Plate { get; set; }
        public required string Maker { get; set; }
        public required string Model { get; set; }
        public required string Color { get; set; }
    }
}
