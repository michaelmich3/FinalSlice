using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private string menuLevel;
	[SerializeField] private string[] Levels;

	private int random;
	private string sceneName;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void LoadLevel() //Use this when player wins round
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
