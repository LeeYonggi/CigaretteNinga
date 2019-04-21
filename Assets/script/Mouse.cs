using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MOUSE_STATE
{
    KEY_DOWN,
    KEY_HOLD,
    KEY_UP
}

public class Mouse : MonoBehaviour {

    private MOUSE_STATE mouse_State;
    private TrailRenderer trailRenderer;
    private BoxCollider2D boxCollider;

    internal MOUSE_STATE Mouse_State
    {
        get
        {
            return mouse_State;
        }

        set
        {
            mouse_State = value;
        }
    }


    // Use this for initialization
    void Start () {
        trailRenderer = GetComponent<TrailRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        boxCollider.size = new Vector2(0.1f, 0.1f);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(screenPos.x, screenPos.y);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(screenPos.x, screenPos.y);
        }
        else
        {
            boxCollider.size = new Vector2(0, 0);
        }
    }
}
