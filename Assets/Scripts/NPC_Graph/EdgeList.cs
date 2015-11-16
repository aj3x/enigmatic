using UnityEngine;
using System.Collections;

public class EdgeList<T> {
    /// <summary>
    /// Is the graph undirected
    /// </summary>
    private bool undirected;
    /// <summary>
    /// Array list: Matrix points to each edge from index to node
    /// </summary>
    Edge<T>[] adjList;


    /// <summary>
    /// Creates a new empty Edge List with a max size and can be either directed or undirected
    /// </summary>
    /// <param name="maxSize">Maximum number of nodes in graph</param>
    /// <param name="undirected">Is the graph undirected</param>
    public EdgeList(int maxSize,bool undirected) {
        adjList = new Edge<T>[maxSize];
        this.undirected = undirected;
    }



    public Edge<T> addEdge(int first, int second) {
        Edge<T> cur = new Edge<T>(first, second);
        if (find(first, second) == null) {
            cur.setNext(adjList[first]);
            adjList[first] = cur;
            if (undirected) {//undirected add edge going other way
                cur = new Edge<T>(second, first);
                cur.setNext(adjList[second]);
                adjList[second] = cur;
                cur = find(first, second);
            }
            return cur;

        } else//throw exception if edge already exists
            throw new System.Exception("Edge already exists.");
        
    }

    public Edge<T> addEdge(int first, int second,int weight) {
        Edge<T> temp = addEdge(first, second);
        temp.setWeight(weight);
        setWeight(second, first, weight);
        return temp;
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



    public void setWeight(int first, int second, int weight) {
        Edge<T> temp = find(first, second);
        if (temp == null) throw new System.Exception("No edge from " + first + " to " + second);
        temp.setWeight(weight);

        if (this.undirected) {
            temp = find(second, first);
            temp.setWeight(weight);
        }
    }

    void inversePoint(Edge<T> pointer) {
        
    }
}
