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
}
