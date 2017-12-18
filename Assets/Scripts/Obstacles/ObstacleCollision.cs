using UnityEngine;
using System.Collections;

public class ObstacleCollision : MonoBehaviour {

    private Vector3 playerPosition;
    private PlayerHealth playerHealth;
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flotsam") || other.CompareTag("CannonBall") )
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Player"))
        {
            playerHealth.TakeDamage(10);
            playerPosition = other.transform.position;
            other.transform.eulerAngles = new Vector3(0.0f, other.transform.eulerAngles.y + 180.0f, 0.0f);
        }
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = playerPosition;
        }
    }
}
