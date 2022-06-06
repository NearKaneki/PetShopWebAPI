using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DtoForBooking
    {
        public int ItemId { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
