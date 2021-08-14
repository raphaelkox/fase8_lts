using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointArrow : MonoBehaviour
{
    public RectTransform targetArrow;
    public Camera cam;
    public float camWidth;
    public float camHeight;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        camHeight = cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        cam = Camera.main;
        var camPos = cam.transform.position;
        var targetPos = target.position;

        var distX = Mathf.Max(targetPos.x, camPos.x) - Mathf.Min(targetPos.x, camPos.x);
        distX -= camWidth;

        var distY = Mathf.Max(targetPos.y, camPos.y) - Mathf.Min(targetPos.y, camPos.y);
        distY -= camHeight;

        //check if inside screen
        if (distX < 0 && distY < 0) {
            //inside screen
            var viewPos = cam.WorldToViewportPoint(targetPos);
            targetArrow.anchoredPosition = viewPos * new Vector2(1920f, 1080f);

            Debug.Log("X: " + Screen.width);
            Debug.Log("Y: " + Screen.height);
            Debug.Log("view: " + viewPos);
        }
        else {
            //outside screen
            var targetVector = targetPos - camPos;
            targetVector.z = 0;

            float ratio;
            if (distX >= distY) {
                ratio = camWidth / targetVector.x;
                targetVector *= ratio;

                if (targetPos.x < camPos.x) targetVector *= -1f;
            }
            else {
                ratio = camHeight / targetVector.y;
                targetVector *= ratio;

                if (targetPos.y < camPos.y) targetVector *= -1f;
            }

            var worldPos = camPos + targetVector;
            var viewPos = cam.WorldToViewportPoint(worldPos);
            targetArrow.anchoredPosition = viewPos * new Vector2(1920f, 1080f);
        }
    }
}
