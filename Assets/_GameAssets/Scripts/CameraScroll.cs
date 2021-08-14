using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class CameraScroll : MonoBehaviour
{
    public UnityEvent OnCameraScrollEnded;

    public float camtime;
    public Ease cameasing;

    public void ScrollCamera(float gridx, float gridy) {
        var camx = gridx * GameManager.cell_width;
        camx += GameManager.half_cell_width;
        var camy = gridy * GameManager.cell_height;
        camy += GameManager.half_cell_height;

        transform.
            DOMove(new Vector3(camx, camy, -10f), camtime)
            .SetEase(cameasing)
            .OnComplete(() => {
                OnCameraScrollEnded?.Invoke();
            });
    }
}





















