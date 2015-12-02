using UnityEngine;
using System.Collections;

public class SpeechGraph : MonoBehaviour {
    Graph<SpeechData, string> graph;
    GraphNode<SpeechData> curNode;//
    
    
	// Use this for initialization
	public void Start () {
        //build graph
        graph = new Graph<SpeechData, string>(15,false);
        string[] arr;// = gameObject.GetComponent<speech>().introLines;

        

        //Quest
        arr = new string[] {
            "You want a quest?",
            "Sure",
            "No",
        };
        graph.addItem(new SpeechData(arr, "quest", true));

        //Accept quest
        arr = new string[] {
            "Quest Accepted"
        };
        graph.addItem(new SpeechData(gameObject.GetComponent<speech>().questLines, "accept", false));

        //Decline quest
        arr = new string[] {
            "Quest Declined"
        };
        graph.addItem(new SpeechData(arr, "decline", false, true));

        //Close
        arr = new string[] {
            "See you later."
        };
        graph.addItem(new SpeechData(arr, "close", false, true));

        //Help
        arr = new string[] {
            "Temp help string"
        };
        graph.addItem(new SpeechData(arr, "help", false));

        //Busy
        arr = new string[] {
            "I see you're busy.",
            "You're already on a job.",
            "You can't help me if you're helping someone else.",
            "Sorry, the script says you can only help one person at a time."
        };
        graph.addItem(new SpeechData(arr, "busy", false, true));

        //Complain
        arr = new string[] {
            "Well you should get back on the job.",
            "You still don't have it!"
        };
        graph.addItem(new SpeechData(arr, "complain", false, true));

        //Congrat
        arr = new string[] {
            "Great job!",
            "Thanks a lot!"
        };
        graph.addItem(new SpeechData(arr, "congrat", false, true));

        //Reveal
        arr = new string[] {
            "Person has weapon format"
        };
        graph.addItem(new SpeechData(arr, "reveal", false));

        //Hope
        arr = new string[] {
            "Hope that helps.",
            "Glad to be of some help.",
            "Good Luck"
        };
        graph.addItem(new SpeechData(arr, "hope", false, true));


        //Intro Lines
        graph.addItem(new SpeechData(gameObject.GetComponent<speech>().introLines, "intro", false));
        curNode = graph.findNode("intro");

        //Passive Lines
        graph.addItem(new SpeechData(gameObject.GetComponent<speech>().passiveLines, "passive", false, true));

        //edges
        graph.addEdge("intro", "passive", 0);

        graph.addEdge("passive", "quest", 0);
        graph.addEdge("passive", "help", 1);
        graph.addEdge("passive", "busy", 2);
        graph.addEdge("passive", "complain", 3);
        graph.addEdge("passive", "congrat", 4);

        graph.addEdge("help", "close", 0);
        graph.addEdge("busy", "close", 0);
        graph.addEdge("complain", "close", 0);
        //CHANGE UNDER LATER**************************
        graph.addEdge("congrat", "reveal", 0);
        graph.addEdge("reveal", "hope", 0);
        graph.addEdge("hope", "close", 0);

        graph.addEdge("quest", "accept", 0);
        graph.addEdge("quest", "decline", 1);
        graph.addEdge("accept", "close", 0);
        graph.addEdge("decline", "close", 0);

    }

    /// <summary>
    /// Goes to next node in the graph.
    /// </summary>
    public void goToNext() {

        PCtoNPC temp = GameObject.Find("Player").GetComponent<PCtoNPC>();
        //special case
        /*
        0 Quest node
        1 Help node
        2 Busy/Passive
        3 Complain
        4 Congrats
        */
        if (curNode.ToString().Equals("passive")) {
            int num = 0;
            if (temp.questing()) {
                num++;
                if (temp.getQuestNPC().Equals("Butler")) {
                    num++;
                } else {
                    num = 2;
                    if (temp.getQuestNPC() == temp.getTalkNPC()) {
                        num++;
                        if (temp.isQuestDone()) {
                            num++;
                        }
                    }
                }
            } else if (temp.getTalkNPC().Equals("Butler")) {
                num = 1;
            }

            goToNext(num);
        } else {
            goToNext(0);
        }
    }
    /// <summary>
    /// Goes to next node in the graph, depending on the num variable
    /// </summary>
    /// <param name="num"></param>
    public void goToNext(int num) {
        curNode = graph.findNodeWeight(curNode.ToString(), num);
        if (curNode.ToString().Equals("accept")) {//player acccepts quest
            GameObject.Find(gameObject.name).GetComponent<speech>().quest();
            GameObject.Find("Player").GetComponent<PCtoNPC>().startQuest(gameObject.name);
        }
        if (curNode == null) {
            Debug.Log("Went to null node resetting graph");
            goToRoot();
        }
    }

    public void goToRoot() {
        curNode = graph.findNode("passive");
    }

	public void setNodeArr(string name,string [] arr) {
        graph.findNode(name).getData().setLines(arr);
    }
	
    public bool isQuestion() {
        return curNode.getData().isQuestion();
    }
    
    public string[] getLines() {
        if (curNode.getData().isSingle()) {
            int num = Random.Range(0, curNode.getData().getLines().Length);
            if (num >= curNode.getData().getLines().Length) //get some weird error where there is nothing show it
                return new string[0];
            return curNode.getData().getLine(num);
        }
        return curNode.getData().getLines();
    }

    public string getName() {
        return curNode.ToString();
    }
}
