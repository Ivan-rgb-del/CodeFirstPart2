using CodeFirstPart2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class CreateEngineDto
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string MyProperty { get; set; } = string.Empty;
        public int SerialNumber { get; set; }
        public string Type { get; set; } = string.Empty;
        //public Car? Car { get; set; }
        public int CarId { get; set; }
        public int EngineTypeId { get; set; }
        //public EngineType? EngineType { get; set; }
    }
}
