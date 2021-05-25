using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class theloai
    {
        public string parent_maloai { get; set; }
        public string idtheloai { get; set; }
        public string tentheloai { get; set; }
        public List<theloai> children { get; set; }
        public string type { get; set; }
    }
}
