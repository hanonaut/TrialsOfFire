using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAI : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    //Named this way for a specific reason
    public LayerMask playerShape, isTheGround;

    [SerializeField]
    private Transform targetPlayer;

    [SerializeField]
    private float patrolRange;

    [SerializeField]
    private float sightRange;

    bool walkPointSet;
    private Vector3 walkPoint;

    bool playerInSight;

	private void Awake()
	{
        agent = GetComponent<NavMeshAgent>();
	}


	// Start is called before the first frame update
	void Start()
    {
		targetPlayer = Player.Instance.transform;
	}

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerShape);

        if (!playerInSight)
        {
			Debug.Log("Commence Roaming");
			Roaming();
        }
        else{
            Debug.Log("Player spotted");

		}
    }

    private void Roaming() {
		Debug.Log("Is Roaming");
		if (!walkPointSet) ChooseLocation();

        if (walkPointSet) {
			walkPointSet = true;
            agent.SetDestination(walkPoint);
        
        };

        if ((transform.position - walkPoint).magnitude < 1f) walkPointSet = false;


	}

    private void ChooseLocation(){
        float randomX = Random.Range(-patrolRange, patrolRange);
		float randomZ = Random.Range(-patrolRange, patrolRange);
        Debug.Log("Testing");


        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
		agent.SetDestination(walkPoint);

	}

    //Visual degugging
	private void OnDrawGizmos()
	{
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        if (walkPointSet) {
			    Gizmos.DrawRay(walkPoint, -transform.up);
		}
		
	}
}
