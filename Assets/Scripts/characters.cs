using UnityEngine;
using System.Collections;

public class characters : MonoBehaviour {
    string firstName;
    public int weapon;
    bool isMale;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    /**
    public string getWeapon() {
        
        switch (weapon) {
            case 0: return "rock"; 
            case 1: return "knife"; 
            case 2: return "pistol"; 
            case 3: return "brass knuckles"; 
            case 4: return "sword"; 
            case 5: return "pistol"; 
            case 6: return "revolver"; 
            case 7: return "axe"; 
            case 8: return "rope"; 
            case 9: return "club"; 
            default: Debug.LogError("Has weapon not defined by code. Changing to 0.");
                weapon = 0;
                return "rock";
        }
    }*/
}
