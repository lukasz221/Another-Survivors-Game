using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float navMeshSampleDistance = 5f;
    [SerializeField] private float spawnRadius = 20f;

    GameObject player;

    public List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(playerPrefab, new Vector3(0, 1, 0), Quaternion.identity);

        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (enemies.Count < 100)
        {
            float angle = Random.Range(0, Mathf.PI * 2);
            Vector3 randomPosition = new Vector3(
                player.transform.position.x + Mathf.Cos(angle) * spawnRadius,
                player.transform.position.y,
                player.transform.position.z + Mathf.Sin(angle) * spawnRadius
            );

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPosition, out hit, navMeshSampleDistance, NavMesh.AllAreas))
            {
                GameObject enemy = Instantiate(enemyPrefab, hit.position, Quaternion.identity);
                enemies.Add(enemy);
            }
            else
            {
                Debug.Log("No valid NavMesh position found for enemy spawn.");
            }
        }
    }
}
