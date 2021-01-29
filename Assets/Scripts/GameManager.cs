using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
  [SerializeField]
  private GameObject turret;

  [SerializeField]
  private int playerMoney = 100;

  /**
   * instantiate turret on touched hexagon, if turret would block npcs path don't place it
   */
  public void instantiateTurret(Transform groundTrans)
  {
    Vector3 pos = groundTrans.position;
    GameObject instantiatedTurret = Instantiate(turret, new Vector3(pos.x, pos.y + 0.1f, pos.z), groundTrans.rotation);
    if (!isNPCPathComplete())
    {
      Destroy(instantiatedTurret);
    }
    else
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
    foreach (GameObject npc in npcs)
    {
      NavMeshAgent navMeshAgent = npc.GetComponent<NavMeshAgent>();
      GameObject npcTarget = npc.GetComponent<Hunt>().GetTarget();
      NavMeshPath path = new NavMeshPath();
      navMeshAgent.CalculatePath(npcTarget.transform.position, path);
      if (path.status != NavMeshPathStatus.PathComplete)
      {
        return false;
      }
    }
    return true;
  }

  // TODO call this when NPC was killed or turret has been sold
  public void ModifyPlayerMoney(int amount = 10)
  {
    playerMoney += amount;
    GetComponent<UIManager>().showMoneyText(playerMoney);
  }

  public int getPlayerMoney()
  {
    return playerMoney;
  }
}
