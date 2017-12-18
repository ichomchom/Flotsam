using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    private float nextFireTop = 0;
    private float nextFireBottom = 0;

    private AudioSource cannonAudio;
    private EnemyHealth enemyHealth;

    public GameObject shot;
    public Transform shotSpawnTop;
    public Transform shotSpawnBottom;

    private float timeOffset = .25f;

    void Awake()
    {
        cannonAudio = GetComponentInParent<AudioSource>();
        enemyHealth = GetComponentInParent<EnemyHealth>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && (enemyHealth.currentHealth > 0))
        {
            fireCannon();
        }
    }

    void fireCannon()
    {
        float fireRate = 0;
        float current_time = Time.time;

        if (current_time > nextFireTop)
        {
            Instantiate(shot, shotSpawnTop.position, shotSpawnTop.rotation);
            fireRate = Random.Range(1.75f, 2.5f);
            nextFireTop = current_time + fireRate;
            playCannonSound();
        }
        if (current_time > nextFireBottom)
        {
            Instantiate(shot, shotSpawnBottom.position, shotSpawnBottom.rotation);
            fireRate = Random.Range(1.75f, 2.5f);
            nextFireBottom = current_time + fireRate;
            playCannonSound();
        }
    }

    void playCannonSound()
    {
        cannonAudio.time = timeOffset * cannonAudio.clip.length;
        cannonAudio.Play();
    }
}
