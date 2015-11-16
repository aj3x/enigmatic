using UnityEngine;
using System.Collections;

public class NPC_Calc : ScriptableObject {

    Graph<Characters, Relationship> NPC_Graph;


    void Start() {
        NPC_Graph = new Graph<Characters, Relationship>(20, true);

        NPC_Graph.addItem(new Characters("Alpha"));
        NPC_Graph.addItem(new Characters("Beta"));
        NPC_Graph.addItem(new Characters("Charlie"));
        NPC_Graph.addItem(new Characters("Delta"));

        //NPC_Graph.addEdge


        /*
        //Debugging for items in correct spots
        if ("Alpha" != NPC_Graph.getName(0)) throw new System.Exception("KABLOOOEY");
        else Debug.Log("alright");


        //names in correct spots
        for (int i = 0; i < 4; i++) {
            Debug.Log("Name: "+NPC_Graph.getName(i));
        }
        */

    }
}
