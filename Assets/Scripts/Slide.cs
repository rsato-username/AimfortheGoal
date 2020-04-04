using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
	Rigidbody rb;
	bool flag = true;
	private int count = 0;
	private float target;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		target = this.transform.position.x + 9;
	}

	void Update()
	{
		// 7往復で運動停止
		if (count < 7)
		{
			if (flag) // 右にスライド
			{
				rb.velocity = new Vector3(1.5f, 0, 0);
				if (this.transform.position.x > target)
				{
					flag = false;
					target = this.transform.position.x - 9;
				}
			}
			if (flag == false) // 左にスライド
			{
				rb.velocity = new Vector3(-1.5f, 0, 0);
				if (this.transform.position.x < target)
				{
					flag = true;
					target = this.transform.position.x + 9;
					count++;
				}
			}
		}
		if (count == 7)
		{
			rb.velocity = new Vector3(0, 0, 0);
		}
	}
}
