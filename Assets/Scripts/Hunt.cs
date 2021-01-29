﻿using UnityEngine;
using UnityEngine.AI;

public class Hunt : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField]
    private bool isPaused = false;

    public GameObject target;
  
  private void Start()
  {
    agent = gameObject.GetComponent<NavMeshAgent>();
  }

  // Update is called once per frame
  private void Update()
  {
    if (isPaused)
        {
            agent.isStopped = true;
    } else {
      agent.isStopped = false;
      agent.SetDestination(target.transform.position);
    }
  }

  public GameObject GetTarget()
  {
    return target;
  }
}
