﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Puzzle.Models;
using System.Collections;
namespace N_Puzzle
{
    class priorityQueue
    {
        private ArrayList Queue =new ArrayList();
        
        public int lenght()
        {
            return Queue.Count;
        }
        public priorityQueue()
        {
            
        }
        public void Enqueue(Vertex Key)
        {
            Queue.Add(Key);
            int index = Queue.Count- 1;
            if (index > 0)
            {
                int parent = (index - 1) / 2;
                while (index>0&&((Vertex)Queue[index]).Cost< ((Vertex)Queue[parent]).Cost)
                {
                   Vertex temp = (Vertex)Queue[index];
                    Queue[index] = Queue[parent];
                    Queue[parent] = temp;
                    index = parent;
                    parent = (index - 1) / 2;
                }
            }
        }
        public Vertex Dequeue()
        {
            Vertex value =(Vertex) Queue[0];
            Queue[0] = Queue[Queue.Count - 1];
            Queue.RemoveAt(Queue.Count - 1);
            minHeapify(0);
            return value;
        }
        public void minHeapify(int i)
        {
            int L = 2 * i + 1;
            int R = 2 * i + 2;
            int Smallest=i;
            if (L < Queue.Count &&((Vertex) Queue[L]).Cost < ((Vertex)Queue[i]).Cost)
            {
                Smallest = L;
            }

            if (R < Queue.Count &&((Vertex) Queue[R]).Cost <((Vertex)Queue[Smallest]).Cost)
            {
                Smallest = R;
            }
            if (Smallest != i)
            {
                Vertex temp =(Vertex) Queue[i];
                Queue[i] = Queue[Smallest];
                Queue[Smallest] = temp;
                minHeapify(Smallest);
            }
        } 
    }
}
