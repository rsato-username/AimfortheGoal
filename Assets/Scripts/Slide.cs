using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
	private float speed = 2;
	public bool flag = true;
	public int count = 0;
	float trans;

	void Start()
	{
		trans = this.transform.position.x + 9;
	}

	void Update()
	{
		float step = speed * Time.deltaTime;

		if (count < 15)
		{
			if (flag)
			{
				Vector3 target = new Vector3(trans, this.transform.position.y, this.transform.position.z);
				transform.position = Vector3.MoveTowards(transform.position, target, step);
				if (this.transform.position.x == trans)
				{
					flag = false;
					trans = this.transform.position.x - 9;
					count++;
				}	
			}
			if (flag == false)
			{
				Vector3 target = new Vector3(trans, this.transform.position.y, this.transform.position.z);
				transform.position = Vector3.MoveTowards(transform.position, target, step);
				if (this.transform.position.x == trans)
				{
					flag = true;
					trans = this.transform.position.x + 9;
					count++;
				}
			}
		}
	}
}
