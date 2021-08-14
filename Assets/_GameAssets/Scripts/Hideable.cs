using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideable : MonoBehaviour
{
    public bool hidden;
    public bool lastHidden;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hidden Check");
        if (!hidden) {
            GetComponent<SpriteRenderer>().enabled = true;
            enabled = false;
            return;
        }

        Debug.Log("Reset Hidden");
        hidden = false;
    }
}
