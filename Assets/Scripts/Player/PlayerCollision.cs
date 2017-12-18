using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{

    public static int max;
    public int damageDone;
    public AudioSource flotsamPickUpSound;
    public AudioSource cannonBallHitSound;
    private PlayerHealth playerHealth;

    void Awake()
    {
        damageDone = 15;
        playerHealth = GetComponent<PlayerHealth>();
        flotsamPickUpSound = GetComponent<AudioSource>();
        cannonBallHitSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flotsam"))
        {
			playerHealth.GainHealth (10);
            Destroy(other.gameObject);
            ScoreManager.score += 100;
            max--;
        }
        if (other.CompareTag("CannonBall"))
        {
            playerHealth.TakeDamage(damageDone);
            cannonBallHitSound.Play();
            Destroy(other.gameObject, 0.25f * Time.deltaTime);

        }
        if (other.CompareTag("Enemy"))
        {
            playerHealth.TakeDamage(15);
        }
    }
}