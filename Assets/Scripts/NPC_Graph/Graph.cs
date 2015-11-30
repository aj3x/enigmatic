using UnityEngine;
using System.Collections;


/// <summary>
/// 
/// </summary>
/// <typeparam name="TN">Data type held in Nodes</typeparam>
/// <typeparam name="TE">Data type held in Edges</typeparam>
public class Graph<TN,TE> {
    private int size;
    private int maxSize;
    GraphNodeList<TN> nodes;
    EdgeList<TE> edges;


    public Graph(int MaxSize, bool undirected) {
        size = 0;
        this.maxSize = MaxSize;
        nodes = new GraphNodeList<TN>(MaxSize);
        edges = new EdgeList<TE>(MaxSize, undirected);
    }


    public void addItem(TN temp) {
        if (size < maxSize) { 
            nodes.addItem(temp);
            size++;
        } else
            throw new System.Exception("Cannot insert anymore items");
    }

    

    public Edge<TE> addEdge(string firstNode, string secondNode,int weight) {
        return addEdge(getIndex(firstNode), getIndex(secondNode), weight);
    }
    public Edge<TE> addEdge(int firstNode, int secondNode, int weight) {
        //throw exception if negative
        if (firstNode < 0 || secondNode < 0) throw new System.Exception("A node can't be less than zero: "+firstNode+" "+secondNode);
        
        //check to see if the nodes exist in the list
        if(firstNode<size && secondNode < size) {
            return edges.addEdge(firstNode, secondNode, weight);//add edge to list
            
        } else
            throw new System.Exception("Node is out of bounds");
    }

    





    
    /// <summary>
    /// Returns size of array
    /// </summary>
    /// <returns></returns>
    public int getSize() {
        return size;
    }
    /// <summary>
    /// Returns index of node with same name.
    /// Returns -1 if it doesn't exist.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public int getIndex(string name) {
        if (nodes.getItem(name) == null) 
            return -1;
        else
            return nodes.getItem(name).getIndex();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public string getName(int index) {
        try { return nodes.getItem(index).getData().ToString(); }
        catch (System.Exception) {
            return "";
        }
    }


    /// <summary>
    /// Gets the node at index.
    /// Doesn't handle out of bound index
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public GraphNode<TN> findNode(int index) {
        try {
            return nodes.getItem(index);
        }
        catch (System.Exception) {
            return null;
        }
    }
    /// <summary>
    /// Finds node with same name.
    /// returns null if doesn't exist
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GraphNode<TN> findNode(string name) {
        try { return nodes.getItem(name);}
        catch (System.Exception) {
            return null;
        }
    }


    /// <summary>
    /// Return the edge between first and second.
    /// If it doesn't exist or are out of bounds, returns null;
    /// </summary>
    /// <param name="first">name of first node</param>
    /// <param name="second">name of second node</param>
    /// <returns></returns>
    public Edge<TE> findEdge(string first, string second) {
        return findEdge(getIndex(first),getIndex(second));
    }
    /// <summary>
    /// Return the edge between first and second.
    /// If it doesn't exist or are out of bounds, returns null;
    /// </summary>
    /// <param name="first">index of first node</param>
    /// <param name="second">index of second node</param>
    /// <returns></returns>
    public Edge<TE> findEdge(int first,int second) {
        try { return edges.find(first, second); }
        catch (System.Exception) {
            return null;
        }
    }


    public GraphNode<TN> findNodeWeight(string name, int weight) {
        return this.findNode(findNodeWeight(findNode(name).getIndex(), weight));
    }
    public int findNodeWeight(int index, int weight) {
        return this.edges.findWeight(index, weight).getSecond();
    }
}
