using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	private int minute;
	private float seconds;
	private float oldSeconds; // 前のUpdateの時の秒数
	public Text timerText; // タイマー表示用テキスト
	public GameObject Player;
	public GameObject gameover;
	public GameObject panel;
	public bool operation; // タイマーの操作権限
	public bool player_operation; // プレイヤーの操作権限
	AudioSource audioSource; // ゲームオーバーのSE
	private bool flag = true;
 
	void Start ()
	{
		minute = 1;
		seconds = 30;
		oldSeconds = 0;
		timerText = GetComponentInChildren<Text>();
		operation = true;
		player_operation = Player.GetComponent<PlayerController>().operation;
		audioSource = this.GetComponent<AudioSource>();
	}
 
	void Update ()
	{
		player_operation = Player.GetComponent<PlayerController>().operation;
		// プレイヤー停止でタイマー停止
		if (player_operation == false)
			operation = false;
		if (this.operation)
		{
			seconds -= Time.deltaTime;
			if (seconds <= 0)
			{
				minute--;
				seconds = seconds + 60;
			}
			// タイマー更新
			if ((int)seconds != (int)oldSeconds)
				timerText.text = minute.ToString("00") + ":" + ((int) seconds).ToString("00");
			oldSeconds = seconds;
		}
		// タイムアップ時
		if (timerText.text == "00:00")
		{
			// 一度だけSE
			if (flag)
			{
				audioSource.PlayOneShot(audioSource.clip);
				flag = false;
			}
			operation = false;
			gameover.SetActive(true);
			panel.SetActive(true);
		}
	}
}
