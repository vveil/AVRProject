using UnityEngine;

public class Pulse : MonoBehaviour
{
    
  //adjust this to change speed
  public float speedpulse = 2.5f;
  public float speedrotate = 50.0f;

  //adjust this to change how high it goes
  public float pulsewidth = 1.25f;

  Vector3 scale;


  // Start is called before the first frame update
  void Start()
  {
    scale = transform.localScale;
  }

  // Update is called once per frame
  void Update()
  {
    //calculate what the new X and Z scale will be
    float newScale = Mathf.Sin(Time.time * speedpulse) * pulsewidth + scale.x;
    //set the object's X and Z to the new calculated Y
    if (newScale>=scale.x)
    {
        transform.localScale = new Vector3(newScale, scale.y, newScale);
    } else
    {
        newScale = ((scale.x-newScale)+scale.x);
        transform.localScale = new Vector3(newScale, scale.y, newScale);
    }
    //Rotate the object
    transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f) * speedrotate * Time.deltaTime);
  }
}