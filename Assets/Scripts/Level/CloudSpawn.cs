using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour {


	public GameObject[] randomObject;
	public int maxCloudCount;
	public int  cloudCount;
    public static int maxCloudCountStatic;
    public static int cloudCountStatic;

    private float spawnRate;

    void Awake()
    {
        maxCloudCountStatic = maxCloudCount;
        cloudCountStatic = cloudCount;
        for (int i = 0; i < 50; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-500, 500), 50, Random.Range(-500, 500));
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(randomObject[Random.Range(0, 2)], spawnPosition, spawnRotation);
        }
        spawnRate = Random.Range(0f, 2.5f);
    }

	void FixedUpdate()
    {
        if (cloudCountStatic < 0)
        {
            cloudCountStatic = 50;
        }
        maxCloudCount = maxCloudCountStatic;
        cloudCount = cloudCountStatic;

        if (cloudCountStatic < maxCloudCountStatic && spawnRate <= 0)
        {
            Vector3 spawnPosition = new Vector3(-600, 50, Random.Range(-500, 500));
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(randomObject[Random.Range(0, 2)], spawnPosition, spawnRotation);
            cloudCountStatic++;
            spawnRate = Random.Range(0f, 4f);
        }
        spawnRate -= Time.deltaTime;
    }
}