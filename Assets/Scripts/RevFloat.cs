﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevFloat : MonoBehaviour
{
	Rigidbody rb;
	bool flag = true;
	private int count = 0;
	private float target;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		target = this.transform.position.y + 9;
	}

	void Update()
	{
		if (count < 7)
		{
			if (flag == false)
			{
				rb.velocity = new Vector3(0, -1.5f, 0);
				if (this.transform.position.y < target)
				{
					flag = true;
					target = this.transform.position.y + 9;
					count++;
				}
			}
			if (flag)
			{
				rb.velocity = new Vector3(0, 1.5f, 0);
				if (this.transform.position.y > target)
				{
					flag = false;
					target = this.transform.position.y - 9;
				}
			}
		}
		if (count == 7)
		{
			rb.velocity = new Vector3(0, 0, 0);
		}
	}
}
