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
  private GameObject npc;

  [SerializeField]
  private int playerMoney = 100;

  [SerializeField]
  private int npcCount = 5;

  [SerializeField]
  private int npcBoostAmount = 50;

  private int npcAlive = 0;

  [SerializeField]
  private int waveCount = 4;

  [SerializeField]
  private bool waveActive = false;

  [SerializeField]
  private int waveWaitTimer = 20;
  private bool gameIsStarted = false;

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

  /// <summary>
  /// Verwaltet das Verkaufen von Türmen
  /// </summary>
  /// <param name="turretName">Name des zu verkaufenden Turms</param>
  public void handleSellTurret(string turretName)
  {
    GameObject.Find(turretName).SetActive(false);
    ModifyPlayerMoney(10);
  }

  /// <summary>
  /// Verwaltete das Upgraden von Türmen
  /// </summary>
  /// <param name="turretName">Name des upzugradenen Turms</param>
  public void handleUpgradeTurret(string turretName)
  {
    Debug.Log("Upgrading " + turretName);
    if (playerMoney - 20 >= 0)
    {
      GameObject.Find(turretName).GetComponent<Turret>().Upgrade();
      ModifyPlayerMoney(-20);
    }
  }

  /// <summary>
  /// set startGame to true
  /// </summary>
  public void startGame()
  {
    gameIsStarted = true;
  }

  /// <summary>
  /// Kontrolliert und verwaltet die verschiedenen Waves
  /// </summary>
  public void waveControl()
  {
    if (waveActive)
    {
      return;
    }
    else
    {
      if (npcAlive > 0)
      {
        return;
      }
      else
      {
        if (waveCount <= 0 && GetComponent<PlayerHealth>().getCurrentHealth() > 0)
        {
          GetComponent<UIManager>().GameWon();
          return;
        }
        waveActive = true;
        StartCoroutine(waveTimer(waveWaitTimer));
      }
    }
  }

  /// <summary>
  /// Verwaletet den Timer zur nächsten Wave
  /// </summary>
  /// <param name="timer">Aktueller Timer</param>
  /// <returns>Zu wartende Sekunden</returns>
  IEnumerator waveTimer(int timer)
  {
    while (timer > 0)
    {
      timer--;
      GetComponent<UIManager>().updateTimer(timer);
      yield return new WaitForSeconds(1);
    }
    StartCoroutine(spawnNPC(npcCount));
  }

  /// <summary>
  /// Ruft in regelmäígen Abständen placeNPC() auf um einen NPC zu erzeugen
  /// </summary>
  /// <param name="count">Anzahl der noch zu setzenden NPCs</param>
  /// <returns></returns>
  IEnumerator spawnNPC(int count)
  {
    npcAlive = 0;
    while (count > 0)
    {
      count--;
      placeNPC();
      yield return new WaitForSeconds(2);
    }
    waveCount--;
    waveActive = false;
  }

  /// <summary>
  /// Verwaltet das Setzen eines NPCs
  /// </summary>
  public void placeNPC()
  {
    GameObject start = GameObject.FindGameObjectWithTag("Start");
    Transform trans = start.transform;
    Vector3 pos = trans.position;
    GameObject temp = Instantiate(npc, new Vector3(pos.x, pos.y + 0.1f, pos.z), trans.rotation);
    npcBoostAmount = 12 / waveCount * 2;
    Debug.Log("BoostAmount: " + npcBoostAmount);
    temp.GetComponent<NPCHealth>().boostNPC(npcBoostAmount);
    npcAlive++;
    Debug.Log("Neuer Gegner betritt das Feld! Mit: " + temp.GetComponent<NPCHealth>().getCurrentHealth() + " Lebenspunkten");
    Debug.Log("Aktuell: " + npcAlive + " Gegner am leben.");
  }

  /// <summary>
  /// Reduziert die Anzahl der lebenden NPCs (aufrufen, wenn NPC zerstört oder im Ziel)
  /// </summary>
  public void reduceNPC()
  {
    npcAlive--;
  }

  private void Update()
  {
    // map place
    if (gameIsStarted)
    {
      waveControl();
    }

    if (isPlaced)
    {
      if (!isNPCPathComplete())
      {
        instantiatedTurret.SetActive(false);
      }
      else
      {
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
