using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hunt : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    public bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            agent.speed = 0;
        } else if(agent.transform.position == target.transform.position)
        {
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<UIManager>().GameLost();
        }
        else {
            agent.SetDestination(target.transform.position);
            // agent.speed = 5;
        }
    }
}
