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
        public bool set = false;
        public Color color = Color.White;

        public Cell(Rectangle dims) 
        { 
             this.dimensions = dims;
            for (int i=1;i<10;i++)
            {
                possible_numbers.Add(i);
            }
        }

        public void ReduceEntropy(int value)
        {
            try
            {
                this.possible_numbers.Remove(value);
            }
            catch(Exception ex)
            {
                // do nothing because it means the element does not exisit in the list 
            }
        }

    }
}
