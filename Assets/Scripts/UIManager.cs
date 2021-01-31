using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
  // UI-Elements to be assigned through the inspector
  public Button startButton;
  public Button helpButton;
  public GameObject startText;
  public GameObject helpText;
  public GameObject playerMoneyText;
  public Button restartButton;
  public GameObject gameOverText;
  public GameObject gameWonText;
  public Image playerHealthForeground;
  public GameObject healthUI;
  public GameObject towerOptions;
  public Button upgradeTower;
  public Button sellTower;
  public Button cancelButton;

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
  }

  /**
   * Handling UI when app is started. Activating "Start UI"
   */
  private void StartGame()
  {
    Time.timeScale = 1f;
    startButton.gameObject.SetActive(false);
    startText.SetActive(false);

    helpButton.gameObject.SetActive(true);
    helpButton.onClick.AddListener(ToggleHelp);

    healthUI.SetActive(true);

    showMoneyText(GetComponent<GameManager>().getPlayerMoney());
  }

  /**
   * Toggling visibilty of helpText
   */
  private void ToggleHelp()
  {
    helpText.SetActive(!helpText.activeSelf);
  }

  /**
   * Handling UI when game is lost
   */
  public void GameLost()
  {
    disableGameUI();
    Time.timeScale = 0f;
    //restartButton.onClick.AddListener(RestartGame);
    restartButton.gameObject.SetActive(true);
    gameOverText.SetActive(true);
  }

  /*
   * Handling UI when game is won
   */
  public void GameWon()
  {
    // TODO Call this function when all NPC are dead!
    disableGameUI();
    Time.timeScale = 0f;
    //restartButton.onClick.AddListener(RestartGame);
    restartButton.gameObject.SetActive(true);
    gameWonText.SetActive(true);
  }

  // TODO delete this function is its not used
  //private void RestartGame()
  //{
  //  // Restart game somehow
  //}

  /*
   * Make playerMoney visible in the UI
   */
  public void showMoneyText(int money)
  {
    string coinsString = "Coins: " + money;
    playerMoneyText.GetComponent<Text>().text = coinsString;
    playerMoneyText.SetActive(true);
  }

  /*
   * Disable the In-game UI
   */
  private void disableGameUI()
  {
    playerMoneyText.SetActive(false);
    helpButton.gameObject.SetActive(false);
    helpText.SetActive(false);
    healthUI.SetActive(false);
  }

  public void showTurretOptions(GameObject turret)
  {
    Debug.Log("Showing turret options");
    upgradeTower.onClick.AddListener(() =>
    {
      GetComponent<GameManager>().handleUpgradeTurret(turret);
      hideTurretOptions();
    });
    sellTower.onClick.AddListener(() =>
    {
      GetComponent<GameManager>().handleSellTurret(turret);
      hideTurretOptions();
    });
    cancelButton.onClick.AddListener(hideTurretOptions);
    towerOptions.SetActive(true);
  }

  private void hideTurretOptions()
  {
    Debug.Log("Hiding turret options");
    towerOptions.SetActive(false);
  }

  /*
   * Handle the changes of playerHealth in the UI
   */
  private void HandleHealthChanged(float pct)
  {
    playerHealthForeground.fillAmount = pct;
  }
}
