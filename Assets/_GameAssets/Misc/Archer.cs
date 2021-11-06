using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : IAttacker, IAim
{
    public float Accuracy;
    public int Arrows;
    public string Bow;

    public void Atk(float dmg){
        Arrows -= 1;
        Debug.Log("Archer caused " +  dmg + "! " + Arrows + " arrows left." );
    }

    public void Aim(){
        Debug.Log("Archer take aim at target!");
    }
}
