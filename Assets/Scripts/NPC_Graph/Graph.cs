using UnityEngine;
using System.Collections;

public class Graph<T> : MonoBehaviour {
    private int size;
    GraphNodeList<T> nodes;
    EdgeList<T> edges;


    public Graph() {
        size = 0;
    }


    public void addItem(T temp) {
        nodes.addItem(temp);
    }

    public void addEdge(int firstNode, int secondNode) {
        if(firstNode<size && secondNode < size) {

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
