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

    
    public Edge<TE> addEdge(int firstNode, int secondNode, int weight) {
        //throw exception if negative
        if (firstNode < 0 || secondNode < 0) throw new System.Exception("A node can't be less than zero");
        
        //check to see if the nodes exist in the list
        if(firstNode<size && secondNode < size) {
            return edges.addEdge(firstNode, secondNode, weight);//add edge to list
            
        } else
            throw new System.Exception("Node is out of bounds");
    }

    





    
    
    public int getSize() {
        return size;
    }

    public int getIndex(string name) {
        return nodes.getItem(name).getIndex();
    }

    public string getName(int index) {
        return nodes.getItem(index).getData().ToString();
    }



    public GraphNode<TN> findNode(int index) {
        return nodes.getItem(index);
    }


    public Edge<TE> findEdge(int first,int second) {
        return edges.find(first, second);
    }
}
