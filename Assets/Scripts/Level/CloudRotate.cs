using UnityEngine;
using System.Collections;

public class CloudRotate : MonoBehaviour
{
    public Transform target;


    void Update()
    {
        transform.RotateAround(target.position, Vector3.up, 20 * Time.deltaTime);
    }
}