
public class EnemyKilledCounter : Singleton<EnemyKilledCounter>
{
    public int enemyKilled;

    public void EnemyKilled()
    {
        enemyKilled++;
    }
}
