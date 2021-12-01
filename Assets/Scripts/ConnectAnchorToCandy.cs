using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectAnchorToCandy : MonoBehaviour
{
	[SerializeField]
	GameObject segmentPrefab;
	[SerializeField]
	Transform candy;
	[SerializeField]
	Transform[] anchors;

	private void Start()
	{
		foreach (var anchor in anchors)
		{
			//DEFINITION
			Vector2 candyDistance = candy.position - anchor.transform.position;
			Vector2 spawnDirection = candyDistance.normalized;
			int segmentNumber = Mathf.CeilToInt(candyDistance.magnitude);
			float distanceBetweenSegments = candyDistance.magnitude / segmentNumber;
			Vector2 nextSegmentSpawnPos = anchor.position;

			GameObject[] segments = new GameObject[segmentNumber];

			//INSTANTIATE
			for (int i = 0; i < segmentNumber; i++)
			{
				GameObject go = Instantiate(segmentPrefab, nextSegmentSpawnPos, Quaternion.identity);
				nextSegmentSpawnPos = spawnDirection * distanceBetweenSegments;
				segments[i] = go;
			}

			anchor.GetComponent<HingeJoint2D>().connectedBody = segments[0].GetComponent<Rigidbody2D>();
			//SET DRAWER AND HINGE
			for (int i = 0; i < segmentNumber - 1; i++)
			{
				segments[i].GetComponent<SegmentDrawer>().SetTarget(segments[i + 1].GetComponent<Rigidbody2D>(), Vector2.right);
			}
			segments[segments.Length-1].GetComponent<SegmentDrawer>().SetTarget(candy.GetComponent<Rigidbody2D>(), Vector2.right);
		}
	}
}
