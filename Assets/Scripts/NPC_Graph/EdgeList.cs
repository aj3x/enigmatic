using UnityEngine;
using System.Collections;

public class EdgeList<T> : MonoBehaviour {

    Edge<T>[] adjList;



    EdgeList(int maxSize) {
        adjList = new Edge<T>[maxSize];
    }



    void addEdge(int first, int second) {
        Edge<T> cur = adjList[first];
        if (find(first, second) == null) {
            cur.setNext(adjList[first]);

        } else
            throw new System.Exception("Edge already exists.");
        
    }


    Edge<T> find(int first,int second) {
        Edge<T> cur = adjList[first];
        while (cur != null || cur.getSecond() != second) {
            cur = cur.getNext();
        }
        return cur;
    }
}
