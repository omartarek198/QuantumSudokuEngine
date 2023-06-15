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
        public int R, C;

        public Cell(Rectangle dims) 
        { 
             this.dimensions = dims;
            for (int i=1;i<10;i++)
            {
                possible_numbers.Add(i);
            }
        }
        //copy constructor
        public Cell(Cell obj_to_copy_from) 
        {
            this.dimensions = obj_to_copy_from.dimensions;
            this.value = obj_to_copy_from.value;
            this.set = obj_to_copy_from.set;
            this.color = Color.White;
            this.possible_numbers = new List<int>(obj_to_copy_from.possible_numbers);
            this.R = obj_to_copy_from.R; 
            this.C = obj_to_copy_from.C;


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
