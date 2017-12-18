using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public bool isDead = false;
	public AudioSource damageSound;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (isDead)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
		damageSound.Play ();
        if (currentHealth <= 0 && isDead != true)
        {
            isDead = true;
            SpawnMover.enemyCount--;
            if (amount == 25)
            {
                ScoreManager.score += 200;
            }
        }
    }
}