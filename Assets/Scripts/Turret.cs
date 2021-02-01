using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Verwaltet Aktionen, die ausgeführt werden sollen wenn ein Turm ausgewählt wird
/// </summary>
public class Turret : MonoBehaviour
{

  [SerializeField]
  private int damage = 5;

  public Material upgradedMaterial;

  private bool isUpgraded = false;

  /// <summary>
  /// Wird bei Auswahl eines Turms aufgerufen. Ruft UI-Funktion zum Anzeigen von Upgrade/Sell-Möglichkeiten auf
  /// </summary>
  public void handleTurretOptions()
  {
    GameObject gameManager = GameObject.Find("GameManager");
    gameManager.GetComponent<UIManager>().showTurretOptions(gameObject.name, isUpgraded);
  }

  /// <summary>
  /// Erhöht den Schaden eines Turms auf 10
  /// </summary>
  public void Upgrade()
  {
    damage = 10;
    isUpgraded = true;
    GetComponentInChildren<MeshRenderer>().material = upgradedMaterial;
  }

  public int GetDamage()
  {
    return damage;
  }
}
