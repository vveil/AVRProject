using UnityEngine;
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

  private void Update()
  {
    if (isPaused)
    {
      agent.isStopped = true;
    }
    else
    {
      agent.isStopped = false;
      agent.SetDestination(target.transform.position);
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    // reduce playerHealth if NPC reaches finish
    if (other.gameObject.tag == "Finish")
    {
      GameObject gameManager = GameObject.Find("GameManager");
      gameManager.GetComponent<PlayerHealth>().ModifyHealth(-1);
    }
  }

  public GameObject GetTarget()
  {
    return target;
  }
}
