using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBlog.Model
{
    public class Click
    {
        public Click(int numClick)
        {
            NumClick = numClick;
        }

        public int NumClick
        {
            get; set;
        }
    }
}
