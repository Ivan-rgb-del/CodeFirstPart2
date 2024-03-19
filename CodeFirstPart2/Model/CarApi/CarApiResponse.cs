using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstPart2.Model.CarApi
{
    public class CarApiResponse
    {
        public Collection Collection { get; set; }
        public List<CarData> Data { get; set; }
    }
}
