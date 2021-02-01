using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Verwaltet alle UI Elemente während des Spiels
/// </summary>
public class UIManager : MonoBehaviour
{
  // UI-Elemente die im Inspektor zugewiesen werden müssen
  public Button startButton;
  public Image startImage;
  public Button helpButton;
  public GameObject startText;
  public Image helpTextBackground;
  public GameObject helpText;
  public GameObject playerMoneyText;
  public GameObject gameOverText;
  public GameObject gameWonText;
  public Image playerHealthForeground;
  public GameObject healthUI;
  public GameObject towerOptions;
  public Button upgradeTower;
  public Button sellTower;
  public Button cancelButton;
  public GameObject waveTimer;

  private void Awake()
  {
    GetComponent<PlayerHealth>().OnHealthPctChanged += HandleHealthChanged;
  }

  private void OnEnable()
  {
    Time.timeScale = 0f;
    startButton.gameObject.SetActive(true);
    startButton.onClick.AddListener(StartGame);
    startText.SetActive(true);
    startImage.gameObject.SetActive(true);
  }

  /// <summary>
  /// Verwaltet UI bei App-Start.
  /// </summary>
  private void StartGame()
  {
    Time.timeScale = 1f;
    startButton.gameObject.SetActive(false);
    startText.SetActive(false);
    startImage.gameObject.SetActive(false);

    helpButton.gameObject.SetActive(true);
    helpButton.onClick.AddListener(ToggleHelp);

    healthUI.SetActive(true);
    waveTimer.SetActive(true);

    showMoneyText(GetComponent<GameManager>().getPlayerMoney());
    GameObject.Find("GameManager").GetComponent<GameManager>().startGame();
  }

  /// <summary>
  /// Togglet Sichtbarkeit der Hilfe
  /// </summary>
  private void ToggleHelp()
  {
    helpTextBackground.gameObject.SetActive(!helpTextBackground.gameObject.activeSelf);
    helpText.SetActive(!helpText.activeSelf);
  }

  /// <summary>
  /// Handelt UI wenn Spieler verloren hat
  /// </summary>
  public void GameLost()
  {
    disableGameUI();
    Time.timeScale = 0f;
    gameOverText.SetActive(true);
  }

  /// <summary>
  /// Handelt UI wenn Spieler gewonnen hat
  /// </summary>
  public void GameWon()
  {
    disableGameUI();
    Time.timeScale = 0f;
    gameWonText.SetActive(true);
  }

  /// <summary>
  /// Sorgt fürs Anzeigen der Münzen des Spielers
  /// </summary>
  public void showMoneyText(int money)
  {
    string coinsString = "Coins: " + money;
    playerMoneyText.GetComponent<Text>().text = coinsString;
    playerMoneyText.SetActive(true);
  }

  /// <summary>
  /// Deaktiviert die in-game UI
  /// </summary>
  private void disableGameUI()
  {
    playerMoneyText.SetActive(false);
    helpButton.gameObject.SetActive(false);
    helpText.SetActive(false);
    healthUI.SetActive(false);
    waveTimer.SetActive(false);
  }

  /// <summary>
  /// Handelt das Anzeigen der Optionen bei Touch auf einen Turm
  /// </summary>
  /// <param name="turretName">Name des Turms</param>
  /// <param name="isUpgraded">bool: true -> Turm bereits upgraded; false-> Turm noch nicht upgraded</param>
  public void showTurretOptions(string turretName, bool isUpgraded)
  {
    upgradeTower.onClick.RemoveAllListeners();
    sellTower.onClick.RemoveAllListeners();
    cancelButton.onClick.RemoveAllListeners();
    upgradeTower.onClick.AddListener(() =>
    {
      GetComponent<GameManager>().handleUpgradeTurret(turretName);
      hideTurretOptions();
    });
    sellTower.onClick.AddListener(() =>
    {
      GetComponent<GameManager>().handleSellTurret(turretName);
      hideTurretOptions();
    });
    cancelButton.onClick.AddListener(hideTurretOptions);
    towerOptions.SetActive(true);
    // hide upgrade button if tower is already upgraded
    upgradeTower.gameObject.SetActive(!isUpgraded);
  }

  /// <summary>
  /// Sorgt für das Deaktvieren der Upgrade/Sell-Optionen der Türme
  /// </summary>
  private void hideTurretOptions()
  {
    towerOptions.SetActive(false);
  }

  /// <summary>
  /// Handle the changes of playerHealth in the UI
  /// </summary>
  /// <param name="pct">maxHealth des Spielers / currentHealth des Spielers</param>
  private void HandleHealthChanged(float pct)
  {
    playerHealthForeground.fillAmount = pct;
  }

  /// <summary>
  /// Sorgt für das Aktualisieren des Timers zum Start der nächsten Wave
  /// </summary>
  /// <param name="current">Aktueller Timer</param>
  public void updateTimer(int current)
  {
    waveTimer.GetComponent<Text>().text = "Nächste Wave in: " + current + " Sekunden";
  }
}
