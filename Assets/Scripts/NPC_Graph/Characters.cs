using UnityEngine;
using System.Collections;
//ScriptableObject
public class Characters {
    string firstName;
    bool isMale;
    
    int loyalty;//sets how likely they are to help you
    int fear;//what you have to beat to get help
    int fearMax;//if fear is > then trigger events
    int location;//current location on map
    int ability;//ability
    bool isKiller;//is this character the killer
    bool isDead;//is this character dead
    public int numReveals;
    Weapon weap;
    

	// Use this for initialization
	public Characters (string name,int weap_seed) {
        firstName = name;
        loyalty = 0;
        fear = 0;
        numReveals = 0;
        weap = new Weapon(weap_seed);
	}


    /// <summary>
    /// Increace the current number of reveals used on this character
    /// loyalty moves down 
    /// </summary>
    public void addReveal() {
        numReveals++;
        loyalty -= fear;
    }

    //will this person help you
    public bool willHelp() {
        return (loyalty > fear);
    }


    //can reveal information they have on other characters or themselves
    public void useLoyalty(int num) {

    }

    
    public int getWeaponIndex() {
        return weap.getWeaponIndex();
    }

    public string getWeapon() {
        return weap.getWeapon();
    }

    public int getWeaponCategory() {
        return weap.getWeaponCategory();
    }
    public int getWeaponCategory(int num) {
        return weap.getWeaponCategory(num);
    }


    public void setKiller() {
        isKiller = true;
    }

    override
    public string ToString() {
        return firstName;
    }
    
}
