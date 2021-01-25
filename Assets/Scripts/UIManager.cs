using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.AR;

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
        // if (GameObject.FindWithTag("Game").GetComponent<ARPlacementInteractable>().placementPrefab == null)
        // {
        //     GameObject.Find("Debug").GetComponent<Text>().text = "null";
        // }
    }

    private void ToggleHelp()
    {
        helpText.SetActive(!helpText.activeSelf);
    }

    public void GameLost()
    {
        Time.timeScale = 0f;
        restartButton.onClick.AddListener(RestartGame);
        restartButton.gameObject.SetActive(true);
        gameOverText.SetActive(true);
    }

    public void GameWon()
    {
        Time.timeScale = 0f;
        restartButton.onClick.AddListener(RestartGame);
        restartButton.gameObject.SetActive(true);
        gameWonText.SetActive(true);
    }

    private void RestartGame()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        foreach (var tower in towers)
        {
            Destroy(tower);
        }
        // Destroy(GameObject.FindGameObjectWithTag("Level"));
        restartButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        gameOverText.SetActive(false);
        gameWonText.SetActive(false);
        startText.SetActive(true);
        GameObject.FindWithTag("GameSessionOrigin").GetComponent<AddReferencePoint>().ResetGame();
    }

    public void showMoneyText(int money)
    {
        Text moneyText = playerMoneyText.GetComponent<Text>();
        moneyText.text = "Coins: " + money;
    }
}
