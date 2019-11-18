using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModels
{
    public class SideList
    {
        public int id { get; set; }
        public string name { get; set; }
        public string abr_nome { get; set; }
        public float distance { get; set; }
        public float[] location { get; set; }
    }
}
