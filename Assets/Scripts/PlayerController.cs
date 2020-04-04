using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float jumpPower = 600;
	private float speed = 4;
	public bool is_landing = true; // 二段ジャンプ防止
	public bool operation = true; // プレイヤーの操作権限
	public bool timer_operation = true; // タイマーの操作権限
	public GameObject Timer;
	public Rigidbody rb;
	AudioSource audioSource;
	public AudioClip jumpAudio; // ジャンプのSE
	public AudioClip goalAudio; // ゴールのSE
	public AudioClip gameoverAudio; // ゲームオーバーのSE
	public GameObject goal_text;
	public GameObject gameover;
	public GameObject panel;

	void Start()
	{
		this.is_landing = true;
		this.operation = true;
		rb = this.GetComponent<Rigidbody>();
		audioSource = this.GetComponent<AudioSource>();
	}

	void FixedUpdate()
	{
		timer_operation = Timer.GetComponent<Timer>().operation;
		// タイムアップでプレイヤー停止
		if (timer_operation == false)
			operation = false;
		if (this.operation)
		{
			if (this.is_landing)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					audioSource.PlayOneShot(jumpAudio);
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
			this.is_landing = true;
		if (collision.gameObject.tag == "Goal")
		{
			audioSource.PlayOneShot(goalAudio);
			goal_text.SetActive(true);
			panel.SetActive(true);
			this.operation = false;
		}
		if (collision.gameObject.tag == "Gameover")
		{
			audioSource.PlayOneShot(gameoverAudio);
			gameover.SetActive(true);
			panel.SetActive(true);
			this.operation = false;
		}
	}
}
