using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Verwaltet das Instanziieren und Deaktiveren von Türmen und das playerMoney
/// </summary>
public class GameManager : MonoBehaviour
{
  [SerializeField]
  private GameObject turret;

  [SerializeField]
  private int playerMoney = 100;

  private bool isPlaced = false;
  private int turretCount = 0;

  private GameObject instantiatedTurret;

  private MeshRenderer[] meshRenderers;

  /// <summary>
  ///  Instantiate turret on touched hexagon
  ///  @param {Transform} groundTrans Transform-object from touched hexagon
  /// </summary>
  public bool instantiateTurret(Transform groundTrans)
  {
    Debug.Log("inside instatiateTurret()");
    GameObject turretClone = turret;
    Debug.Log("after assigning turret to turretClone: " + turretClone.name);
    Debug.Log("turretClone != undefined: " + (turretClone).ToString());
    Vector3 pos = groundTrans.position;
    if (getPlayerMoney() - 20 >= 0)
    {
      ++turretCount;
      turretClone.name = "Turret " + turretCount;
      instantiatedTurret = Instantiate(turretClone, new Vector3(pos.x, pos.y + 0.1f, pos.z), groundTrans.rotation);
      //turretCount++;
      //instantiatedTurret.name = "Turret " + turretCount.ToString();
      meshRenderers = instantiatedTurret.GetComponentsInChildren<MeshRenderer>();
      foreach (MeshRenderer meshRenderer in meshRenderers)
      {
        meshRenderer.enabled = false;
      }
      Debug.Log("Placed turret with name: " + instantiatedTurret.name);
      isPlaced = true;
    }
    return isPlaced;
  }

  /// <summary>
  /// Check if NPCs path to destination is complete
  /// </summary>
  /// <returns>bool, true if path complete, false if not</returns>
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
        Debug.Log("NPC Path is not complete!");
        return false;
      }
    }
    Debug.Log("NPC Path is complete!");
    return true;
  }

  /// <summary>
  /// Adds amount to players current money
  /// </summary>
  /// <param name="amount">int, amount Amount that is added to players money, Standard: 10</param>
  public void ModifyPlayerMoney(int amount = 10)
  {
    Debug.Log("Adding " + amount + " to playerMoney");
    playerMoney += amount;
    GetComponent<UIManager>().showMoneyText(playerMoney);
  }

  public int getPlayerMoney()
  {
    return playerMoney;
  }

  public void handleSellTurret(string turretName)
  {
    Debug.Log("Deactivating " + turretName);
    GameObject.Find(turretName).SetActive(false);
    ModifyPlayerMoney(10);
  }

  public void handleUpgradeTurret(string turretName)
  {
    Debug.Log("Upgrading " + turretName);
    if (playerMoney - 20 >= 0)
    {
      ModifyPlayerMoney(-20);
    }
  }

  private void Update()
  {
    if (isPlaced)
      {
        if (!isNPCPathComplete())
        {
          //Debug.Log("Destroying Turret cause it is blocking NPC way");
         instantiatedTurret.SetActive(false);
        }
        else
        {
          //Debug.Log("Activating Turret");
          foreach (MeshRenderer meshRenderer in meshRenderers)
          {
            meshRenderer.enabled = true;
          }
          ModifyPlayerMoney(-20);
        }
        isPlaced = false;
      }
  }
}
