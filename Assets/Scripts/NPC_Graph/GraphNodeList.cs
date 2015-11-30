using UnityEngine;
using System.Collections;

public class GraphNodeList<T> {
    private GraphNode<T>[] nodeArr;
    private int size;
    private int maxSize;

    /// <summary>
    /// Creates a new, empty Graph Node list
    /// </summary>
    public GraphNodeList(int maxSize) {
        nodeArr = new GraphNode<T>[maxSize];
        size = 0;
        this.maxSize = maxSize;
    }

    int getSize() {
        return size;
    }

    public void addItem(T newItem) {
        if (size > maxSize) throw new System.Exception("Major error encountered. Matrix size larger than possible.");
        if (size == maxSize) throw new System.Exception("Can't insert, matrix is full");
        


        if (getItem(newItem.ToString())!=null)
            throw new System.Exception("Object already exists");


        nodeArr[getSize()] = new GraphNode<T>(getSize(), newItem);

        size++;
    }


    public GraphNode<T> getItem(int index) {
        if (index < 0 || index >= getSize())
            throw new System.Exception("Index out of bounds.");
        return nodeArr[index];
    }
    /// <summary>
    /// Returns the node of string name
    /// Returns null if not found
    /// </summary>
    /// <param name="name">Name of node</param>
    /// <returns></returns>
    public GraphNode<T> getItem(string name) {
        for(int i=0;i< size; i++) {
            if (nodeArr[i].getData().ToString().Equals(name)) {
                return nodeArr[i];
            }
        }
        return null;
    }
}
