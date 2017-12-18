using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    private Rigidbody rb;
    private Light flash;
    private float stop;

    void Awake()
    {
        flash = GetComponent<Light>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.velocity = transform.forward * -20;
        rb.AddForce(0.0f, -(Random.Range(0.075f, 0.085f)), 0.0f);

        flash.enabled = false;
        flash.enabled = true;
        stop = Time.deltaTime + 0.5f;
    }

    void Update()
    {
        if (stop > Time.deltaTime)
        {
            flash.enabled = false;
        }
    }
}
