using UnityEngine;
using System.Collections;

public class Edge<T> {
    int first;
    int second;

    Edge<T> next;

    T data;
    int relationship;


    //Weighted graph
    //directed or undirected TBD


    //DECLARATIONS
    /// <summary>
    /// Declare edge with only nodes
    /// </summary>
    /// <param name="firstNode"></param>
    /// <param name="otherNode"></param>
    public Edge(int firstNode, int otherNode) {
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
    public Edge(int firstNode, int otherNode,int relations) {
        first = firstNode;
        second = otherNode;
        next = null;
        relationship = relations;
    }


    /// <summary>
    /// Pointer to next
    /// </summary>
    /// <returns></returns>
    public Edge<T> getNext() {
        return next;
    }

    /// <summary>
    /// Sets next pointer to user input 'next'
    /// </summary>
    /// <param name="next"></param>
    public void setNext(Edge<T> next) {
        this.next = next;
    }

    /// <summary>
    /// First node index
    /// </summary>
    /// <returns></returns>
    public int getFirst() {
        return first;
    }

    /// <summary>
    /// Second node index
    /// </summary>
    /// <returns></returns>
    public int getSecond() {
        return second;
    }




    public int getWeight() {
        return relationship;
    }

    public void setWeight(int weight) {
        relationship = weight;
    }



    public T getData() {
        return data;
    }


    public void setData(T Data) {
        data = Data;
    }
}
