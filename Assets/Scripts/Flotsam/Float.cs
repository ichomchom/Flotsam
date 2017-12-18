using UnityEngine;
using System.Collections;

public class Float : MonoBehaviour {

	public float degreePerSecond = 5f;
	public float amlitude = 0.5f;
	public float frequency = 0.4f;
	public float timer = 2.2f;


	Vector3 posOffset = new Vector3();
	Vector3 tempPos = new Vector3();


	void Start()
	{
		posOffset = transform.localPosition + new Vector3(0.0f, 5.4f,0.0f);	
	}
	void Update()
	{
		timer -= Time.deltaTime;
		if (timer < 0) {
			transform.Rotate (new Vector3 (0f,Time.deltaTime*Random.Range(-90.0f,90.0f), 0f));

			tempPos = posOffset;
			tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amlitude;

			transform.position = tempPos;
		}
	}


}
