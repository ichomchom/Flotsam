using UnityEngine;
using System.Collections;

public class Octopus : MonoBehaviour 
{
    public float timer;
	public GameObject squid;
    public static int squidCount;
    public int sCount;
    public int squidCountMax;
		
	void Start()
	{
        squidCount = 0;
        squidCountMax = 10;
		timer = Random.Range (2, 10) + Time.time;
	}
	void Update()
    {
        if (squidCount < 0)
        {
            squidCount = 0;
        }
        sCount = squidCount;
		if (timer <= Time.time && squidCount <= squidCountMax)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-500, 500), 9, Random.Range(-500, 500));
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(squid, spawnPosition, spawnRotation);
            squidCount++;
            timer = Random.Range(2.0f, 10.0f) + Time.time;
        }
    }
}




