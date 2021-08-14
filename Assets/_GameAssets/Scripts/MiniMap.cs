using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MiniMap : MonoBehaviour
{
    public static MiniMap instance;

    public GameObject pinPrefab;

    public Transform player;
    public Dictionary<Transform, RectTransform> pins = new Dictionary<Transform, RectTransform>();

    public RectTransform player_pin;

    public RectTransform map;
    public Transform waypoint;

    public float MapWidth = 265f;
    public float MapHeight = 160f;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        map = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {        
        var mapx = player.position.x.Remap(0f, MapWidth, 0f, map.sizeDelta.x);
        var mapy = player.position.y.Remap(0f, MapHeight, 0f, map.sizeDelta.y);

        player_pin.anchoredPosition = new Vector2(mapx, mapy);

        foreach(var item in pins) {
            mapx = item.Key.position.x.Remap(0f, MapWidth, 0f, map.sizeDelta.x);
            mapy = item.Key.position.y.Remap(0f, MapHeight, 0f, map.sizeDelta.y);

            item.Value.anchoredPosition = new Vector2(mapx, mapy);
        }
    }

    public void OnClick(BaseEventData e) {        
        var pointer_event = e as PointerEventData;
        var pos = map.InverseTransformPoint(pointer_event.position);

        var worldx = pos.x.Remap(0f, map.sizeDelta.x, 0f, 256f);
        var worldy = pos.y.Remap(0f, -map.sizeDelta.y, 0f, -160f);

        waypoint.position = new Vector3(worldx, worldy);
    }

    public void RegisterPin(Transform obj, Sprite icon, Color color) {
        var pin = Instantiate(pinPrefab, transform);
        pin.GetComponent<Image>().sprite = icon;
        pin.GetComponent<Image>().color = color;
        pins.Add(obj, pin.GetComponent<RectTransform>());
    }

    public void UnregisterPin(Transform obj) {
        Destroy(pins[obj].gameObject);
        pins.Remove(obj);
    }
} 