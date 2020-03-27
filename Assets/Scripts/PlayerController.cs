using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float jumpPower = 600;
	private float speed = 4;
	public bool is_landing = true;
	public bool operation = true;
	public bool timer_operation = true;
	public GameObject Timer;
	public Rigidbody rb;

	public GameObject goal_text;
	public GameObject gameover;
	public GameObject panel;

	void Start()
	{
		this.is_landing = true;
		this.operation = true;
		rb = this.GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		timer_operation = Timer.GetComponent<Timer>().operation;
		if (timer_operation == false)
		{
			operation = false;
		}
		if (this.operation)
		{
			if (this.is_landing)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					this.is_landing = false;
					this.rb.AddForce(transform.up * jumpPower);
				}
			}
			if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			{
				float x = 3 * speed;
				if (x <= 12)
				{
					this.rb.AddForce(x, 0, 0);
				}
			}
			if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			{
				float x = -3 * speed;
				if (x >= -12)
				{
					this.rb.AddForce(x, 0, 0);
				}
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Stage")
		{
			this.is_landing = true;
		}
		if (collision.gameObject.tag == "Goal")
		{
			goal_text.SetActive(true);
			panel.SetActive(true);
			this.operation = false;
		}
		if (collision.gameObject.tag == "Gameover")
		{
			gameover.SetActive(true);
			panel.SetActive(true);
			this.operation = false;
		}
	}
}
