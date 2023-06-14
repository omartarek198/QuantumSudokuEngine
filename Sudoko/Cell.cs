using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sudoko
{
    public class Cell
    {
        public Rectangle dimensions { get; private set; }
        public List<int> possible_numbers = new List<int>();
        public int value = -1;


        public Cell(Rectangle dims) 
        { 
             this.dimensions = dims;
        }

    }
}
