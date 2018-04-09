using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private string menuLevel;
	[SerializeField] private string[] levels;

	private int random;
	private string sceneName;



    public void LoadRandomLevel() //Use this when player wins round on random mode
	{
		random = Random.Range(0, levels.Length);
		sceneName = SceneManager.GetActiveScene().name;

		while (levels[random] == sceneName)
		{
			random = Random.Range(0, levels.Length);
		}

		SceneManager.LoadScene(levels[random]);
	}

    public void LoadSameLevel(int levelNumber) //Use this when player wins round on specific level mode
    {
        SceneManager.LoadScene(levels[levelNumber]);
    }
}
