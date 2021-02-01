using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Verwaltet Aktionen, die bei Auswahl eines Ground-Objekts ausgeführt werden sollen
/// </summary>
public class Selection : MonoBehaviour
{
  private bool isTurretActive = false;

  // adjust this to change speed of swing
  [SerializeField]
  private float swingSpeed = 2.5f;

  // adjust this to change speed of rotation
  [SerializeField]
  private float rotationSpeed = 20.0f;

  // adjust this to change how high it goes
  [SerializeField]
  private float height = 0.025f;

  //private GameObject instantiatedTurret;

  private Vector3 pos;

  private void Start()
  {
    pos = transform.position;
  }

  private void LateUpdate()
  {
    // calculate what the new Y position will be
    float newY = Mathf.Sin(Time.time * swingSpeed) * height + pos.y;
    // set the object's Y to the new calculated Y
    transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f) * rotationSpeed * Time.deltaTime);
    GameObject gameManager = GameObject.Find("GameManager");
    if (!isTurretActive)
    {
      isTurretActive = gameManager.GetComponent<GameManager>().instantiateTurret(transform);
    }
  }
}