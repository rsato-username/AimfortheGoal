using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSystem : MonoBehaviour
{
	public GameObject commandPanel;

	public void CommandClose()
	{
		commandPanel.SetActive(false);
	}

	public void CommandOpen()
	{
		commandPanel.SetActive(true);
	}

	public void StartEasy()
	{
		SceneManager.LoadScene("Easy");
	}

	public void StartNormal()
	{
		SceneManager.LoadScene("Normal");
	}

	public void BackGame()
	{
		SceneManager.LoadScene("Start");
	}
}
