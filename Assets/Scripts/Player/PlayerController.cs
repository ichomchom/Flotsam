using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private float nextPSFireTop = 0;
    private float nextPSFireBottom = 0;
    private float nextSBFireTop = 0;
    private float nextSBFireBottom = 0;

    private AudioSource cannonAudio;

    public float speed;
    public GameObject shot;
    public Transform shotSpawnPSTop;
    public Transform shotSpawnPSBottom;
    public Transform shotSpawnSBTop;
    public Transform shotSpawnSBBottom;

    private float timeOffset = .25f;

    void Awake()
    {
        cannonAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        fireCannon();
    }
	
	void FixedUpdate ()
    {
        float h = (Input.GetAxis("Horizontal"));
        float v = (Input.GetAxis("Vertical"));
        move(h, v);
	}

    void move(float moveHorizontal, float moveVertical)
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);          
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(2 * Time.deltaTime, 0.0f, 0.0f);
        }
        transform.Rotate(0.0f, moveHorizontal * 2, 0.0f);
    }

    void fireCannon()
    {
        float fireRate = 0;
        float current_time = Time.time;
        if (Input.GetButton("Fire1"))
        {
            if (current_time > nextPSFireTop)
            {
                Instantiate(shot, shotSpawnPSTop.position, shotSpawnPSTop.rotation);
                fireRate = Random.Range(0.75f, 1.5f);
                nextPSFireTop = current_time + fireRate;
                playCannonSound();
            }
            if (current_time > nextPSFireBottom)
            {
                Instantiate(shot, shotSpawnPSBottom.position, shotSpawnPSBottom.rotation);
                fireRate = Random.Range(1.75f, 2.5f);
                nextPSFireBottom = current_time + fireRate;
                playCannonSound();
            }
        }


        if (Input.GetButton("Fire2"))
        {
            if (current_time > nextSBFireTop)
            {
                Instantiate(shot, shotSpawnSBTop.position, shotSpawnSBTop.rotation);
                fireRate = Random.Range(1.0f, 1.75f);
                nextSBFireTop = current_time + fireRate;
                playCannonSound();
            }
            if (current_time > nextSBFireBottom)
            {
                Instantiate(shot, shotSpawnSBBottom.position, shotSpawnSBBottom.rotation);
                fireRate = Random.Range(1.75f, 2.00f);
                nextSBFireBottom = current_time + fireRate;
                playCannonSound();
            }
        }
    }

    void playCannonSound()
    {
        cannonAudio.time = timeOffset * cannonAudio.clip.length;
        cannonAudio.Play();
    }
}
