using UnityEngine;
using System.Collections;

public class SquidControl : MonoBehaviour
{
    Transform player;               
    PlayerHealth playerHealth;     
    NavMeshAgent nav;

    public float timeAlive;      

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        nav = GetComponent<NavMeshAgent>();
        timeAlive = 20.0f;
        nav.enabled = false;
    }

    void Update()
    {
        if (timeAlive < 0)
        {
            Octopus.squidCount--;
            Destroy(this.gameObject);
        }
        if (playerHealth.currentHealth > 0 && nav.enabled == true)
        {
            nav.SetDestination(player.position);
        }
        timeAlive -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nav.enabled = true;
        }
    }
}