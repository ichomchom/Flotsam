using UnityEngine;
using System.Collections;

public class SpawnMover : MonoBehaviour {

    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;
    private Vector3 pos4;
    public float speed = 1.0f;
    public GameObject enemy;
    public int sliderRange;

    public static int enemyCount;
    public static int maxEnemyCount;

    void Awake()
    {
        pos1 = new Vector3(transform.position.x, 0, sliderRange);
        pos2 = new Vector3(transform.position.x, 0, -sliderRange);
        pos3 = new Vector3(sliderRange, 0, transform.position.z);
        pos4 = new Vector3(-sliderRange, 0, transform.position.z);

        maxEnemyCount = 25;
        enemyCount = 0;
    }

    void Update()
    {
        if (transform.position.x == 500 || transform.position.x == -500)
        {
            transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
        }
        else
        {
            transform.position = Vector3.Lerp(pos3, pos4, Mathf.PingPong(Time.time * speed, 1.0f));
        }

        if (enemyCount < maxEnemyCount)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            enemyCount++;
        }
    }
}   
