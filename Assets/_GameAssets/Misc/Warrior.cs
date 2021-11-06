using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : IAttacker
{
    public float Strenght;
    public string Sword;
    public string Shield;

    public void Atk(float dmg){
        Debug.Log("Warrior caused " +  dmg + " slashing damage!");
    }
}
