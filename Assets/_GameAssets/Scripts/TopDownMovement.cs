using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    Rigidbody2D rb;
    IController controller;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        if(TryGetComponent(out controller)) {
            controller.OnDirectionInput += SetDirInput;
        }
        else {
            Debug.LogWarning("No Controller");
        }
    }

    void Update()
    {
        rb.velocity = dir.normalized * speed;
    }

    public void SetDirInput(Vector2 new_dir) {
        dir = new_dir;
    }
}
