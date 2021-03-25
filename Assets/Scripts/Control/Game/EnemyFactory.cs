using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory<Enemy>
{

    [SerializeField] private Enemy[] enemies;

    public Enemy Create(int id)
    {
        return Instantiate(enemies[id]);
    }

    public Enemy CreateRandom()
    {
        return Create(Random.Range(0, enemies.Length));
    }

}
