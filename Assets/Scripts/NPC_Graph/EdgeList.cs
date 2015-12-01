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
    /// Maximum size of the edge list
    /// </summary>
    private int maxSize;


    /// <summary>
    /// Creates a new empty Edge List with a max size and can be either directed or undirected
    /// </summary>
    /// <param name="maxSize">Maximum number of nodes in graph</param>
    /// <param name="undirected">Is the graph undirected</param>
    public EdgeList(int MaxSize,bool undirected) {
        adjList = new Edge<T>[MaxSize];
        this.undirected = undirected;
        maxSize = MaxSize;
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
        setWeight(first, second, weight);

        return temp;
    }

    /// <summary>
    /// Finds and returns edge from first to second
    /// </summary>
    /// <param name="first">index of first node</param>
    /// <param name="second">index of second node</param>
    /// <returns>null if not found, returns edge if found</returns>
    public Edge<T> find(int first,int second) {
        if (first < 0 || first >= maxSize || second < 0 || second >= maxSize)
            throw new System.Exception("First is out of bounds");
        Edge<T> cur = adjList[first];
        while (cur != null && cur.getSecond() != second) {
            cur = cur.getNext();
        }
        return cur;
    }
    /// <summary>
    /// Finds first edge from index node to another with same weight
    /// </summary>
    /// <param name="index">Node from which to find weight out</param>
    /// <param name="weight">Weight to be found</param>
    /// <returns></returns>
    public Edge<T> findWeight(int index, int weight) {
        Edge<T> cur = adjList[index];
        while(cur != null && cur.getWeight() != weight) {
            cur = cur.getNext();
        }
        return cur;
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <param name="weight"></param>
    public void setWeight(int first, int second, int weight) {
        Edge<T> temp = find(first, second);
        if (temp == null) throw new System.Exception("No edge from " + first + " to " + second);
        temp.setWeight(weight);

        if (this.undirected) {
            temp = find(second, first);
            temp.setWeight(weight);
        }
    }



    /// <summary>
    /// Gets the weight of the edge from first to second
    /// </summary>
    /// <param name="first">Index of first node</param>
    /// <param name="second">Index of second node</param>
    /// <returns>Weight of edge from first to second</returns>
    public int getWeight(int first, int second) {
        return find(first, second).getWeight();
    }



    /// <summary>
    /// Does each node connect to every other, ignoring itself
    /// </summary>
    /// <returns></returns>
    public bool isFull() {
        for (int i = 0; i < maxSize; i++) {
            for (int j = 0; j < maxSize; i++) {
                if (i != j && find(i, j) == null) {
                    return false;
                }
            }
        }
        return true;
    }
}
