using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSystem : MonoBehaviour
{
	public GameObject commandPanel;
	public GameObject coursePanel;

	public void CloseCommand()
	{
		commandPanel.SetActive(false);
	}

	public void OpenCommand()
	{
		commandPanel.SetActive(true);
	}

	public void CloseCourse()
	{
		coursePanel.SetActive(false);
	}

	public void OpenCourse()
	{
		coursePanel.SetActive(true);
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
