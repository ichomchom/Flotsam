using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    private PlayerController playerController;
    private BoxCollider playerBoxCollider;
    private GameObject player;
	public AudioSource damageSound;
	public AudioSource pickupSound;

    public int startingHealth = 100;
    public int currentHealth;
    public bool isDead = false;
    public Slider healthSlider;
	public float timer = 2.5f;

    void Awake()
    {
        playerBoxCollider = GetComponent<BoxCollider>();
        playerController = GetComponent<PlayerController>();
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (isDead)
        {
            Quaternion sinkAnim = new Quaternion(transform.rotation.x, transform.rotation.y, 45.0f, 1.0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, sinkAnim, Time.deltaTime * .05f);
			timer -= Time.deltaTime;
			if (timer < 0) {
				SceneManager.LoadScene ("Death");
			}
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
		damageSound.Play ();
        if (currentHealth <= 0 && isDead != true)
        {
            Death();
        }
    }

	public void GainHealth(int amount)
	{
		currentHealth += amount;
		healthSlider.value = currentHealth;
		if (currentHealth > 100)
		{
			currentHealth = 100;
			healthSlider.value = currentHealth;
		}
		pickupSound.Play ();
	}

    void Death()
    {
        playerBoxCollider.enabled = false;
        isDead = true;
        playerController.enabled = false;
    }

}
