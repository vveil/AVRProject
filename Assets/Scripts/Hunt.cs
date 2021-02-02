using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Sorgt dafür, dass NPCs zum Ziel laufen
/// </summary>
public class Hunt : MonoBehaviour
{
  private NavMeshAgent agent;

  [SerializeField]
  private bool isPaused = false;

  [SerializeField]
  private GameObject target;

  private void Start()
  {
    agent = gameObject.GetComponent<NavMeshAgent>();
    target = GameObject.FindGameObjectWithTag("Finish");
    agent.SetDestination(target.transform.position);
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
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    // reduce playerHealth if NPC reaches finish
    if (other.gameObject.tag == "Finish")
    {
      GameObject gameManager = GameObject.Find("GameManager");
      gameManager.GetComponent<PlayerHealth>().ModifyHealth(-1);
      gameManager.GetComponent<GameManager>().reduceNPC();
      Destroy(gameObject);
    }
  }

  public GameObject GetTarget()
  {
    return target;
  }
}
