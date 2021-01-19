using UnityEngine;

public class Health : MonoBehaviour
{
  // Start is called before the first frame update
  public float lifePoints = 0.0f;

  public bool alive;
  Renderer rend;
  Color normalColor;

  void Start()
  {
    lifePoints = 10.0f;
    rend = GetComponent<Renderer>();
    normalColor = rend.material.color;
    alive = true;
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter(Collider other)
  {
    if (alive && other.gameObject.tag == "Weapon")
    {
      lifePoints = lifePoints - 1.0f;
      rend.material.color = Color.yellow;
      if (lifePoints == 0)
      {
        rend.enabled = false;
        alive = rend.isVisible;
        GameObject gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<UIManager>().GameWon();
      }
    }
  }
  private void OnTriggerExit(Collider other)
  {
      if (alive)
      {
          rend.material.color = normalColor;
      } else
      {
          rend.material.color = Color.black;
      }
  }
}
