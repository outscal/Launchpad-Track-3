using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public MenuController menu;

	public int score;
	public float gameTimeLimit;
	public float gameTimer;

	private bool isGamesStart;

	private void Start()
	{
		isGamesStart = false;
		Time.timeScale = 1;
		ResetScore();
	}

	private void ResetScore()
	{
		score = 0;
	}

	public void IncreaseScore(int value)
	{
		score += value;
		gameTimer -= 5;
		menu.UpdateScore(score);
	}

	private void Update()
	{
		if (isGamesStart)
		{
			IncreaseGameTimer();
			isTimerOver();
		}
	}

	private void isTimerOver()
	{
		if (gameTimer >= gameTimeLimit)
		{
			isGamesStart = false;
			Time.timeScale = 0;
			menu.EndGame(score);
		}
	}

	private void IncreaseGameTimer()
	{
		gameTimer += Time.deltaTime;
		menu.UpdateTimer(gameTimeLimit - gameTimer);
	}

	public void StartGame()
	{
		isGamesStart = true;
	}
}
