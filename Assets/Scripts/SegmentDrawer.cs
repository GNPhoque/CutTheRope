using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(HingeJoint2D))]
public class SegmentDrawer : MonoBehaviour
{
	[SerializeField]
	LineRenderer lr;
	[SerializeField]
	HingeJoint2D hinge;

	public void SetTarget(Rigidbody2D rb)
	{
		hinge.connectedBody = rb;
		lr.SetPosition(0, Vector3.zero);
		lr.SetPosition(1, hinge.anchor);
	}
}
