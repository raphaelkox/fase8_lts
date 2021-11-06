using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : IAttacker
{
    public float MP;
    public string Spell1;
    public string Spell2;
    public string Staff;

    public void Atk(float dmg){
        MP -= 20f;
        Debug.Log("Mage caused " +  dmg + " by casting " + Spell1 + "! " + MP + " MP left." );
    }
}
