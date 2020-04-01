using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	NavMeshAgent Enemy;
	public GameObject Player;
	public bool player_operation;

	void Start()
	{
		Enemy = gameObject.GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		player_operation = Player.GetComponent<PlayerController>().operation;
		if (player_operation)
		{
			Enemy.destination = Player.transform.position;
		}
		else
			Enemy.destination = this.transform.position;
	}
}
