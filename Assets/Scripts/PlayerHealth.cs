using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField]
  private int maxHealth = 100;

  private int currentHealth;

  public event Action<float> OnHealthPctChanged = delegate { };

  private void OnEnable()
  {
    currentHealth = maxHealth;
  }

  /**
   * Modify the players health
   * @param {Int} amount will be added to current health (pass negative value
   * to reduce currentHealth)
   * */
  public void ModifyHealth(int amount)
  {
    currentHealth += amount;

    float currentHealthPct = (float)currentHealth / (float)(maxHealth);
    OnHealthPctChanged(currentHealthPct);

    if(currentHealth <= 0)
    {
      GetComponent<UIManager>().GameLost();
    }
  }
}