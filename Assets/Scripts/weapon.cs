using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    int weapon;
	// Use this for initialization
	void Start () {
        weapon = 0;//DEFAULTS TO FISTS BUT SHOULD BE CHANGED
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    /// <summary>
    /// returns the index of weapon
    /// </summary>
    /// <returns></returns>
    public int getWeaponIndex() {
        return weapon;
    }


    /// <summary>
    /// returns value based on whether character has weapon
    /// </summary>
    /// <returns>
    /// 2 if has weapon
    /// 1 if has similar weapon
    /// 0 does not have weapon
    /// </returns>
    int hasMurderWeapon() {
        //person has murder weapon 
        if (getWeaponIndex() == -1 || getWeaponIndex() == 0) {//CHANGE TO GET MURDERWEAPON
            return 2;
        } else if (getWeaponIndex() == -1) {//has weapon of same category
                                      //^--- change this value to be murder weapon category
            return 1;
        } else {//doesn't have weapon
            return 0;
        }
    }

    /// <summary>
    /// Return weapon category 
    /// also is used to determine how char was murdered
    /// 0 -> strangled
    /// 1 -> shot
    /// 2 -> bludgeoned
    /// 3 -> stabbed
    /// </summary>
    /// <returns></returns>
    int weaponCategory() {
        switch (getWeaponIndex()) {
            case 0: return 0;//strangled
            case 1: return 0;
            case 2: return 1;//shot
            case 3: return 1;
            case 4: return 2;//bludgeoned
            case 5: return 2;
            case 6: return 2;
            case 7: return 3;//stabbed
            case 8: return 3;
            case 9: return 3;
            default: Debug.LogError("Did not select proper category"); return -1;
        }
    }


    /*
    0,1 -> rope/fists   strangled
    2,3 -> gun          shot
    2,3,4->blunt        bludgeoned
    5,6,7-> blades      stabbed
    */

    /// <summary>
    /// Returns the weapon in string form from the index
    /// </summary>
    /// <returns>String of weapon</returns>
    public string getWeapon() {
        switch (weapon) { 
            case 0: return "fist";
            case 1: return "rope";
            case 2: return "pistol";
            case 3: return "revolver";
            case 4: return "knife";
            case 5: return "spike";
            case 6: return "sword";
            case 7: return "candlestick";
            case 8: return "rock";
            case 9: return "lamp";
            default:
                Debug.LogError("This weapon not defined by code. Changing to fist.");
                weapon = 0;
                return "fist";
        }
    }
}
