using System;
using UnityEngine;

/// <summary>
/// Verwaltet Lebenspunkte des Spielers
/// </summary>
public class PlayerHealth : MonoBehaviour
{
  [SerializeField]
  private int maxHealth = 10;

  private int currentHealth;

  public event Action<float> OnHealthPctChanged = delegate { };

  private void OnEnable()
  {
    currentHealth = maxHealth;
  }

  /// <summary>
  /// Modify the players health
  /// </summary>
  /// <param name="amount"> will be added to current health</param>
  public void ModifyHealth(int amount)
  {
    currentHealth += amount;

    float currentHealthPct = (float)currentHealth / (float)(maxHealth);
    OnHealthPctChanged(currentHealthPct);

    if (currentHealth <= 0)
    {
      GetComponent<UIManager>().GameLost();
    }
  }

  public int getCurrentHealth () {
    return currentHealth;
  }
}