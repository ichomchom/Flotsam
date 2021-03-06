using UnityEngine;
using System.Collections;

public class AINavigation : MonoBehaviour 
{
	private GameObject[] objects;
	private int points;
	private Transform loc;
	private NavMeshAgent agent;
    private EnemyHealth enemyHealth;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponentInChildren<EnemyHealth>();
    }

	void Start () 
	{
		objects = GameObject.FindGameObjectsWithTag ("PatrolPoint");
		points = Random.Range(0, objects.Length);
		loc = objects [points].transform;
		agent.SetDestination (loc.position);
		agent.autoBraking = false;
	}
		
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PatrolPoint" && enemyHealth.currentHealth > 0) 
		{
			points += 1;
			if (points >= objects.Length) 
			{
				points = 0;
			}
			loc = objects [points].transform;
			agent.destination = loc.position;
		}
	}
}
