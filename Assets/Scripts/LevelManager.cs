using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private string[] Levels;

	private int random;
	private string sceneName;

	private void LoadLevel()
	{
		random = Random.Range(0, Levels.Length);
		sceneName = SceneManager.GetActiveScene().name;

		while (Levels[random] == sceneName)
		{
			random = Random.Range(0, Levels.Length);
		}

		SceneManager.LoadScene(Levels[random]);
	}
}
