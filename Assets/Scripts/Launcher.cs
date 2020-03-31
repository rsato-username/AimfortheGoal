using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
	[SerializeField] private float power;
	public GameObject ballPrefab;
	public GameObject timer;
	public GameObject player;
	public bool operation = true;
	public bool timer_operation = true;
	public bool player_operation = true;
	public bool boost;

	void Update()
	{
		timer_operation = timer.GetComponent<Timer>().operation;
		player_operation = player.GetComponent<PlayerController>().operation;
		if (timer_operation == false || player_operation == false)
			operation = false;
		if (this.operation)
		{
			power += Time.deltaTime;
			if (boost)
			{
				power += Time.deltaTime;
			} 
			if (power >= 5.0f)
			{
				power = 0;
				Instantiate(this.ballPrefab, this.transform);
			}
			if (timer.GetComponent<Timer>().timerText.text == "00:30")
			{
				boost = true;
			}
		}
	}
}
