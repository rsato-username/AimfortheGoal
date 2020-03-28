using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
	private float speed = 2;
	public bool flag = true;
	public int count = 0;

	void Update()
	{
		Vector3 target = new Vector3(this.transform.position.x, -3, this.transform.position.z);
		float step = speed * Time.deltaTime;
		

		if (count < 7)
		{
			if (flag)
			{
				if (this.transform.position.y > -3)
				{
					transform.position = Vector3.MoveTowards(transform.position, target, step);
					if (this.transform.position.y == -3)
					{
						flag = false;
						count++;
					}
				}
				
			}
			if (flag == false)
			{
				if (this.transform.position.y < 6)
				{
					target = new Vector3(this.transform.position.x, 6, this.transform.position.z);
					transform.position = Vector3.MoveTowards(transform.position, target, step);
					if (this.transform.position.y == 6)
					{
						flag = true;
						count++;
					}
				}
			}
		}
	}
}
