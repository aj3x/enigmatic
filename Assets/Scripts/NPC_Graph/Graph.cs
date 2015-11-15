using UnityEngine;
using System.Collections;

public class Graph<T> : MonoBehaviour {
    private int size;
    GraphNodeList<T> nodes;
    EdgeList<T> edges;


    public Graph(bool undirected) {
        size = 0;
    }


    public void addItem(T temp) {
        nodes.addItem(temp);
    }

    public void addEdge(int firstNode, int secondNode) {
        //throw exception if negative
        if (firstNode < 0 || secondNode < 0) throw new System.Exception("A node can't be less than zero");
        
        //check to see if the nodes exist in the list
        if(firstNode<size && secondNode < size) {
            edges.addEdge(firstNode, secondNode);//add edge to list
        } else
            throw new System.Exception("Node is out of bounds");
    }
    public void addEdge(int firstNode, int secondNode, int weight) {
        if (firstNode < size && secondNode < size) {

        } else
            throw new System.Exception("Node is out of bounds");
    }





    
    
    public int getSize() {
        return size;
    }
}
