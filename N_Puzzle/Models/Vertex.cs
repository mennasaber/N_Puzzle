using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle.Models
{
    class Vertex<T>
    {
        // T can be int or any data type
        private T[][] matrix;
        private int manhattan;
        private int hamming;
        private int distance;
        private Vertex<T> parent;      
        private LinkedList<Vertex<T>> adjacent;

        public Vertex(T[][] matrix)
        {
            this.matrix = matrix;
            this.adjacent = new LinkedList<Vertex<T>>();
        }

        public T[][] Matrix
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

        public Vertex<T> Parent
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

        public LinkedList<Vertex<T>> Adjacent
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


        /// <summary>
        /// Take vertex from main and add it to adjacent linked list
        /// </summary>
        /// <param name="adj"></param>
        public void addAdjacent(Vertex<T> adj)
        {
            Adjacent.AddLast(adj);
        }
        public void calculateHamming() {
            //TODO: calculate hamming for this matrix 
        }
        public void calculateManhattan() {
            //TODO: calculate manhattan for this matrix
        }

    }
}
