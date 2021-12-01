using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector2 vTouchPos;
        for (int i = 0; i < Input.touchCount; i++)
        {
            Debug.Log("Touch!");
            vTouchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            Collider2D col = Physics2D.OverlapPoint(vTouchPos);
            Debug.Log("Collided!");
            if (col != null && col.CompareTag("RopeSegment"))
			{
                Debug.Log("Rope destroyed!");
                Destroy(col.gameObject);
            }
        }
    }
}
