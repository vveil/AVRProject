using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

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

  private void ToggleHelp()
  {
    helpText.SetActive(!helpText.activeSelf);
  }

  public void GameLost()
  {
    disableGameUI();
    Time.timeScale = 0f;
    restartButton.onClick.AddListener(RestartGame);
    restartButton.gameObject.SetActive(true);
    gameOverText.SetActive(true);
  }

  public void GameWon()
  {
    // TODO Call this function when all NPC are dead!
    disableGameUI();
    Time.timeScale = 0f;
    restartButton.onClick.AddListener(RestartGame);
    restartButton.gameObject.SetActive(true);
    gameWonText.SetActive(true);
  }

  private void RestartGame()
  {
    // Restart game somehow
  }

  public void showMoneyText(int money)
  {
    playerMoneyText.SetActive(true);
    Text moneyText = playerMoneyText.GetComponent<Text>();
    moneyText.text = "Coins: " + money.ToString();
  }

  private void disableGameUI()
  {
    playerMoneyText.SetActive(false);
    helpButton.gameObject.SetActive(false);
    helpText.SetActive(false);
    healthUI.SetActive(false);
  }

  private void HandleHealthChanged(float pct)
  {
    playerHealthForeground.fillAmount = pct;
  }
}
