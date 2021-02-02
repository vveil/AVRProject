using UnityEngine;

/// <summary>
/// Verwaltet die Lebenspunkte der NPCs
/// </summary>
public class NPCHealth : MonoBehaviour
{
  [SerializeField]
  private int maxHealth = 6;

  private int currentHealth;

  private Renderer rend;

  private bool isTriggerActive = false;

  private void Awake()
  {
    currentHealth = maxHealth;
    rend = GetComponent<Renderer>();
  }

  /// <summary>
  /// Erhört die maximalen Lebenspunkte eines NPCs
  /// </summary>
  /// <param name="amount">Anzahl der zusätzlichen Lebenspunkte</param>
  public void boostNPC(int amount)
  {
    maxHealth += amount;
    currentHealth = maxHealth;
  }

  public int getCurrentHealth()
  {
    return currentHealth;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!isTriggerActive)
    {
      isTriggerActive = true;
      // if NPC collides with a weapon NPC gets damaged or dies
      if (other.gameObject.tag == "Weapon")
      {
        gameObject.GetComponent<AudioSource>().Play();
        currentHealth -= other.gameObject.GetComponentInParent<Turret>().GetDamage();
        float healthPct = (float)currentHealth / (float)maxHealth;
        if (currentHealth <= 0)
        {
          Destroy(gameObject);
          // TODO mit Waves muss das wo anders stehen, Game erst verloren wenn alle NPCs tot sind
          GameObject gameManager = GameObject.Find("GameManager");
          gameManager.GetComponent<GameManager>().ModifyPlayerMoney(10);
          gameManager.GetComponent<GameManager>().reduceNPC();
        }
        else if (healthPct > 0.5f)
        {
          // set NPC color to green if npcHealth is > 50%
          rend.material.color = Color.green;
        }
        else if (healthPct > 0.25f)
        {
          // set NPC color to yellow if npcHealth is between 50% - 25%
          rend.material.color = Color.yellow;
        }
        else
        {
          // set NPC color to red if npcHealth is between 25% - 0%
          rend.material.color = Color.red;
        }
      }
    }
  }

  private void OnTriggerExit(Collider other)
  {
    isTriggerActive = false;
  }
}
