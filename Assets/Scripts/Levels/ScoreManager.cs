using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public static int Player1Score = 0;
	public static int Player2Score = 0;
	public static int Player3Score = 0;
	public static int Player4Score = 0;

	[SerializeField] private GameObject player1ScoreText;
	[SerializeField] private GameObject player2ScoreText;
	[SerializeField] private GameObject player3ScoreText;
	[SerializeField] private GameObject player4ScoreText;

	private Text text1;
	private Text text2;
	private Text text3;
	private Text text4;



	private void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
		text1 = player1ScoreText.GetComponent<Text>();
		text2 = player2ScoreText.GetComponent<Text>();
		text3 = player3ScoreText.GetComponent<Text>();
		text4 = player4ScoreText.GetComponent<Text>();
	}

	private void Update()
	{
		SetScoreText();
	}



	private void SetScoreText()
	{
		//Update the score UI
		text1.text = "Player 1: " + Player1Score;
		text2.text = "Player 2: " + Player2Score;
		text3.text = "Player 3: " + Player3Score;
		text4.text = "Player 4: " + Player4Score;
	}
}
