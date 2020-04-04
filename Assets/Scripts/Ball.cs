using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	void Start()
	{
		this.GetComponent<Rigidbody>().velocity = new Vector3(-5, 0, 0);
	}

	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Stage")
			Destroy(this.gameObject);
		if (collision.gameObject.tag == "Goal")
			Destroy(this.gameObject);
		if (collision.gameObject.tag == "Gameover")
			Destroy(this.gameObject);
	}
}
