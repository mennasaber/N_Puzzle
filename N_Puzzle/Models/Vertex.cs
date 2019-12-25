using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle.Models
{
    class Vertex
    {
        private int[,] matrix;
        private int manhattan;
        private int hamming;
        private int distance;
        private Vertex parent;
        private LinkedList<Vertex> adjacent;
        private String direction;
        private int zeroIndex_i;
        private int zeroIndex_j;
        private int cost;


        public Vertex()
        {

        }
        public Vertex(int[,] matrix)
        {
            this.matrix = matrix;
            this.adjacent = new LinkedList<Vertex>();
        }

        public int[,] Matrix
        {
            get
            {
                return matrix;
            }

            set
            {
                matrix = value;
            }
        }

        public int Manhattan
        {
            get
            {
                return manhattan;
            }

            set
            {
                manhattan = value;
            }
        }

        public int Hamming
        {
            get
            {
                return hamming;
            }

            set
            {
                hamming = value;
            }
        }

        public Vertex Parent
        {
            get
            {
                return parent;
            }

            set
            {
                parent = value;
            }
        }

        public LinkedList<Vertex> Adjacent
        {
            get
            {
                return adjacent;
            }

            set
            {
                adjacent = value;
            }
        }

        public int Distance
        {
            get
            {
                return distance;
            }

            set
            {
                distance = value;
            }
        }


        public int ZeroIndex_i
        {
            get
            {
                return zeroIndex_i;
            }

            set
            {
                zeroIndex_i = value;
            }
        }
        public int ZeroIndex_j
        {
            get
            {
                return zeroIndex_j;
            }

            set
            {
                zeroIndex_j = value;
            }
        }

        public string Direction
        {
            get
            {
                return direction;
            }

            set
            {
                direction = value;
            }
        }

        public int Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
            }
        }



        /// <summary>
        /// Take vertex from main and add it to adjacent linked list
        /// </summary>
        /// <param name="adj"></param>
        public void addAdjacent(Vertex adj)
        {
          //  Adjacent.AddLast(adj);
        }
        public void calculateHamming()
        {
            //TODO: calculate hamming for this matrix
            for (int i = 0; i < Math.Sqrt(Matrix.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(Matrix.Length); j++)
                {
                    int size = Convert.ToInt32(Math.Sqrt(Matrix.Length));
                    if (j == size - 1)
                    {
                        if (matrix[i, j] != (i + 1) * size && matrix[i, j] != 0)
                        {
                            Hamming += 1;
                        }
                    }
                    else if ((matrix[i, j] / size != i || matrix[i, j] % size - 1 != j) && matrix[i, j] != 0)
                    {
                        Hamming += 1;
                    }
                    if (matrix[i, j] == 0)
                    {
                        ZeroIndex_i = i;
                        ZeroIndex_j = j;
                    }
                }
            }
        }
        public void calculateManhattan()
        {
            //TODO: calculate manhattan for this matrix
        }

    }
}
