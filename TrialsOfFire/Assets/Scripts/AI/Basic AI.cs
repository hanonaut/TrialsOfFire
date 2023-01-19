using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAI : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    //Named this way for a specific reason
    public LayerMask playerShape;

    [SerializeField]
    private Transform targetPlayer;

    [SerializeField]
    private float sightRange;

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
    }
}
