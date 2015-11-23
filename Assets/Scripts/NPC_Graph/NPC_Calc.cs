using UnityEngine;
using System.Collections;

public class NPC_Calc : ScriptableObject {

    Graph<Characters, Relationship> NPC_Graph;
    double seed;
    int size;
    private Characters killer;
    PCtoNPC interact;

    void Start() {
        size = 4;//change dependent on number of people
        seed = GameObject.Find("MetaController").GetComponent<meta_script>().GetSeed();
        NPC_Graph = new Graph<Characters, Relationship>(size, true);

        //Testing Variables
        NPC_Graph.addItem(new Characters("Alpha",getSeedDigit(0)));
        NPC_Graph.addItem(new Characters("Beta", getSeedDigit(1)));
        NPC_Graph.addItem(new Characters("Charlie", getSeedDigit(2)));
        NPC_Graph.addItem(new Characters("Delta", getSeedDigit(3)));

        killer = NPC_Graph.findNode(getSeedDigit(size)%size).getData();
        killer.setKiller();


        NPC_Graph.addEdge(0, 2, 100);
        NPC_Graph.addEdge(0, 1, 20);
        NPC_Graph.addEdge(0, 3, -20);





        //replace jk with seed for actual gameplay later***********************************************************************
        double jk;//deletion
        jk = 18306950871;//deletion
        double temp = modSeed(jk);//replace with seed

        /*go through each edge checking if it's filled yet
        * if not insert edge with seed determined weight
        */
        for (int i = 0; i < NPC_Graph.getSize(); i++) {
            for(int j = 0; j < NPC_Graph.getSize(); j++) {
                if(NPC_Graph.findEdge(i, j) == null && i!=j) {
                                                  //Rating              // +/-
                    NPC_Graph.addEdge(i, j, getRelation((int)(100 - temp % 100)) * (int)(temp%2*2-1) );
                    temp /= 100;
                }
            }
        }
        interact = GameObject.Find("Player").GetComponent<PCtoNPC>();
        

        /*
        //Debugging for items in correct spots
        if ("Alpha" != NPC_Graph.getName(0)) throw new System.Exception("KABLOOOEY");
        else Debug.Log("alright");


        //names in correct spots
        for (int i = 0; i < 4; i++) {
            Debug.Log("Name: "+NPC_Graph.getName(i));
        }
        Debug.Log(NPC_Graph.findEdge(2, 0).getWeight());
        */

    }




    /// <summary>
    /// Takes a percentage and converts it into relationship
    /// Change distribution from linear to Parabolic******************************************************
    /// </summary>
    /// <param name="percent"></param>
    /// <returns></returns>
    int getRelation(int percent) {
        if (percent >= 90) {//10% chance of close
            return 85 + 2 * (100-percent);
        }else if (percent < 30) {//30% chance of distant
            return percent*20/30;
        } else {//60% chance of friendly
            return (percent - 30) * 55 / 60 + 30;
        }
    }

    /// <summary>
    /// Takes the seed and returns a modified version of it
    /// </summary>
    /// <returns>Modified seed</returns>
    double modSeed() {
        return modSeed(seed);
    }

    private double modSeed(double num) {
        double multiplier = 130796182357;//large prime number
        return (num + multiplier) * multiplier;
    }


    /// <summary>
    /// Gets digit in seed at position index
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private int getSeedDigit(int index) {
        return (int)(seed / Mathf.Pow(10, index) % 10);
    }



    /// <summary>
    /// Returns the index of the person to reveal from neighbours and self
    /// changes category depending on whether to reveal weapon or category
    /// </summary>
    /// <param name="guy">index of npc that's talking</param>
    /// <param name="category">empty bool that changes based on result</param>
    /// <returns></returns>
    public int revealPerson(int guy, bool category) {
        int []best = new int[6];

        best[0] = hasMurderWeapon(guy) * 100;
        best[1] = hasMurderCategory(guy) * 100;

        int patsy = getNeighbour(false, guy);
        best[2] = hasMurderWeapon(patsy) * NPC_Graph.findEdge(guy,patsy).getWeight();
        best[3] = hasMurderCategory(patsy) * NPC_Graph.findEdge(guy, patsy).getWeight();

        patsy = getNeighbour(true, guy);
        best[4] = hasMurderWeapon(patsy) * NPC_Graph.findEdge(guy,patsy).getWeight();
        best[5] = hasMurderCategory(patsy) * NPC_Graph.findEdge(guy, patsy).getWeight();

        int[] reveal = best;
        for(int i = 0; i < 6; i++) {
            for(int j = i; j < 6; j++) {
                if (reveal[i] < reveal[j]) {
                    reveal[i] = reveal[j];
                }
            }
        }
        for (int i = 0; i < 6; i++) {
            if (reveal[NPC_Graph.findNode(guy).getData().numReveals] == best[i]) {
                if (i % 2 == 0) {
                    category = false;
                } else {
                    category = true;
                }
                NPC_Graph.findNode(guy).getData().addReveal();
                return (guy + i + 9) % 10;
            }
        }

        //something has gone wrong
        return best[NPC_Graph.findNode(guy).getData().numReveals];


    }

    /// <summary>
    /// Gets the index of it's neighbours
    /// </summary>
    /// <param name="right"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public int getNeighbour(bool right,int index) {
        if (right) {
            return (index+1) % 10;
        } else {
            return (index+9) % 10;
        }
    }

    /// <summary>
    /// Asks first person about second person, whether or not they did it
    /// </summary>
    /// <param name="first">index of first person</param>
    /// <param name="second">index of second person</param>
    /// <returns></returns>
    int askAbout(int first, int second) {
        return NPC_Graph.findEdge(first, second).getWeight() + (15 * hasMurderWeapon(second)) + (25 * hasMurderCategory(second));
    }

    /// <summary>
    /// returns value based on whether character has weapon
    /// -2 if has weapon
    /// 1 does not have weapon
    /// </summary>
    /// <returns>
    /// -2 if has weapon
    /// 1 does not have weapon
    /// </returns>
    int hasMurderWeapon(int index) {
        Characters temp = NPC_Graph.findNode(index).getData();
        //person has murder weapon 
        if (temp.getWeaponIndex() == killer.getWeaponIndex()) {//CHANGE TO GET MURDERWEAPON
            return -2;
        } else if (temp.getWeaponCategory() == killer.getWeaponCategory()) {//has weapon of same category
            return -1;
        } else {//doesn't have weapon
            return 1;
        }
    }

    /// <summary>
    /// returns value based on whether character has weapon
    /// -1 if has same category
    /// 1 does not have category
    /// </summary>
    /// <returns>
    /// -1 if has same category
    /// 1 does not have category
    /// </returns>
    int hasMurderCategory(int index) {
        Characters temp = NPC_Graph.findNode(index).getData();
        if (temp.getWeaponCategory() == killer.getWeaponCategory()) {
            return -1;
        } else {
            return 1;
        }
    }

    


    void startQuest(int npcIndex) {
        for(int i=0;i< size; i++) {
            if (NPC_Graph.findEdge(npcIndex, i).getWeight() > 0) {
                NPC_Graph.findNode(i).getData().offsetLoyalty(1);
            } else {
                NPC_Graph.findNode(i).getData().offsetLoyalty(-4);
            }
        }

    }


}
