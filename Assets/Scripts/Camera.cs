using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	public GameObject player;
	private float speed = 20;

	void Update()
	{
		Vector3 playerPos = this.player.transform.position;
		Vector3 target = new Vector3(playerPos.x, playerPos.y, -15);
		float step = speed * Time.deltaTime;

		// プレイヤーのY軸に応じてカメラのZ軸変化
		if (playerPos.y < 10)
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		else if (playerPos.y > 10)
		{
			target = new Vector3(playerPos.x, playerPos.y, -20);
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		}
	}
}
