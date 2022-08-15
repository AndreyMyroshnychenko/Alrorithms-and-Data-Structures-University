using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПА_Лаб._1
{
    public sealed class Node
	{
	   public int[,] State { get; set; } 
       public Node parentNode { get; set; } 
       public List<Node> children = new List<Node>();
	
	   public int Depth { get; set; } 

        public Node(int[,] State, Node parentNode, int Depth)
	    {
	        this.State = State;
            this.parentNode = parentNode;
            this.Depth = Depth;
        }

        public Node()
        {

        }
    }



}
