using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    private bool isTurretActive = false;

  //adjust this to change speed
  public float speedswing = 2.5f;
  public float speedrotate = 20.0f;

  //adjust this to change how high it goes
  public float height = 0.025f;

  Vector3 pos;


  // Start is called before the first frame update
  void Start()
  {
    pos = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    //calculate what the new Y position will be
    float newY = Mathf.Sin(Time.time * speedswing) * height + pos.y;
    //set the object's Y to the new calculated Y
    transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f) * speedrotate * Time.deltaTime);
        if (!isTurretActive)
        {
                GameObject gameManager = GameObject.Find("GameManager");
                gameManager.GetComponent<GameManager>().instantiateTurret(transform);
                isTurretActive = true;
        }
    }
}