using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class DestroyByBoundary : MonoBehaviour
{
    public Boundary boundary;

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 objectPosition = new Vector3(other.transform.position.x, 0.0f, other.transform.position.z);
            if (other.transform.position.x > boundary.xMax || other.transform.position.x < boundary.xMin)
            {
                objectPosition.z *= -1.0f;
                other.transform.position = objectPosition;
            }
            if (other.transform.position.z > boundary.zMax || other.transform.position.z < boundary.zMin)
            {
                objectPosition.x *= -1.0f;
                other.transform.position = objectPosition;
            }
        }
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            SpawnMover.enemyCount--;
        }
    }
}
