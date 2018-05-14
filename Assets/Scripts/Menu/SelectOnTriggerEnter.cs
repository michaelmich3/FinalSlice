using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectOnTriggerEnter : MonoBehaviour
{
    [SerializeField] GameObject TextTarget;
    [SerializeField] string levelName;
    [SerializeField] bool loadLevel;
    [SerializeField] bool exitGame;

    private bool isInTrigger;

    private void Update()
    {
        if (isInTrigger)
        {
            TextTarget.SetActive(true);
            if (Input.GetButtonDown("Melee1") || Input.GetButtonDown("Melee2") || Input.GetButtonDown("Melee3") || Input.GetButtonDown("Melee4"))
            {
                if (loadLevel)
                {
                    LoadLevel();
                }
                else if (exitGame)
                {
                    ExitGame();
                }
            }
        }
        else
        {
            TextTarget.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player1" || other.tag == "Player2" || other.tag == "Player3" || other.tag == "Player4")
        {
            isInTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player1" || other.tag == "Player2" || other.tag == "Player3" || other.tag == "Player4")
        {
            isInTrigger = false;
        }
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
