using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TankView : MonoBehaviour
{

    private TankController tankController;
    private float movementInput;
    private float rotationInput;

    public Transform firePoint;
    public Rigidbody rb;
    public MeshRenderer[] childs;

    public AudioClip driving;
    public AudioClip idle;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        if (movementInput != 0)
            tankController.Move(movementInput);

        if (rotationInput != 0)
            tankController.Rotate(rotationInput);
        PlayMovementAudio();
        CheckFiring();
    }

	private void PlayMovementAudio()
	{
        if (rb.velocity != Vector3.zero && source.clip != driving)
        {
            source.clip = driving;
            source.Play();
        }
        else if(rb.velocity == Vector3.zero && source.clip != idle)
		{
            source.clip = idle;
            source.Play();
        }
    }

	private void CheckFiring()
	{
        if (Input.GetMouseButtonDown(0))
            tankController.Fire();
	}

	private void GetInput()
    {
        movementInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");
    }

    public void SetTankController(TankController _tankController) => tankController = _tankController;

    public Rigidbody GetRigidbody() => rb;

    public void ChangeColor(Material color)
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].material = color;
        }
    }
}
