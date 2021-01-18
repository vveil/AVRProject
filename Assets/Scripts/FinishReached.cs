using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishReached : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<UIManager>().GameLost();
        }
    }
}
