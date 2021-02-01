using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Verwaltet Aktionen, die ausgeführt werden sollen wenn ein Turm ausgewählt wird
/// </summary>
public class Turret : MonoBehaviour
{
  public void handleTurretOptions()
  {
    GameObject gameManager = GameObject.Find("GameManager");
    Debug.Log("Calling showTurretOptions from " + gameObject.name);
    gameManager.GetComponent<UIManager>().showTurretOptions(gameObject.name);
  }
}
