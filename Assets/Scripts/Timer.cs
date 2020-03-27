using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	[SerializeField] private int minute;
	[SerializeField] private float seconds;
	[SerializeField] public GameObject Player;
	private float oldSeconds; // 前のUpdateの時の秒数
	public Text timerText; // タイマー表示用テキスト

	public GameObject gameover;
	public bool operation;
	public bool player_operation;

 
	void Start ()
	{
		minute = 1;
		seconds = 30;
		oldSeconds = 0;
		timerText = GetComponentInChildren<Text>();
		operation = true;
		player_operation = Player.GetComponent<PlayerController>().operation;
	}
 
	void Update ()
	{
		player_operation = Player.GetComponent<PlayerController>().operation;
		if (player_operation == false)
		{
			operation = false;
		}
		if (this.operation)
		{
			seconds -= Time.deltaTime;
			if (seconds <= 00)
			{
				minute--;
				seconds = seconds + 60;
			}
			if ((int)seconds != (int)oldSeconds)
			{
				timerText.text = minute.ToString("00") + ":" + ((int) seconds).ToString("00");
			}
			oldSeconds = seconds;
		}
		if (timerText.text == "00:00")
		{
			operation = false;
			gameover.SetActive(true);
		}
	}
}
