using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectAnchorToCandy : MonoBehaviour
{
	[SerializeField]
	Transform ropeParent;
	[SerializeField]
	GameObject segmentPrefab;
	[SerializeField]
	HingeJoint2D prefabJoint;
	[SerializeField]
	bool selectRopeLength;
	[SerializeField]
	int ropeLength;

	private void Start()
	{
		Transform candy = GameObject.FindGameObjectWithTag("Candy").transform;
		Transform anchor = transform;
		{
			//DEFINITION
			float candyDistance = Vector3.Distance(candy.position, anchor.position);
			if (!selectRopeLength)
			{
				ropeLength = Mathf.CeilToInt(candyDistance / prefabJoint.anchor.x); 
			}

			GameObject[] segments = new GameObject[ropeLength];

			//INSTANTIATE
			for (int i = 0; i < ropeLength; i++)
			{
				GameObject go = Instantiate(segmentPrefab, ropeParent);
				segments[i] = go;
				if (i == 0)
				{
					anchor.GetComponent<HingeJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();
				}
				else
				{
					segments[i - 1].GetComponent<SegmentDrawer>().SetTarget(go.GetComponent<Rigidbody2D>());
				}
			}
			segments[segments.Length - 1].GetComponent<SegmentDrawer>().SetTarget(candy.GetComponent<Rigidbody2D>());
		}
	}
}
