using UnityEngine;
using System.Collections;

public class FlotsamMover : MonoBehaviour
{
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.position.y < 0.0f)
        {
            transform.Translate(0.0f, 1.0f * Time.deltaTime * 2.5f, 0.0f);
        }
    }
}
