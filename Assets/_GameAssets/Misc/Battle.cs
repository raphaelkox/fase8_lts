using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Battle : MonoBehaviour
{

    IAttacker character;

    // Start is called before the first frame update
    void Start()
    {
        var player = new Archer();
        player.Arrows = 10;
        
        character = player;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            //char atk
            character.Atk(10f);
        }
    }
}