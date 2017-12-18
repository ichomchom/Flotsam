using UnityEngine;
using System.Collections;

public class Flying : MonoBehaviour {

	public float horizontalSpeed = -0.01f;
	public float verticalSpeed=1;
	public float amplitude=1;

	public Vector3 tempPos;

	void Start () {
		transform.position = tempPos;

	}
	
	void FixedUpdate(){
		//horizontalSpeed = Random.Range (-0.09f, 0.09f);
		tempPos.x += horizontalSpeed;
		tempPos.y = Mathf.Sin (Time.realtimeSinceStartup + verticalSpeed) * amplitude;
	
	
	}
}
