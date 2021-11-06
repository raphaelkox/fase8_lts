using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    event Action<Vector2> OnDirectionInput;
}
