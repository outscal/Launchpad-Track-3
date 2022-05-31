using System;
using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;

    private Rigidbody rb;

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);
        rb = tankView.GetRigidbody();

        tankModel.SetTankController(this);
        tankView.SetTankController(this);

        tankView.ChangeColor(tankModel.color);
    }

    public void Move(float movement)
    {
        rb.velocity = tankView.transform.forward * movement * tankModel.movementSpeed;
    }
    public void Rotate(float rotate)
    {
        Vector3 vector = new Vector3(0f, rotate * tankModel.rotationSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public TankModel GetTankModel()
    {
        return tankModel;
    }

	internal void Fire()
	{
        ShellScript newShell = GameObject.Instantiate<ShellScript>(tankModel.shellPrefab);
        newShell.SetShellProperties(tankView.firePoint);
	}
}
