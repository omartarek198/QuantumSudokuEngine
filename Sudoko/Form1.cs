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
            T.Start();
        }

        public void Form1_Load(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            offset = new Bitmap(this.Width, this.Height);
            visualizer = new Visualizer();
            this.grid = SeedBoard(MakeBoard(),9);

        }
        List<List<Cell>> MakeBoard()
        {
            List<List<Cell>> board = new List<List<Cell>>();
            for (int i = 0; i < 9; i++)
            {

                board.Add(new List<Cell>());
                for (int k = 0; k < 9; k++)
                {
                    Cell cell = new Cell(new Rectangle(75 * k + 700, 75 * i+300, 75, 75));
                    board[i].Add(cell);
                }
            }
            return board;
        }
        int Choice(List<int> list)

        {
            // implementation of the Choice function in python
            Random random = new Random();
            return list[random.Next(list.Count)];

        }
        List<List<Cell>> SeedBoard(List<List<Cell>> board, int ct)
        {
            // input : the board to be seeded and the number of seeds 
            // output : seeded board


            Random random = new Random();
            List<int> list_of_numbers = new List<int>();
            for (int i=0;i<9;i++)
            {
                list_of_numbers.Add(i + 1);
            }
            int r, c;
            for (int i=0;i<ct;i++)
            {
                r = random.Next(board.Count);
                c = random.Next(board.Count);
                board[r][c].value = Choice(list_of_numbers);
                list_of_numbers.Remove(board[r][c].value);

            }
            return board;
        }


    }
}