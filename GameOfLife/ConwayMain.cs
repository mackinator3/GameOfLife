using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace GameOfLife
{
    public partial class ConwayMain : Form
    {
        Grid CellGrid;
        bool InProgress = false;

        public ConwayMain()
        {
            InitializeComponent();
        }

        private void ConWayMain_Load(object sender, EventArgs e)
        {
            CreateGridSurface(true);
            //activeCount();
            //activeCount2();
        }

        private void CreateGridSurface(bool RandomCells)
        {
            Point locPoint;
            Random random = new Random();
            Cell newCell;

            int rows = (int)(pbGrid.Height / numsSize.Value);
            int cols = (int)(pbGrid.Width / numsSize.Value);

            CellGrid = new Grid(rows, cols);

            Grid.gridCells.Clear();

            {

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        locPoint = new Point((int)(j * numsSize.Value), (int)(i * numsSize.Value));
                        newCell = new Cell(locPoint, j, i);

                        if (RandomCells)
                        {
                            newCell.isAlive = ((random.Next(100) < 15) ? true : false);
                        }
                        else
                        {
                            newCell.isAlive = false;
                        }
                        Grid.gridCells.Add(newCell);
                    }
                }

                Grid.gridCells = Grid.gridCells.OrderBy(c => c.xPos).OrderBy(c => c.yPos).ToList();
                UpdateGrid(CellGrid);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            CreateGridSurface(true);
            //activeCount();
            //activeCount2();
        }

        public void UpdateGrid(Grid GridDisplay)
        {
            Random random = new Random();

            using (Bitmap bmp = new Bitmap(pbGrid.Width, pbGrid.Height))
            using (Graphics g = Graphics.FromImage(bmp))
            using (SolidBrush cellBrush = new SolidBrush(Color.DarkOrange))
            {
                g.Clear(Color.Black);

                foreach (Cell cell in Grid.gridCells)
                {
                    if (cell.isAlive)
                    {
                        g.FillRectangle(cellBrush, new Rectangle(cell.Location,
                            new Size((int)numsSize.Value, (int)numsSize.Value)));
                    }
                }
                if (pbGrid.Image != null)
                {
                    pbGrid.Image.Dispose();
                }
                pbGrid.Image = (Bitmap)bmp.Clone();
            }
        }

        private void advanceButton_Click(object sender, EventArgs e)
        {
            NextState();
            //activeCount();
            //activeCount2();
        }

        private void NextState()
        {
            //Method to calculate next positions of cells and update the grid.
            /*
            1.Any live cell with fewer than two live neighbours dies, 
            as if by underpopulation.
            2.Any live cell with two or three live neighbours lives on 
            to the next generation.
            3.Any live cell with more than three live neighbours dies, 
            as if by overpopulation.
            4. Any dead cell with exactly three live neighbours becomes a live cell, 
            as if by reproduction.
            */

            foreach (Cell cell in Grid.gridCells)
            {
                int adjacentAlive = CellGrid.AliveCheck(cell);

                if (cell.isAlive)
                {
                    if (adjacentAlive < 2 || adjacentAlive > 3)
                    {
                        cell.NextStatus = false;
                    }
                    else
                    {
                        cell.NextStatus = true;
                    }
                }
                else
                {
                    if (adjacentAlive == 3)
                    {
                        cell.NextStatus = true;
                    }
                }
            }

            foreach (Cell cell in Grid.gridCells)
            {
                cell.isAlive = cell.NextStatus;
            }

            // Update the grid display
            UpdateGrid(CellGrid);
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            Go();
        }
        private void Go()
        {
            InProgress = !InProgress;
            goButton.Text = InProgress ? "Stop" : "Go";

            while (InProgress)
            {
                NextState();
                Application.DoEvents();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeCount();
        }

        public void activeCount()
        {
            comboBox1.Items.Clear();
            foreach (Cell cell in Grid.gridCells)
            {
                comboBox1.Items.Add($"X: {cell.xPos}, Y: {cell.yPos}, Count: {CellGrid.AliveCheck(cell)}");
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeCount2();
        }

        public void activeCount2()
        {
            comboBox2.Items.Clear();
            foreach (Cell cell in Grid.gridCells)
            {
                comboBox2.Items.Add($"X: {cell.xPos}, Y: {cell.yPos}, Count: {CellGrid.AliveCheck(cell)}");
            }
        }

        private void ConwayMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            InProgress = false;
            Application.Exit();
        }
    }

    public class Cell
    {
        private Point cLocation;
        private Boolean cIsAlive;
        private int cXPos;
        private int cYPos;
        private bool cNext;

        public Cell(Point location, int x, int y)
        {
            this.Location = location;
            this.xPos = x;
            this.yPos = y;
        }

        public Point Location
        {
            get { return cLocation; }
            set { cLocation = value; }
        }

        public int xPos
        {
            get { return cXPos; }
            set { cXPos = value; }
        }

        public int yPos
        {
            get { return cYPos; }
            set { cYPos = value; }
        }
        public Boolean isAlive
        {
            get { return cIsAlive; }
            set { cIsAlive = value; }
        }
        public bool NextStatus
        {
            get { return cNext; }
            set { cNext = value; }
        }

        public override string ToString()
        {
            return $"GridX: {this.xPos} GridY:{this.yPos} LocX: {this.Location.X} LocY: {this.Location.Y}";
        }
    }

    public class Grid
    {
        public static List<Cell> gridCells = new List<Cell>();

        private int cRows;
        private int cCols;

        public Grid(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
        }

        public int Rows
        {
            get { return cRows; }
            set { cRows = value; }
        }
        public int Cols
        {
            get { return cCols; }
            set { cCols = value; }
        }

        public int AliveCheck(Cell cellCheck)
        {
            int liveAdjacent = 0;

            int cellIndex = (cellCheck.yPos * Cols) + cellCheck.xPos;
            int startIndex = cellIndex - Cols - 2;
            int endIndex = cellIndex + Cols + 2;

            startIndex = (startIndex < 0) ? 0 : startIndex;
            endIndex = (endIndex > (gridCells.Count - 1)) ? gridCells.Count - 1 : endIndex;

            for (int x = startIndex; x < endIndex; x++)
            {
                if ((Math.Abs(cellCheck.xPos - gridCells[x].xPos) < 2) && Math.Abs(cellCheck.yPos - gridCells[x].yPos) < 2)
                {
                    if (gridCells[x].Location != cellCheck.Location)
                    {
                            if (gridCells[x].isAlive)
                            {
                                liveAdjacent++;
                            }
                    }
                }
            }
            //Original game loop. 
            //foreach (Cell cell in Grid.gridCells)
            //{
            //    if ((Math.Abs(cell.xPos - cellCheck.xPos) < 2) && Math.Abs(cell.yPos - cellCheck.yPos) < 2)
            //    {
            //        if (cell.Location != cellCheck.Location)
            //        {
            //            if (cell.isAlive)
            //            {
            //            liveAdjacent++;
            //            }
            //        }
            //    }
            //}
            return liveAdjacent;
        }
    }
}
