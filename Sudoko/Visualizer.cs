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
                    g.DrawRectangle(Pens.White, cells[i][k].dimensions);
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
