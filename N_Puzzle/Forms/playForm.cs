using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using N_Puzzle.UserControls;
using N_Puzzle.Models;

namespace N_Puzzle.Forms
{
    public partial class playForm : MetroFramework.Forms.MetroForm
    {
        priorityQueue priorityQueue = new priorityQueue();
        private List<Vertex> graph = new List<Vertex>();
        bool solvable;
        Queue<Vertex> Q = new Queue<Vertex>();
      
        public playForm(int[,] matrix)
        {
            InitializeComponent();
            load_initial_matix(matrix);
            solvable = checkSolvable(matrix);
            if (solvable)
            {
                Vertex v = new Vertex(matrix);
                v.Distance = 0;
                //v.calculateManhattan();
                v.Direction = "";
                
                BFS(v);
                //graph.Add(v);
                //priorityQueue.Enqueue(v);
                //convertToGraph();
                List<Vertex> path = getShortestPath(graph);
                load_solution(path);
            }
        }
        private void load_initial_matix(int[,] matrix)
        {
            panel1.Controls.Clear();
            containerUserControl container = new containerUserControl();
            container.addMatrix(matrix, 1);
            panel1.Controls.Add(container);
        }

        private bool checkSolvable(int[,] matrix)
        {
            int[] arr = new int[matrix.Length];
            int parity = 0;
            int gridWidth = Convert.ToInt32(Math.Sqrt(arr.Length)); //Size of matrix
            int row = 0; // the current row we are on
            int blankRow = 0; // the row with the blank tile
            int k = 0; //array index

            //Convert 2D array to 1D array        
            for (int i = 0; i < Math.Sqrt(matrix.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(matrix.Length); j++)
                {
                    arr[k] = matrix[i, j];
                    k++;
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (i % gridWidth == 0)
                {
                    // advance to next row 
                    row++;
                }
                if (arr[i] == 0)
                {
                    // the blank tile 
                    blankRow = row; // save the row on which encountered 
                    continue;
                }
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j] && arr[j] != 0)
                        parity++;
                }
            }
            if (gridWidth % 2 == 0)
            {
                // even grid
                if (blankRow % 2 == 0)
                {
                    // blank on odd row; counting from bottom 
                    return parity % 2 == 0;
                }
                else
                {
                    // blank on even row; counting from bottom
                    return parity % 2 != 0;
                }
            }
            else
            {
                // odd grid 
                return parity % 2 == 0;
            }


        }

        private void convertToGraph()
        {
            Vertex temp = new Vertex();
            temp = priorityQueue.Dequeue();
            int size = Convert.ToInt32(Math.Sqrt(temp.Matrix.Length));
            while (true)
            {
                if (temp.Manhattan == 0)
                {
                    MessageBox.Show(temp.Distance.ToString());
                    break;
                }
                if (temp.ZeroIndex_i + 1 < size && temp.Direction != "U")
                {
                    int[,] nMatrix = new int[size, size];
                    Array.Copy(temp.Matrix, nMatrix, temp.Matrix.Length);
                    nMatrix[temp.ZeroIndex_i, temp.ZeroIndex_j] = temp.Matrix[temp.ZeroIndex_i + 1, temp.ZeroIndex_j];
                    nMatrix[temp.ZeroIndex_i + 1, temp.ZeroIndex_j] = 0;
                    Vertex u = new Vertex(nMatrix);
                    u.calculateManhattan();
                    u.Distance = temp.Distance + 1;

                    u.Cost = u.Distance + u.Manhattan;
                    u.Parent = temp;
                    u.Direction = "D";
                    priorityQueue.Enqueue(u);
                    temp.addAdjacent(u);
                }
                if (temp.ZeroIndex_i - 1 > -1 && temp.Direction != "D")
                {
                    int[,] nMatrix = new int[size, size];
                    Array.Copy(temp.Matrix, nMatrix, temp.Matrix.Length);
                    nMatrix[temp.ZeroIndex_i, temp.ZeroIndex_j] = temp.Matrix[temp.ZeroIndex_i - 1, temp.ZeroIndex_j];
                    nMatrix[temp.ZeroIndex_i - 1, temp.ZeroIndex_j] = 0;
                    Vertex u = new Vertex(nMatrix);
                    u.calculateManhattan();
                    u.Distance = temp.Distance + 1;
                    u.Cost = u.Distance + u.Manhattan;
                    u.Parent = temp;
                    u.Direction = "U";
                    priorityQueue.Enqueue(u);
                    temp.addAdjacent(u);
                }

                if (temp.ZeroIndex_j + 1 < size && temp.Direction != "L")
                {
                    int[,] nMatrix = new int[size, size];
                    Array.Copy(temp.Matrix, nMatrix, temp.Matrix.Length);
                    nMatrix[temp.ZeroIndex_i, temp.ZeroIndex_j] = temp.Matrix[temp.ZeroIndex_i, temp.ZeroIndex_j + 1];
                    nMatrix[temp.ZeroIndex_i, temp.ZeroIndex_j + 1] = 0;
                    Vertex u = new Vertex(nMatrix);
                    u.calculateManhattan();
                    u.Distance = temp.Distance + 1;
                    u.Cost = u.Distance + u.Manhattan;
                    u.Parent = temp;
                    u.Direction = "R";
                    priorityQueue.Enqueue(u);
                    temp.addAdjacent(u);
                }

                if (temp.ZeroIndex_j - 1 > -1 && temp.Direction != "R")
                {
                    int[,] nMatrix = new int[size, size];
                    Array.Copy(temp.Matrix, nMatrix, temp.Matrix.Length);
                    nMatrix[temp.ZeroIndex_i, temp.ZeroIndex_j] = temp.Matrix[temp.ZeroIndex_i, temp.ZeroIndex_j - 1];
                    nMatrix[temp.ZeroIndex_i, temp.ZeroIndex_j - 1] = 0;
                    Vertex u = new Vertex(nMatrix);
                    u.calculateManhattan();
                    u.Distance = temp.Distance + 1;
                    u.Cost = u.Distance + u.Manhattan;
                    u.Parent = temp;
                    u.Direction = "L";
                    priorityQueue.Enqueue(u);
                    temp.addAdjacent(u);
                }
                temp = priorityQueue.Dequeue();
                graph.Add(temp);
            }
        }

        private List<Vertex> getShortestPath(List<Vertex> graph)
        {
            Vertex last = graph[graph.Count - 1];
            Vertex temp= graph[graph.Count - 1]; 
            for (int i = 0; i <= temp.Distance; i++)
            {               
                MessageBox.Show(last.Distance.ToString());
                MessageBox.Show(last.Direction);
                Vertex parent = last.Parent;
                last = parent;
            }
            //TODO: Display path
            List<Vertex> path = new List<Vertex>();
            return path;
        }

        private void BFS(Vertex v)
        {
            Vertex temp = new Vertex();
            int size  = Convert.ToInt32(Math.Sqrt(v.Matrix.Length));
            Q.Enqueue(v);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (v.Matrix[i,j]==0)
                    {
                        v.ZeroIndex_i = i;
                        v.ZeroIndex_j = j;
                    }

                }
            }
            while (Q.Count>0)
            {
                temp = Q.Dequeue();
                if (temp.solved())
                {
                    graph.Add(temp);
                    break;
                }

                if (temp.ZeroIndex_i + 1 < size && temp.Direction != "U")
                {
                    int[,] nMatrix = new int[size, size];
                    Array.Copy(temp.Matrix, nMatrix, temp.Matrix.Length);
                    nMatrix[temp.ZeroIndex_i, temp.ZeroIndex_j] = temp.Matrix[temp.ZeroIndex_i + 1, temp.ZeroIndex_j];
                    nMatrix[temp.ZeroIndex_i + 1, temp.ZeroIndex_j] = 0;
                    Vertex u = new Vertex(nMatrix);
                    u.ZeroIndex_i=temp.ZeroIndex_i + 1 ;
                    u.ZeroIndex_j = temp.ZeroIndex_j;
                  //  u.calculateManhattan();
                    u.Distance = temp.Distance + 1;
                    u.Cost = u.Distance;
                    u.Parent = temp;
                    u.Direction = "D";
                    Q.Enqueue(u);
                  //  temp.addAdjacent(u);
                }
                if (temp.ZeroIndex_i - 1 > -1 && temp.Direction != "D")
                {
                    int[,] nMatrix = new int[size, size];
                    Array.Copy(temp.Matrix, nMatrix, temp.Matrix.Length);
                    nMatrix[temp.ZeroIndex_i, temp.ZeroIndex_j] = temp.Matrix[temp.ZeroIndex_i - 1, temp.ZeroIndex_j];
                    nMatrix[temp.ZeroIndex_i - 1, temp.ZeroIndex_j] = 0;
                    Vertex u = new Vertex(nMatrix);
                    u.ZeroIndex_i= temp.ZeroIndex_i - 1;
                    u.ZeroIndex_j = temp.ZeroIndex_j;
                    //   u.calculateManhattan();
                    u.Distance = temp.Distance + 1;
                    u.Cost = u.Distance;
                    u.Parent = temp;
                    u.Direction = "U";
                    Q.Enqueue(u);
              //      temp.addAdjacent(u);
                }

                if (temp.ZeroIndex_j + 1 < size && temp.Direction != "L")
                {
                    int[,] nMatrix = new int[size, size];
                    Array.Copy(temp.Matrix, nMatrix, temp.Matrix.Length);
                    nMatrix[temp.ZeroIndex_i, temp.ZeroIndex_j] = temp.Matrix[temp.ZeroIndex_i, temp.ZeroIndex_j + 1];
                    nMatrix[temp.ZeroIndex_i, temp.ZeroIndex_j + 1] = 0;
                    Vertex u = new Vertex(nMatrix);
                    u.ZeroIndex_j= temp.ZeroIndex_j + 1;
                    u.ZeroIndex_i = temp.ZeroIndex_i;
                    //  u.calculateManhattan();
                    u.Distance = temp.Distance + 1;
                    u.Cost = u.Distance;
                    u.Parent = temp;
                    u.Direction = "R";
                   Q.Enqueue(u);
                //    temp.addAdjacent(u);
                }

                if (temp.ZeroIndex_j - 1 > -1 && temp.Direction != "R")
                {
                    int[,] nMatrix = new int[size, size];
                    Array.Copy(temp.Matrix, nMatrix, temp.Matrix.Length);
                    nMatrix[temp.ZeroIndex_i, temp.ZeroIndex_j] = temp.Matrix[temp.ZeroIndex_i, temp.ZeroIndex_j - 1];
                    nMatrix[temp.ZeroIndex_i, temp.ZeroIndex_j - 1] = 0;
                    Vertex u = new Vertex(nMatrix);
                    u.ZeroIndex_j = temp.ZeroIndex_j - 1;
                    u.ZeroIndex_i = temp.ZeroIndex_i;
                    //   u.calculateManhattan();
                    u.Distance = temp.Distance + 1;
                    u.Cost = u.Distance ;
                    u.Parent = temp;
                    u.Direction = "L";
                    Q.Enqueue(u);
                  //  temp.addAdjacent(u);
                }



            }



        }
        private void playForm_Load(object sender, EventArgs e)
        {

        }

        private void load_solution(List<Vertex> path)
        {
            //TODO : load solution to GUI
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
