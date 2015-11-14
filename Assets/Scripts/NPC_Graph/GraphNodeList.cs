using UnityEngine;
using System.Collections;

public class GraphNodeList<T> : MonoBehaviour {
    private GraphNode<T> first;
    private GraphNode<T> last;
    private int size;


    GraphNodeList() {
        first = null;
        last = null;
        size = 0;
    }

    int getSize() {
        return size;
    }

    public void addItem(T newItem) {
        GraphNode<T> temp = new GraphNode<T>(getSize(), newItem);//create a temp variable with index at end
        GraphNode<T> cur = first;//pointer to first variable
        if (cur == first) {

        }
        for(int i=1;i< getSize(); i++) {
            if (cur.getNext() == null) throw new System.Exception();
            if(cur.getIndex() < cur.getNext().getIndex()) {
                break;
            }
            cur = cur.getNext();
        }
        size++;
        temp.getNext().setNext(cur.getNext());
        cur.setNext(temp);
    }
}
