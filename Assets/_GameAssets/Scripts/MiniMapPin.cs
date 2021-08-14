using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapPin : MonoBehaviour
{
    public Sprite icon;
    public Color color;

    private void OnEnable() {
        MiniMap.instance.RegisterPin(transform, icon, color);
    }

    private void OnDisable() {
        MiniMap.instance.UnregisterPin(transform);
    }
}
