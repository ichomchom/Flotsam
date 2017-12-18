using UnityEngine;
using System.Collections;

public class FailSafe : MonoBehaviour
{
    private Vector3 returnToStart;

    void Awake()
    {
        returnToStart = new Vector3(0, 0, 0);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            SpawnMover.enemyCount--;
        }
        other.transform.position = returnToStart;
    }
}
