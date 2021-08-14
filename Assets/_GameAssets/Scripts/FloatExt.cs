using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloatExt
{
    public static float Remap(this float value, float minA, float maxaA, float minB, float maxB) {
        var p = (value - minA) / (maxaA - minA);
        return p * (maxB - minB) + minB;
    }
}
