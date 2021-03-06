﻿using UnityEngine;
using System.Collections;

public class NPC_Calc : MonoBehaviour {

    Graph<Characters, Relationship> NPC_Graph;
    public GameObject []characterList;
    double seed;
    int size;
    int revealSize;
    public GraphNode<Characters> killer;
    public PCtoNPC toPC;

    void Start() {
        revealSize = 6;
        seed = GameObject.Find("MetaController").GetComponent<meta_script>().GetSeed();
        toPC = GameObject.Find("Player").GetComponent<PCtoNPC>();
        characterList = gameObject.GetComponent<NPC_Calc>().characterList;

        size = characterList.Length;//change dependent on number of people
        NPC_Graph = new Graph<Characters, Relationship>(size, true);
        
        for(int i=0;i< size; i++) {
            NPC_Graph.addItem(new Characters(characterList[i].name, getSeedDigit(i)));
        }
        killer = NPC_Graph.findNode(0);
        //killer.setKiller();

        /*
        NPC_Graph.addEdge(0, 2, 100);
        NPC_Graph.addEdge(0, 1, 20);
        NPC_Graph.addEdge(0, 3, -20);
        */




        
        double temp = modSeed(seed);
        //initialize array to 0
        int[] tempArr = new int[5];
        for (int i = 0; i < 5; i++) {
            tempArr[i] = 0;
        }
        //set each characters role accordingly
        for (int i = 0; i < 10; i++) {
            int num = (int)(temp / Mathf.Pow(100, i) % 100);
            tempArr[num%5]++;
            NPC_Graph.findNode(i).getData().setRole(num%5);
        }

        /*go through each edge checking if it's filled yet
        * if not insert edge with seed determined weight
        */
        for (int i = 0; i < NPC_Graph.getSize(); i++) {
            for(int j = 0; j < NPC_Graph.getSize(); j++) {
                if(NPC_Graph.findEdge(i, j) == null && i!=j) {
                                                              //Rating              // +/-
                    NPC_Graph.addEdge(i, j, getRelation((int)(100 - temp % 100)) * (int)(temp%2*2-1) );
                    temp /= 100;
                    if (temp < 1) {
                        temp = modSeed2(seed);
                    }
                }
            }
        }
        toPC = GameObject.Find("Player").GetComponent<PCtoNPC>();
        
        

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
    private double modSeed2(double num) {
        double multiplier = 130796182357;
        return (num - multiplier) * multiplier;
    }


    /// <summary>
    /// Gets digit in seed at position index
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private int getSeedDigit(int index) {
        return (int)(seed / Mathf.Pow(10, index) % 10);
    }


    void swap(int[] arr,int i,int j) {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    /// <summary>
    /// Returns the index of the person to reveal from neighbours and self.
    /// Adds 10 if category is to be revealed
    /// </summary>
    /// <param name="guy">index of npc that's talking</param>
    /// <param name="category">empty bool that changes based on result</param>
    /// <returns></returns>
    public int revealPerson(int guy) {
        int maxSize = 6;
        int[] best = new int[maxSize];

        best[0] = hasMurderWeapon(guy) * 100;
        best[1] = hasMurderCategory(guy) * 100;

        int patsy = getNeighbour(false, guy);
        best[2] = hasMurderWeapon(patsy) * NPC_Graph.findEdge(guy, patsy).getWeight();
        best[3] = hasMurderCategory(patsy) * NPC_Graph.findEdge(guy, patsy).getWeight();

        patsy = getNeighbour(true, guy);
        best[4] = hasMurderWeapon(patsy) * NPC_Graph.findEdge(guy, patsy).getWeight();
        best[5] = hasMurderCategory(patsy) * NPC_Graph.findEdge(guy, patsy).getWeight();

        int[] orderIndex = new int[maxSize];
        for (int i = 0; i < maxSize; i++) {
            orderIndex[i] = i;
        }
        for (int i = 0; i < maxSize; i++) {
            for (int j = i + 1; j < maxSize; j++) {
                if (best[i] < best[j]) {
                    swap(best, i, j);
                    swap(orderIndex, i, j);
                }
            }
        }

        //can't reveal weapon and then weapon category
        //this is infered from the weapon so 
        //only reveal stuff player doesn't know
        bool[] visited = new bool[maxSize/2];//initialize array half reveal
        for(int i = 0; i < maxSize/2; i++) {
            visited[i] = false;
        }
        int[] reveal = new int[maxSize];
        revealSize = 0;

        //go through array to sort
        for(int i = 0; i < maxSize; i++) {
            int person = orderIndex[i] / 2;//person pulled from weapon 

            if (!visited[person]) {
                reveal[revealSize] = orderIndex[i];
                revealSize++;//hasn't been visited add to number of reveals
                if (orderIndex[i] % 2 == 0) {//only set to visited once weapon is revealed
                    visited[person] = true;
                }
            }
        }

        //save the index of reveal
        
        int revealIndex = NPC_Graph.findNode(guy).getData().numReveals;
        //
        if (revealIndex >= revealSize)
            return -1;

        int index = reveal[revealIndex];
        NPC_Graph.findNode(guy).getData().addReveal();
            if (index % 2 == 0) {
                return (guy + index/2 + 9) % 10;
            } else {
                return (guy + index/2 + 9) % 10+10;
            }
            


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
    public int askAbout(int first, int second) {
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
        if (temp.getWeaponIndex() == killer.getData().getWeaponIndex()) {//CHANGE TO GET MURDERWEAPON
            return -2;
        } else if (temp.getWeaponCategory() == killer.getData().getWeaponCategory()) {//has weapon of same category
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
        if (temp.getWeaponCategory() == killer.getData().getWeaponCategory()) {
            return -1;
        } else {
            return 1;
        }
    }


    public int findIndex(string name) {
        return NPC_Graph.getIndex(name);
    }
    public string findName(int index) {
        return NPC_Graph.getName(index);
    }
    public int relation(int first, int second) {
        return NPC_Graph.findEdge(first,second).getWeight();
    }
    

    /// <summary>
    /// Adjusts other NPC's loyalty according to 
    /// </summary>
    /// <param name="npcIndex">Index of NPC, PC is doing quest for</param>
    public void startQuest(int npcIndex) {
        for(int i=0;i< size; i++) {
            if (npcIndex != i) {
                if (NPC_Graph.findEdge(npcIndex, i).getWeight() > 0) {
                    NPC_Graph.findNode(i).getData().offsetLoyalty(1);
                } else {
                    NPC_Graph.findNode(i).getData().offsetLoyalty(-4);
                }
            }
        }

    }


}
