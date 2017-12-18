using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public int flotsamMax;
    public Vector3 flotsamSpawnValues;
    public GameObject flotsam;

    public int scoreTracker;

    public static bool spawnTB;
    public static bool spawnLR;

    void Update()
    {
        if (ScoreManager.score > scoreTracker + 500)
        {
            flotsamMax--;
            SpawnMover.maxEnemyCount++;
            scoreTracker = ScoreManager.score;
        }
        if (PlayerCollision.max < flotsamMax)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-flotsamSpawnValues.x, flotsamSpawnValues.x), flotsamSpawnValues.y, Random.Range(-flotsamSpawnValues.z, flotsamSpawnValues.z));
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(flotsam, spawnPosition, spawnRotation);
            PlayerCollision.max++;
        }
    }
}
