using UnityEngine;
using System.Collections;

public class EdgeList<T> : MonoBehaviour {
    /// <summary>
    /// Is the graph undirected
    /// </summary>
    private bool undirected;
    /// <summary>
    /// Array list: Matrix points to each edge from index to node
    /// </summary>
    Edge<T>[] adjList;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="maxSize">Maximum number of nodes in graph</param>
    /// <param name="undirected">Is the graph undirected</param>
    EdgeList(int maxSize,bool undirected) {
        adjList = new Edge<T>[maxSize];
        this.undirected = undirected;
    }



    public void addEdge(int first, int second) {
        Edge<T> cur = new Edge<T>(first, second);
        if (find(first, second) == null) {
            cur.setNext(adjList[first]);
            adjList[first] = cur;

            if (undirected) {
                addEdge(second, first);
            }

        } else//throw exception if edge already exists
            throw new System.Exception("Edge already exists.");
        
    }

    /// <summary>
    /// Finds and returns edge from first to second
    /// </summary>
    /// <param name="first">index of first node</param>
    /// <param name="second">index of second node</param>
    /// <returns>null if not found, returns edge if found</returns>
    public Edge<T> find(int first,int second) {
        Edge<T> cur = adjList[first];
        while (cur != null || cur.getSecond() != second) {
            cur = cur.getNext();
        }
        return cur;
    }

    void inversePoint(Edge<T> pointer) {
        
    }
}
