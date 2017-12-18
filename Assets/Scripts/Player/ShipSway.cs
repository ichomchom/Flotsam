using UnityEngine;
using System.Collections;

public class ShipSway : MonoBehaviour {

    public float speed = .04f;

    void Update () {
        if ( transform.rotation.x >= 2)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(-2, transform.rotation.y, transform.rotation.z, transform.rotation.w), Time.deltaTime * speed);
        }
        else if (transform.rotation.x <= -2)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(2, transform.rotation.y, transform.rotation.z, transform.rotation.w), Time.deltaTime * speed);
        }
    }
}
