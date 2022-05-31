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

    // Start is called before the first frame update
    void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 3f, -4f);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        if (movementInput != 0)
            tankController.Move(movementInput);

        if (rotationInput != 0)
            tankController.Rotate(rotationInput);

        CheckFiring();
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
