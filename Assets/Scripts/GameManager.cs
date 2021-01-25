using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    
    public GameObject turret;

    [SerializeField]
    private int playerMoney = 500;

    [SerializeField]
    private int playerLifePoints = 50;

    /**
     * instantiate turret on touched hexagon, if turret would block npcs path don't place it
     */
    public void instantiateTurret(Transform trans)
    {
        if (isNPCPathComplete())
        {
            Vector3 pos = trans.position;
            Instantiate(turret, new Vector3(pos.x, pos.y + 0.1f, pos.z), trans.rotation);
        } else
        {
            // TODO make visible that turret can't be placed cause it would block npcs path to destination
        }
    }

    /**
     * Check if NPCs path to destination is complete
     * @return bool if path not complete return false, else return true
     */
    private bool isNPCPathComplete()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
        foreach (GameObject npc in npcs) {
            NavMeshAgent navMeshAgent = npc.GetComponent<NavMeshAgent>();
            if(navMeshAgent.pathStatus != NavMeshPathStatus.PathComplete)
            {
                return false;
            }
        }

        return true;
    }

    public void reducePlayerLifePoints()
    {
        --playerLifePoints;
        if(playerLifePoints <= 0)
        {
            GetComponent<UIManager>().GameLost();
        }
    }

    // TODO call this when NPC was killed or turret has been sold
    public void increasePlayerMoney(int amount = 1)
    {
        playerMoney += amount;
        GetComponent<UIManager>().showMoneyText(playerMoney);
    }

    // TODO call this when new turret was placed/turret was upgraded
    public void descreasePlayerMoney(int amount = 1)
    {
        playerMoney -= amount;
        GetComponent<UIManager>().showMoneyText(playerMoney);
    }
}
