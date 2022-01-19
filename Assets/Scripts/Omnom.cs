using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Omnom : MonoBehaviour
{
	//Transform candy;
	//Transform t;

	//private void Start()
	//{
	//	candy = GameObject.FindGameObjectWithTag("Candy").transform;
	//}

	//private void Update()
	//{
	//	float candyDistance = Vector2.Distance(t.position, candy.position);
	//	//set animations on distance reach : interested, mouth open
	//}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Candy"))
		{
			Destroy(collision.gameObject);
		}
	}
}
