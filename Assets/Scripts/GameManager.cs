using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject turret;

    public void instantiateTurret(Transform trans)
    {
        Vector3 pos = trans.position;
        Instantiate(turret, new Vector3(pos.x, pos.y + 0.1f, pos.z), trans.rotation);
    }
}