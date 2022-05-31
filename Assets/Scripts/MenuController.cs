using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
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
		gameObject.SetActive(false);
	}
}
