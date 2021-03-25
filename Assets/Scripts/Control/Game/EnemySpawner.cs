using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private IFactory<Enemy> enemyFactory;
    [SerializeField] private Transform spawnPosition;

    private Enemy currentEnemy;

    private void Awake()
    {
        enemyFactory = GetComponent<IFactory<Enemy>>();
    }

    public void NewEnemy()
    {
        if (currentEnemy != null)
        {
            Destroy(currentEnemy.gameObject);
        }
        currentEnemy = enemyFactory.CreateRandom();
        currentEnemy.transform.position = spawnPosition.position;
    }

    /*
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            enemyFactory.Create(Random.Range(0, 5));
        }
    }
    */

}
