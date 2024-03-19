using CodeFirstPart2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class CreateEngineTypeDto
    {
        public int Id {  get; set; }
        public string Model { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        //public List<Engine> Engines { get; set; }
    }
}
