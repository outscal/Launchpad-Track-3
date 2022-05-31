using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Tank
    {
        public float movementSpeed;
        public float rotationSpeed;
        public TankTypes tankType;
        public Material color;
        public ShellScript shellPrefab;
    }

    public List<Tank> tankList;

    public TankView tankView;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void CreateTank(TankTypes tankType)
    {
        int index = (int)tankType;
        TankModel tankModel = new TankModel(tankList[index].movementSpeed, tankList[index].rotationSpeed, tankList[index].tankType, tankList[index].color, tankList[index].shellPrefab);
        TankController tankController = new TankController(tankModel, tankView);
    }
}
