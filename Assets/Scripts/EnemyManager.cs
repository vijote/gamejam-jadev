using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public List<Enemy> enemies;
    public Transform player;

    private Vector3 bottomLeftCorner = new Vector3(-7.25f, 0f, -17.77f);
    private Vector3 bottomRightCorner = new Vector3(60.1f, 0f, -17.77f);
    private Vector3 topLeftCorner = new Vector3(-7.25f, 0f, 29.906f);
    private Vector3 topRightCorner = new Vector3(60.1f, 0f, 29.906f);

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(2);

        while (true)
        {
            yield return wait;
            SpawnEnemy();
        }
    }
    
    public void SpawnEnemy()
    {
        if (enemies.Count == 5) return;

        // Get a random enemy prefab from the list
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

        // Generate a random position within the playable area
        Vector3 randomPosition = GetRandomPositionWithinPlayableArea();

        // Instantiate a new enemy from the selected prefab at the random position
        GameObject newEnemyObject = Instantiate(randomEnemyPrefab, randomPosition, Quaternion.identity);

        // Get the Enemy component from the instantiated enemy GameObject
        Enemy newEnemy = newEnemyObject.GetComponent<Enemy>();

        newEnemy.SetSize(SizeHelper.GetRandomSize());

        // Add the new enemy to the enemies list
        enemies.Add(newEnemy);
    }

    private Vector3 GetRandomPositionWithinPlayableArea()
    {
        Vector3 playableAreaCenter = (bottomLeftCorner + bottomRightCorner + topLeftCorner + topRightCorner) / 4f;
        Vector3 playableAreaSize = new Vector3(
            Mathf.Abs(topRightCorner.x - topLeftCorner.x),
            Mathf.Abs(topLeftCorner.y - bottomLeftCorner.y),
            Mathf.Abs(topRightCorner.z - bottomRightCorner.z)
        );

        // Calculate the minimum and maximum position limits within the playable area
        Vector3 minPosition = playableAreaCenter - playableAreaSize / 2f;
        Vector3 maxPosition = playableAreaCenter + playableAreaSize / 2f;

        // Generate a random position within the limits
        Vector3 randomPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y),
            0f
        );

        return randomPosition;
    }
}


