using UnityEngine;

public class NPCHealth : MonoBehaviour
{
  [SerializeField]
  private int maxHealth = 20;

  private int currentHealth;

  private Renderer rend;

  public Color normalColor;

  private void Start()
  {
    currentHealth = maxHealth;
    rend = GetComponent<Renderer>();
    normalColor = rend.material.color;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Weapon")
    {
      currentHealth -= 1;
      float healthPct = (float)currentHealth / (float)maxHealth;
      if (currentHealth <= 0)
      {
        Destroy(gameObject);
        // TODO mit Waves muss das wo anders stehen, Game erst verloren wenn alle NPCs tot sind
        GameObject gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<GameManager>().ModifyPlayerMoney(10);
        gameManager.GetComponent<UIManager>().GameWon();
      } else if (healthPct > 0.5f)
      {
        rend.material.color = Color.green;
      } else if(healthPct > 0.25f)
      {
        rend.material.color = Color.yellow;
      } else
      {
        rend.material.color = Color.red;
      }
    }
  }
}
