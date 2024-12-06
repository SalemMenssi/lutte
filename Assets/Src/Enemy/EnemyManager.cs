using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab; 
    private Enemy currentEnemy; 

    private void Start()
    {
        SpawnAndInitializeEnemy();
    }

    private void SpawnAndInitializeEnemy()
    {
        GameObject enemyObj = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);

        currentEnemy = enemyObj.GetComponent<Enemy>();

        if (currentEnemy == null)
        {
            currentEnemy = enemyObj.AddComponent<Enemy>();
        }

        string enemyName = "Enemy_" + Random.Range(1, 1000);

        currentEnemy.InitializeEnemy(enemyName);

        currentEnemy.DisplayEnemyInfo();
    }
}
