using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    TrailRenderer tr;

    void Update()
    {
        Vector2 touchPos = Vector2.zero;
        Vector2 touchPosOld = Vector2.zero;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosOld = Camera.main.ScreenToWorldPoint(touch.position - touch.deltaPosition);
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            int a = Physics2D.Raycast(touchPos, touchPosOld - touchPos, new ContactFilter2D(), hits, Vector2.Distance(touchPos, touchPosOld));
            Debug.DrawRay(touchPos, touchPosOld-touchPos, Color.red);
            if (a > 0)
            {
				foreach (var hit in hits)
				{
					if (hit.collider.CompareTag("RopeSegment"))
					{
                        Destroy(hit.collider.gameObject);
                    }
                }
			}
            if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary))
            {
				transform.position = touchPos;
                if (tr.enabled == false)
				{
					tr.enabled = true;
				}
            }
            else
            {
                tr.Clear();
                tr.enabled = false;
            }
        }
    }
}
