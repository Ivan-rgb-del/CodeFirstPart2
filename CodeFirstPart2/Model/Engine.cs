using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstPart2.Model
{
    public class Engine
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string MyProperty { get; set; } = string.Empty;
        public int SerialNumber { get; set; }
        public string Type { get; set; } = string.Empty;

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }

        [ForeignKey("EngineType")]
        public int EngineTypeId { get; set; }
        public EngineType EngineType { get; set; }
    }
}
