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
            //RaycastHit2D[] hitsNumber = Physics2D.RaycastAll(touchPos, touchPosOld - touchPos, Vector2.Distance(touchPos, touchPosOld));
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            int hitsNumber = Physics2D.Raycast(touchPos, touchPosOld - touchPos, new ContactFilter2D(), hits, Vector2.Distance(touchPos, touchPosOld));
            Debug.DrawRay(touchPos, touchPosOld-touchPos, Color.red);
            if (hitsNumber > 0)
            {
				foreach (var hit in hits)
				{
                    Debug.Log(hit.collider.name);
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
                    //UpdateCollider();
				}
            }
            else
            {
                tr.Clear();
                tr.enabled = false;
            }
        }
    }

    void UpdateCollider()
    {
        var ec = gameObject.GetComponent<EdgeCollider2D>();
        Vector3[] points = new Vector3[tr.positionCount];
        tr.GetPositions(points);

        Vector2[] pointsList = new Vector2[tr.positionCount];

        for (int i = 0; i < points.Length; i++)
        {
            pointsList[i] = (points[i]);
        }

        ec.points = pointsList;
    }
}
