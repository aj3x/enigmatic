using UnityEngine;
using System.Collections;

public class Edge<T> : MonoBehaviour {
    int first;
    int second;

    Edge<T> next;

    int relationship;


    //Weighted graph
    //directed or undirected TBD


    //DECLARATIONS
    /// <summary>
    /// Declare edge with only nodes
    /// </summary>
    /// <param name="firstNode"></param>
    /// <param name="otherNode"></param>
    Edge(int firstNode, int otherNode) {
        first = firstNode;
        second = otherNode;
        next = null;
    }

    /// <summary>
    /// Declare edge with weight
    /// </summary>
    /// <param name="firstNode"></param>
    /// <param name="otherNode"></param>
    /// <param name="relations"></param>
    Edge(int firstNode, int otherNode,int relations) {
        first = firstNode;
        second = otherNode;
        next = null;
        relationship = relations;
    }



    public Edge<T> getNext() {
        return next;
    }


    public void setNext(Edge<T> next) {
        this.next = next;
    }

    public int getFirst() {
        return first;
    }

    public int getSecond() {
        return second;
    }
}
