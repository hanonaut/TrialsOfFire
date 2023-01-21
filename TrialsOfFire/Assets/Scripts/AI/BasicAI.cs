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
        targetPlayer = Player.Instance.transform;
        agent = GetComponent<NavMeshAgent>();
	}


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerShape);

        if (playerInSight) Roaming();
    }

    private void Roaming() {
        if (!walkPointSet) ChooseLocation();

        if (walkPointSet) agent.SetDestination(walkPoint);

        if ((transform.position - walkPoint).magnitude < 1f) walkPointSet = false;


	}

    private void ChooseLocation(){
        float randomX = Random.Range(-patrolRange, patrolRange);
		float randomZ = Random.Range(-patrolRange, patrolRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if(Physics.Raycast(walkPoint, -transform.up, 2f, isTheGround)) walkPointSet = true;

	}
}
