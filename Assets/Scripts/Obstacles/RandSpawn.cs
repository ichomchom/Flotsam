using UnityEngine;
using System.Collections;

public class RandSpawn : MonoBehaviour 
{
	
	public GameObject randomObject;
	public bool isCreated = false;

	public int maxSpawn;
	public int minSpawn;

	void FixedUpdate(){


		if (minSpawn < maxSpawn) 
		{
			Vector3 spawnPosition = new Vector3 (Random.Range (-90, 90), 0, Random.Range (-90, 90));
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (randomObject, spawnPosition, spawnRotation);
			minSpawn++;
		}

	}

}