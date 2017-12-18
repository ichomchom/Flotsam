using UnityEngine;
using System.Collections;

public class CloudMover : MonoBehaviour {

    public int speed;
    float deleteTime;

    void Awake()
    {
        deleteTime = Time.time + 420;
    }

	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (deleteTime < Time.time)
        {
            Destroy(this.gameObject);
            CloudSpawn.cloudCountStatic--;
        }
	}
}
