using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject turret;

    public void instantiateTurret(Vector3 pos)
    {
        Instantiate(turret, new Vector3(pos.x, pos.y + 0.05f, pos.z), Quaternion.identity);
    }
    
}
