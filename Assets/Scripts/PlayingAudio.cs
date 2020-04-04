using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingAudio : MonoBehaviour
{
	AudioSource asource;
	public GameObject player;
	bool operation = true;

	void Start()
	{
		asource = GetComponent<AudioSource>();
	}

	void Update()
	{
		operation = player.GetComponent<PlayerController>().operation;
		// プレイヤー停止でBGMフェードアウト
		if (operation == false)
		{
			asource.volume -= Time.deltaTime / 2;
		}
	}
}
