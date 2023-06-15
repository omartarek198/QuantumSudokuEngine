namespace Sudoko
{
    public partial class Form1 : Form
    {
        Visualizer visualizer;
        List<List<Cell>> grid;
        System.Windows.Forms.Timer T = new System.Windows.Forms.Timer();
        Bitmap offset;

        public Form1()
        {
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.T.Tick += T_Tick;
        }

        private void T_Tick(object? sender, EventArgs e)

        {
            visualizer.Draw(CreateGraphics(), offset, this.grid);
        }

        public void Form1_Paint(object? sender, PaintEventArgs e)
        {

            visualizer.Draw(CreateGraphics(), offset, this.grid);
            //T.Start();
        }

        public void Form1_Load(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            offset = new Bitmap(this.Width, this.Height);
            visualizer = new Visualizer();
            MakeBoard();
            SeedBoard(25);
            visualizer.Draw(CreateGraphics(), offset, this.grid);
            solve();
          
        }
        void MakeBoard()
        {
            this.grid = new List<List<Cell>>();
            for (int i = 0; i < 9; i++)
            {

                grid.Add(new List<Cell>());
                for (int k = 0; k < 9; k++)
                {
                    
                    if (i < 3 && k < 3)
                    {

                    }
                    Cell cell = new Cell(new Rectangle(75 * k + 700, 75 * i+100, 75, 75));
                    grid[i].Add(cell);
                }
            }
        }
        int Choice(List<int> list)

        {
            // implementation of the Choice function in python

            try
            {
                Random random = new Random();
                return list[random.Next(list.Count)];
            } catch
            {
                return -1;
            }
           

        }
        void WhitenBoard()
        {
            for (int i = 0; i < this.grid.Count; i++)
            {
                for (int j = 0; j < this.grid.Count; j++)
                {
                    this.grid[i][j].color = Color.White;

                }
            }
        }
       void SeedBoard( int ct)
        {
            // input : the board to be seeded and the number of seeds 
            // output : seeded board


            Random random = new Random();
          
            int r, c;
            for (int i=0;i<ct;i++)
            {
                r = random.Next(grid.Count);
                c = random.Next(grid.Count);

                grid[r][c].value = Choice(grid[r][c].possible_numbers);
                grid[r][c].set = true;
                if (grid[r][c].value == -1)
                {
                    MessageBox.Show("Contradiction at" + i.ToString());
                }
                UpdateEntropy(r, c);
               
            }
        }
        bool Solved()
        {
            int ct = 0;
            for (int i = 0; i < this.grid.Count; i++)
            {
                for (int j = 0; j < this.grid.Count; j++)
                {
                    if (grid[i][j].value !=-1)
                    {
                        ct++;
                    }
                   
                }
            }
            return ct == 80;
        }
        void solve()
        {
            while (!Solved())
            {
                 List<Point> cells = GetMinimumEntropy();
                grid[cells[0].X][cells[0].Y].value = Choice(grid[cells[0].X][cells[0].Y].possible_numbers);
                grid[cells[0].X][cells[0].Y].set = true;
                grid[cells[0].X][cells[0].Y].possible_numbers.Clear();
                visualizer.Draw(CreateGraphics(), offset, this.grid);
                UpdateEntropy(cells[0].X, cells[0].Y);
                visualizer.Draw(CreateGraphics(), offset, this.grid);
                WhitenBoard();
                visualizer.Draw(CreateGraphics(), offset, this.grid);
            }

        }
        PriorityQueue<Cell, int> GetMinimumEntropy(List<List<Cell>> board)
        {
            //returns a list containing all unset cells sorted based on each cell's entropy
            PriorityQueue<Cell,int> priorityQueue = new PriorityQueue<Cell,int>();
            for (int i=0;i<board.Count;i++)
            {
                for (int k=0;k<board.Count;k++)
                {
                    if (!board[i][k].set)
                    {
                        priorityQueue.Enqueue(board[i][k], board[i][k].possible_numbers.Count); // i love data structures
                    }
                }
            }
          
            return priorityQueue;
        }
        void UpdateEntropy(int r,int c)

        {
            //called upon setting a value for grid[r][c]

            //Entropy is equal to the count of possible remaining states in the current superposition 

            //Once a cell R,C is narrowed down to one possible state, it affects the entropy for neighbouring cells


            // Calculating which Square we are in through a series of basic If-elses 

            int start_row = -1, start_col = -1, end_row = -1, end_col = -1;
            if (r < 3)
            {
                start_row = 0;
                end_row = 3; //exclusive 
            }
            else if (r <6)
            {
                start_row = 3;
                end_row = 6; 
            }
            else if (r < 9)
            {
                start_row = 6;
                end_row = 9;

            }
            if (c < 3) { 
                start_col = 0;
                end_col = 3; //exclusive 

            }
            else if ( c < 6)
            {
                start_col = 3;  
                end_col = 6;
                
            }
            else if(c < 9)
            {
                start_col = 6;
                end_col= 9;
            }

            for (int i=start_row; i<end_row; i++) 
            { 
                for (int k = start_col; k<end_col; k++)
                {
                    this.grid[i][k].ReduceEntropy(this.grid[r][c].value);
                    this.grid[i][k].color = Color.Green;
                }
            }

            for (int i =0;i<this.grid.Count;i++)
            {
                this.grid[r][i].ReduceEntropy(this.grid[r][c].value);
                this.grid[r][i].color = Color.Green;
                this.grid[i][c].ReduceEntropy(this.grid[r][c].value);
                this.grid[i][c].color = Color.Green;


            }



        }




    }

}