using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public GameObject test;

    Rigidbody2D rb;
    public float speed;
    public bool canWalk = true;

    public float gridx;
    public float gridy;

    //public float timeScale;

    public Camera camera;

    public UnityEvent<float, float> OnGridPosChanged;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        var sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if (!canWalk) {
            rb.velocity = Vector2.zero;
            return;
        }

        var gridPos = GameManager.GetGridPosition(transform.position);

        var campos = camera.WorldToViewportPoint(test.transform.position);

        /*if ((gridPos.x != gridx) || (gridPos.y != gridy)) {
            gridx = gridPos.x;
            gridy = gridPos.y;

            canWalk = false;
            OnGridPosChanged?.Invoke(gridx, gridy);
        }*/

        transform.DOScale(1.1f, 0.1f);

        var dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        dir.Normalize();

        rb.velocity = dir * speed;

        DetectHiddeable();
    }

    public void EnableWalk() {
        canWalk = true;
    }

    public void DetectHiddeable() {
        var colliders = Physics2D.OverlapBoxAll(transform.position, Vector2.one, 0f);
        Hideable hideable;

        foreach (var collider in colliders) {
            if (collider.TryGetComponent(out hideable)) {
                hideable.hidden = true;
                hideable.enabled = true;
                collider.GetComponent<SpriteRenderer>().enabled = false;
                Debug.Log("Collision Detected!");
            }
        }
    }
}