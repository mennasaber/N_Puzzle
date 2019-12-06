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
        private List<Vertex<int>> graph = new List<Vertex<int>>();
        bool solvable;
        public playForm(int[,] matrix)
        {
            InitializeComponent();
            load_initial_matix(matrix);
            solvable = checkSolvable(matrix);
            if (solvable)
            {
                convertToGraph(matrix);
                List<Vertex<int>> path =  getShortestPath(graph);
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
            //TODO: check if this matrix has solution or not
            return true;
        }

        private void convertToGraph(int[,] matrix)
        {
            //TODO: generate all possible states from this matrix and repeat this step for every state
        }

        private List<Vertex<int>> getShortestPath(List<Vertex<int>> graph)
        {
            List<Vertex<int>> path = new List<Vertex<int>>();
            //TODO: get shortest path , solve it by A* algorithm
            return path;
        }

        private void playForm_Load(object sender, EventArgs e)
        {

        }

        private void load_solution(List<Vertex<int>> path)
        {
            //TODO : load solution to GUI
        }
    }
}
