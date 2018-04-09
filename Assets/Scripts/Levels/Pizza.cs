using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pizza : MonoBehaviour
{
	[SerializeField] private float pizzaTime;
	[SerializeField] private Text timerText;

	[SerializeField] private GameObject activateObject;

	private Animator animator;
	private bool isActivated = false;



	private void Awake()
	{
		animator = activateObject.GetComponent<Animator>();
	}

	private void Update()
	{
		PizzaTimer();
	}

	private	void OnTriggerEnter(Collider other)
	{
		AddScore(other);
	}



	private void PizzaTimer()
	{
		//Count down time from level start
		if (pizzaTime > 0)
		{
			pizzaTime -= Time.deltaTime;
            timerText.text = "Pizza Time! in: " + pizzaTime.ToString("F1"); //Update the pizza timer UI
        }
		else if(pizzaTime <= 0)
         {
			if (!isActivated)
			{
				//Open pizza slice location when timer is done
				isActivated = true;
				pizzaTime = 0;

                timerText.text = "PIZZA TIME!"; //Update the pizza timer UI
                animator.SetBool("IsActivated", true);
			}
         }
	}

	private void AddScore(Collider other)
	{
		//Add score  +1 to the player that touched the pizza slice first
		if (other.tag == "Player1")
		{
			ScoreManager.Player1Score += 1;
			gameObject.SetActive(false);
		}
		else if (other.tag == "Player2")
		{
			ScoreManager.Player2Score += 1;
			gameObject.SetActive(false);
		}
		else if (other.tag == "Player3")
		{
			ScoreManager.Player3Score += 1;
			gameObject.SetActive(false);
		}
		else if (other.tag == "Player4")
		{
			ScoreManager.Player4Score += 1;
			gameObject.SetActive(false);
		}
	}
}
