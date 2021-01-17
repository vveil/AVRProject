using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{

  //adjust this to change speed
  public float speed = 5.0f;

  //adjust this to change how high it goes
  public float height = 0.0125f;

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
    float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
    //set the object's Y to the new calculated Y
    transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    // transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f) * speed * Time.deltaTime);
  }
}