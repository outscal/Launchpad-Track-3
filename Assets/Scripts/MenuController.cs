using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public GameObject startPanel;

	public GameObject endPanel;
	public TextMeshProUGUI finalScoreText;

	public GameObject scorePanel;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI TimerText;

	public GameManager gameManager;

	[Header("Spawner")]
    public TankSpawner spawnner;

	[Header("Menu Tank Properties")]
    public Transform MenuTank;
	public float rotationSpeed;
	private float rotation;

	private TankTypes selectedType;

	private void Start()
	{
		selectedType = TankTypes.GreenTank;
		startPanel.SetActive(true);
		endPanel.SetActive(false);
		scorePanel.SetActive(false);
	}

	private void Update()
	{
		RotateMenuTank();
	}

	private void RotateMenuTank()
	{
		rotation += rotationSpeed * Time.deltaTime;
		MenuTank.rotation = Quaternion.Euler(0, rotation, 0);
	}

	public void SetTankType(int selected)
	{
		selectedType = (TankTypes)selected;
		SetTankColor();
	}

	private void SetTankColor()
	{
		Material tankMaterial = spawnner.tankList[(int)selectedType].color;
		Transform tankBody = MenuTank.GetChild(0);
		foreach (Transform part in tankBody)
		{
			part.GetComponent<MeshRenderer>().material = tankMaterial;
		}
	}

	public void StartGame()
	{
		spawnner.CreateTank(selectedType);
		MenuTank.gameObject.SetActive(false);
		startPanel.SetActive(false);
		scorePanel.SetActive(true);

		gameManager.StartGame();
	}

	public void EndGame(int score)
	{
		endPanel.SetActive(true);
		scorePanel.SetActive(false);
		finalScoreText.text = "Target Destroyed : " + score;
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void UpdateScore(int value)
	{
		scoreText.text = "Target Destroyed : " + value;
	}

	public void UpdateTimer(float value)
	{
		TimerText.text = "Time Left: " + (int)value;
	}

	public void QuitGame()
	{
		Application.Quit();

		
	}
}
