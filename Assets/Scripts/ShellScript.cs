using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellScript : MonoBehaviour
{
	public ParticleSystem explosion;
	public Transform trail;
	public Rigidbody shellBody;
	public MeshRenderer shellMesh;
	public Collider shellCollider;

	public float maxVelocity = 5f;
	public float shellLifeTime = 5f;
	public float explosionRadius = 2f;
	public float explosionForce = 1000f;

	private bool exploded = false;
	public AudioClip shootingClip;
	public AudioClip explosionClip;
	public AudioSource source;
	private CameraController cam;

	private void Start()
	{
		shellBody.velocity = maxVelocity * transform.forward;
	}

	public void SetShellProperties(Transform exitPoint,CameraController _cam)
	{
		SetShootingAudio();
		cam = _cam;
		SetShellActive(true);
		transform.SetPositionAndRotation(exitPoint.position, exitPoint.rotation);

		// just precaution, if the shell didnt hit anything
		// it'll still explode after lifetime
		exploded = false;
		Invoke(nameof(Explode), shellLifeTime);
	}

	private void SetShootingAudio()
	{
		source.clip = shootingClip;
		source.Play();
	}

	private void Explode()
	{
		if (exploded)
			return;
		exploded = true;
		SetShellActive(false); 
		CheckInRadius();
		SetOffExplosion();
	}

	private void CheckInRadius()
	{
		Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);
		foreach(Collider col in cols)
		{
			TankView tank = col.GetComponent<TankView>();
			if(tank != null)
			{
				tank.GetRigidbody().AddExplosionForce(explosionForce, transform.position, explosionRadius);
				continue;
			}

			TargetScript target = col.GetComponent<TargetScript>();
			if(target != null)
			{
				target.ChangePosition();
			}
		}
	}

	private void SetShellActive(bool active)
	{
		shellMesh.enabled = active;
		shellCollider.enabled = active;
		trail.gameObject.SetActive(active);
	}

	private void SetOffExplosion()
	{
		cam.CameraShake();
		explosion.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(-90, 0, 0));
		explosion.Play();
		source.clip = explosionClip;
		source.Play();
		Destroy(gameObject, explosion.main.duration);
	}


	private void Update()
	{
		transform.forward = shellBody.velocity;
	}

	private void OnCollisionEnter(Collision collision) => Explode();

}