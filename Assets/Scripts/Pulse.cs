using UnityEngine;

/// <summary>
/// Sorgt für das Pulsieren der Türme
/// </summary>
public class Pulse : MonoBehaviour
{
    
  // adjust this to change speed of pulse
  [SerializeField]
  private float pulseSpeed = 2.5f;

  // adjust this to change speed of rotation
  [SerializeField]
  private float rotationSpeed = 50.0f;

  // adjust this to change how high it goes
  [SerializeField]
  private float pulseWidth = 1.25f;

  [SerializeField]
  private Vector3 scale;

  void Start()
  {
    scale = transform.localScale;
  }

  void Update()
  {
    // calculate what the new X and Z scale will be
    float newScale = Mathf.Sin(Time.time * pulseSpeed) * pulseWidth + scale.x;
    // set the object's X and Z to the new calculated Y
    if (newScale >= scale.x)
    {
        transform.localScale = new Vector3(newScale, scale.y, newScale);
    } else
    {
        newScale = ((scale.x-newScale)+scale.x);
        transform.localScale = new Vector3(newScale, scale.y, newScale);
    }
    
    transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f) * rotationSpeed * Time.deltaTime);
  }
}