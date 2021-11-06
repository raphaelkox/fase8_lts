using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseController : MonoBehaviour, IController
{
    public event Action<Vector2> OnDirectionInput;
    public Transform target;
    public float maxDist;
    void Update()
    {
        if (!target) return;

        var dirVector = target.position - transform.position;

        if(dirVector.magnitude > maxDist){
            OnDirectionInput?.Invoke(dirVector);
        }
    }
}
