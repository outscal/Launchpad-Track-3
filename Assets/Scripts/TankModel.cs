using UnityEngine;

public class TankModel
{
    private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;
    public TankTypes tankType;
    public Material color;
    public ShellScript shellPrefab;

    public TankModel(float _movement, float _rotation, TankTypes tank, Material _color, ShellScript _shell)
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
        tankType = tank;
        color = _color;
        shellPrefab = _shell;
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
