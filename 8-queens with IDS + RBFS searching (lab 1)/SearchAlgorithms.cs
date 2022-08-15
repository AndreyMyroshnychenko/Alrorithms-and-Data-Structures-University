using System.Collections.Generic;
using Priority_Queue;
namespace ПА_Лаб._1
{
    static class SearchAlgorithms
    {
        private static List<Node> Expand(Node nodeToExpand)
        {
            List<Node> successors = new List<Node>();
            List<int[,]> newStates = Board.getNewStates(nodeToExpand.State);

            int count = 0;
            foreach (var item in newStates)
            {
                Node newNode = new Node(newStates[count], nodeToExpand, nodeToExpand.Depth + 1);

                successors.Add(newNode);
                count++;
            }

            return successors;
        }

        //1st part uninformative search
        public static Node DepthLimitedSearch(Node node, int limit)
        {
            Stack<Node> fringe = new Stack<Node>();
            fringe.Push(node);

            while (true)
            {
                TaskCounters.iterationsCounterIDS++;

                if (fringe.Count == 0)
                {
                    return null; //failure (cutoff)
                }

                var currentNode = fringe.Pop();

                if (Problem.isAGoal(currentNode.State))
                {
                    return currentNode;
                }

                // Expand node and insert all the successors
                if (currentNode.Depth < limit)
                {
                    // insert into the fringe Expand(currentNode)
                    var successors = Expand(currentNode);

                    foreach (var successor in successors)
                    {
                        fringe.Push(successor);
                        TaskCounters.generatedStatesCounterIDS++;
                    }
                }
            }
        }

        public static Node IterativeDeepeningSearch(Node node)
        {
            int depth = 0;
            Node result = new Node();

            while (depth<10)
            {
                result = DepthLimitedSearch(node, depth);
                depth++;

                if (result != null)
                {
                    return result;
                }
            }
            return result;
        }

        //2nd part informative search
        //f_limit - evaluation limit function 
        public static Node RecursiveBestFirstSearch(Node node, int f_limit)
        {
            SimplePriorityQueue<Node> priorqueue = new SimplePriorityQueue<Node>();

            if (Problem.isAGoal(node.State))
            {
                return node;
            }

            node.children = Expand(node); //successors

            //if succesors are empty
            if (node.children == null)
            {
                return null; //failure 
            }

            foreach (var successor in node.children)
            {
                TaskCounters.generatedStatesCounterRBFS++;

                int f_n = successor.Depth + Problem.conflictsCount(successor.State); // g(n) + h(n)
                priorqueue.Enqueue(successor, f_n);
            }

            while (true)
            {
                TaskCounters.iterationsCounterRBFS++;

                var best = priorqueue.Dequeue();

                //return failure and reject the way
                if (best.Depth + Problem.conflictsCount(best.State) > f_limit)
                {
                    return null;
                }
                else
                {
                    var alternative = priorqueue.Dequeue();
                    var result = RecursiveBestFirstSearch(best, alternative.Depth + Problem.conflictsCount(alternative.State));

                    if (result != null)
                    {
                        return result;
                    }
                }
            }
        }

    }
}
