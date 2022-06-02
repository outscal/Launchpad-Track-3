using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraController : MonoBehaviour
{
	public CinemachineVirtualCamera virtualCamera;
	private CinemachineBasicMultiChannelPerlin noise;

	public void SetPlayer(Transform player)
	{
		virtualCamera.Follow = player;
		virtualCamera.LookAt = player;
		noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
	}

	public void CameraShake()
	{
		StartCoroutine(StartCameraShake());
	}

	IEnumerator StartCameraShake()
	{
		noise.m_AmplitudeGain = 1.3f;
		yield return new WaitForSeconds(0.2f);
		noise.m_AmplitudeGain = 0;
	}
}
