using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstPart2.Model.CarApi
{
    public class CarData
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }
        public CarMake Make { get; set; }
    }
}
