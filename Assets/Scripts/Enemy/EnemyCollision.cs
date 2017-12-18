using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

    private EnemyHealth enemyHealth;

   // public AudioSource cannonBallHitSound;
    public int damageDone;

    void Awake()
    {
        damageDone = 5;
        enemyHealth = GetComponentInParent<EnemyHealth>();
      //  cannonBallHitSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CannonBall"))
        {
            enemyHealth.TakeDamage(damageDone);
          //  cannonBallHitSound.Play();
            Destroy(other.gameObject, 0.25f * Time.deltaTime);
        }
        if (other.CompareTag("Player"))
        {
            enemyHealth.TakeDamage(50);
        }
    }

  /*  void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyHealth.TakeDamage(100);
        }
    } */
}
