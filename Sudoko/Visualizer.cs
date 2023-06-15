namespace Sudoko
{
    public class Visualizer
    {
        public void Draw(Graphics g, Bitmap offset, List<List<Cell>> cells)

        {

            Graphics g2 = Graphics.FromImage(offset);
            DrawScene(g2, cells);
            g.DrawImage(offset, 0, 0);
        }
        public void DrawScene(Graphics g, List<List<Cell>> cells)
        {
            g.Clear(Color.Black);
         
            for (int i = 0; i < cells.Count; i++)
            {
                for (int k = 0; k < cells[i].Count; k++)
                {
                    if ( false) //testing something
                    {
                        g.DrawRectangle(Pens.Red, cells[i][k].dimensions);

                    }
                    else { 
                      g.DrawRectangle(new Pen(cells[i][k].color), cells[i][k].dimensions);

                    }
                    if (cells[i][k].value == -1) { continue; }
                    PointF point = CalcMidPoint(cells[i][k].dimensions);
                    // Set the font and brush for drawing the value
                    Font font = new Font("Arial", 12);
                    Brush brush = Brushes.White;

                    // Draw the value at the calculated midpoint
                    g.DrawString(cells[i][k].value.ToString(), font, brush, point);
                }
            }
        }

        public PointF CalcMidPoint(Rectangle rect)
        {
            return new PointF((float)(rect.X + rect.X + rect.Width)/2 , (float)(rect.Y + rect.Y + rect.Height) / 2);
        }
    }
}
