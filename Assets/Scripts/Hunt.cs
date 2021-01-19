using UnityEngine;
using UnityEngine.AI;

public class Hunt : MonoBehaviour
{
  public GameObject target;
  private NavMeshAgent agent;
  public bool paused = false;
  public float speed = 0.5f;
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
    }
    else
    {
      agent.SetDestination(target.transform.position);
      agent.speed = speed;
    }
  }
}
