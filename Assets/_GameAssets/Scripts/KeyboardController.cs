using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour, IController
{
    public event Action<Vector2> OnDirectionInput;
    Vector2 dirInput;
    Vector2 lastDirInput;

    void Update()
    {
        dirInput.x = Input.GetAxisRaw("Horizontal");
        dirInput.y = Input.GetAxisRaw("Vertical");

        if(dirInput != lastDirInput) {
            OnDirectionInput?.Invoke(dirInput);
            lastDirInput = dirInput;
        }
    }
}
