using UnityEngine;

public class NPCHealth : MonoBehaviour
{
  [SerializeField]
  private int maxHealth = 20;

  private int currentHealth;

  private Renderer rend;

  private void Start()
  {
    currentHealth = maxHealth;
    rend = GetComponent<Renderer>();
  }

  private void OnTriggerEnter(Collider other)
  {
    // if NPC collides with a weapon NPC gets damaged or dies
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
        // set NPC color to green if npcHealth is > 50%
        rend.material.color = Color.green;
      } else if(healthPct > 0.25f)
      {
        // set NPC color to yellow if npcHealth is between 50% - 25%
        rend.material.color = Color.yellow;
      } else
      {
        // set NPC color to red if npcHealth is between 25% - 0%
        rend.material.color = Color.red;
      }
    }
  }
}
