using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject smallEnemyPrefab;
    public GameObject mediumEnemyPrefab;
    public GameObject largeEnemyPrefab;

    public List<Enemy> enemies;
    public Transform player;
    public static EnemyManager instance;

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        instance = this;
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(2);

        while (true)
        {
            yield return wait;

            GameObject selectedPrefab = SelectEnemyPrefab();
            if (selectedPrefab != null)
            {
                SpawnEnemy(selectedPrefab);
            }
        }
    }

    private GameObject SelectEnemyPrefab()
    {
        if (ShouldSpawnSmallEnemy())
        {
            return smallEnemyPrefab;
        }

        if (ShouldSpawnMediumEnemy())
        {
            return mediumEnemyPrefab;
        }

        if (ShouldSpawnLargeEnemy())
        {
            return largeEnemyPrefab;
        }

        return null;
    }

    private bool ShouldSpawnMediumEnemy()
    {
        if (Player.instance.size == Size.Small)
        {
            if (MediumEnemiesCount() < 1) return true;

            return false;
        }

        if (Player.instance.size == Size.Medium)
        {
            if (MediumEnemiesCount() < 3) return true;

            return false;
        }

        if (Player.instance.size == Size.Large)
        {
            if (MediumEnemiesCount() < 2) return true;

            return false;
        }

        return false;
    }

    private bool ShouldSpawnSmallEnemy()
    {
        if (Player.instance.size == Size.Small)
        {
            if (SmallEnemiesCount() < 5) return true;

            return false;
        }

        if (Player.instance.size == Size.Medium)
        {
            if (SmallEnemiesCount() < 2) return true;

            return false;
        }

        if (Player.instance.size == Size.Large)
        {
            if (SmallEnemiesCount() < 1) return true;

            return false;
        }

        return false;
    }

    private bool ShouldSpawnLargeEnemy()
    {
        if (Player.instance.size == Size.Small)
        {
            if(LargeEnemiesCount() < 1) return true;

            return false;
        }

        if (Player.instance.size == Size.Medium)
        {
            if (LargeEnemiesCount() < 2) return true;

            return false;
        }

        if(Player.instance.size == Size.Large)
        {
            if(LargeEnemiesCount() < 5) return true;

            return false;
        }

        return false;
    }

    private int SmallEnemiesCount()
    {
        return enemies.Count(enemy => enemy.size == Size.Small);
    }

    private int MediumEnemiesCount()
    {
        return enemies.Count(enemy => enemy.size == Size.Medium);
    }

    private int LargeEnemiesCount()
    {
        return enemies.Count(enemy => enemy.size == Size.Large);
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        if (enemies.Count == Globals.MAX_ENEMY_COUNT) return;

        // Generate a random position within the playable area
        Vector3 randomPosition = GetRandomPositionWithinPlayableArea();

        // Instantiate a new enemy from the selected prefab at the random position
        GameObject newEnemyObject = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

        // Get the Enemy component from the instantiated enemy GameObject
        Enemy newEnemy = newEnemyObject.GetComponent<Enemy>();

        // Add the new enemy to the enemies list
        enemies.Add(newEnemy);
    }

    private Vector3 GetRandomPositionWithinPlayableArea()
    {
        Camera mainCamera = Camera.main;

        // Get the playable area bounds
        Vector3 playableAreaCenter = (PlayableArea.bottomLeftCorner + PlayableArea.bottomRightCorner + PlayableArea.topLeftCorner + PlayableArea.topRightCorner) / 4f;
        Vector3 playableAreaSize = new Vector3(
            Mathf.Abs(PlayableArea.topRightCorner.x - PlayableArea.topLeftCorner.x),
            Mathf.Abs(PlayableArea.topLeftCorner.y - PlayableArea.bottomLeftCorner.y),
            Mathf.Abs(PlayableArea.topRightCorner.z - PlayableArea.bottomRightCorner.z)
        );

        // Calculate the minimum and maximum position limits within the playable area
        Vector3 minPosition = playableAreaCenter - playableAreaSize / 2f;
        Vector3 maxPosition = playableAreaCenter + playableAreaSize / 2f;

        // Calculate the adjusted minimum and maximum position limits based on the camera's viewport edges
        Vector3 viewportMin = mainCamera.WorldToViewportPoint(minPosition);
        Vector3 viewportMax = mainCamera.WorldToViewportPoint(maxPosition);

        // Adjust the viewport limits based on your desired margin
        float margin = 0.1f;
        viewportMin += new Vector3(margin, margin, 0f);
        viewportMax -= new Vector3(margin, margin, 0f);

        // Convert the adjusted viewport limits back to world space
        Vector3 adjustedMinPos = mainCamera.ViewportToWorldPoint(viewportMin);
        Vector3 adjustedMaxPos = mainCamera.ViewportToWorldPoint(viewportMax);

        // Generate a random position within the adjusted limits
        Vector3 randomPosition = new Vector3(
            Random.Range(adjustedMinPos.x, adjustedMaxPos.x),
            1f,
            Random.Range(adjustedMinPos.z, adjustedMaxPos.z)            
        );

        Debug.Log(randomPosition);

        return randomPosition;
    }

    public void RemoveEnemy(Enemy enemyToRemove)
    {
        this.enemies.Remove(enemyToRemove);
    }
}


