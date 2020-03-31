using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFloat : MonoBehaviour
{
	private float speed = 2;
	public bool flag = true;
	public int count = 0;
	float trans;

	void Start()
	{
		trans = this.transform.position.y - 9;
	}

	void Update()
	{
		float step = speed * Time.deltaTime;

		if (count < 9)
		{
			if (flag)
			{
				Vector3 target = new Vector3(this.transform.position.x, trans, this.transform.position.z);
				transform.position = Vector3.MoveTowards(transform.position, target, step);
				if (this.transform.position.y == trans)
				{
					flag = false;
					trans = this.transform.position.y + 9;
					count++;
				}	
			}
			if (flag == false)
			{
				Vector3 target = new Vector3(this.transform.position.x, trans, this.transform.position.z);
				transform.position = Vector3.MoveTowards(transform.position, target, step);
				if (this.transform.position.y == trans)
				{
					flag = true;
					trans = this.transform.position.y - 9;
					count++;
				}
			}
		}
	}
}
