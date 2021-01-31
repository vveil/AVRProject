using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
  void Update()
  {
    for(int i = 0; i < Input.touchCount; ++i)
    {
      Touch touch = Input.GetTouch(i);
      if (touch.phase == TouchPhase.Began)
      {
        GameObject gameManager = GameObject.Find("GameManager");
        Debug.Log("Calling showTurretOptions from Turret.cs");
        gameManager.GetComponent<UIManager>().showTurretOptions(gameObject);
      }
    }
  }
}
