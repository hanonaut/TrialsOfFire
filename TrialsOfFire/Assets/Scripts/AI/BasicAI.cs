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
			Roaming();
        }
        else{
            Debug.Log("Player spotted");
			agent.SetDestination(targetPlayer.position);
			agent.stoppingDistance = 4;

		}
    }

    private void Roaming() {
		Debug.Log("Is Roaming");
		if (!walkPointSet) ChooseLocation();

        if (walkPointSet) {
            agent.SetDestination(walkPoint);
            agent.stoppingDistance = 0;
        
        };

        if ((transform.position - walkPoint).magnitude < 1f) 
            walkPointSet = false;
	}

    private void ChooseLocation(){
        float randomX = Random.Range(-patrolRange, patrolRange);
		float randomZ = Random.Range(-patrolRange, patrolRange);
        Debug.Log("Testing");


        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
		agent.SetDestination(walkPoint);

        if(Physics.Raycast(walkPoint, -transform.up, isTheGround))
			walkPointSet = true;



	}

    //Visual degugging
	private void OnDrawGizmos()
	{
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sightRange);
		
	}
}
