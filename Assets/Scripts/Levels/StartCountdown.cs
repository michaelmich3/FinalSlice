using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountdown : MonoBehaviour
{
	[SerializeField] private float startCountdown = 3;
	[SerializeField] private Text startCountdownText;
	[SerializeField] private GameObject levelUI;

	private bool gameStarted = false;



	void Awake()
	{
		levelUI.SetActive(false);
		Time.timeScale = 0;
	}
	
	void Update()
	{
		CountdownTimer();
	}



	private void CountdownTimer()
	{
		//Update the countdown timer UI
		startCountdownText.text = startCountdown.ToString("F0");

		//Count down time for level start
		if (startCountdown > 0)
		{
			startCountdown -= Time.unscaledDeltaTime;
		}
		else if(startCountdown <= 0)
         {
			if (!gameStarted)
			{
				//Enable level UI and scale time to 1
				gameStarted = true;
				startCountdown = 0;
				
				levelUI.SetActive(true);
				startCountdownText.enabled = false;
				Time.timeScale = 1;
			}
         }
	}
}
