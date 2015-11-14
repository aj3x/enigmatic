using UnityEngine;
using System;
using System.Collections;

public class GraphNode<T> : MonoBehaviour,IComparable<GraphNode<T>> {

    private int index;
    private T data;
    private GraphNode<T> next;


    public GraphNode(int i, T item) {
        index = i;
        data = item;
    }


    public GraphNode<T> getNext() {
        return next;
    }

    public void setNext(GraphNode<T> temp) {
        next = temp;
    }

    public T getData() {
        return data;
    }

    public int getIndex() {
        return index;
    }
    /// <summary>
    /// Compares index of node to another
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>0 - if they are equal
    /// 1 if this is greater than obj
    /// -1 if this is less than obj</returns>
    public int CompareTo(GraphNode<T> obj) {
        if (obj == null) throw new NullReferenceException();
        if (this.index > obj.index) {
            return 1;
        }else if(this.index == obj.index) {
            return 0;
        }else{
            return -1;
        }
    }
}
