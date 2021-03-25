using UnityEngine;

public class StateNewLevel : AbstractState
{

    private readonly HealthState playerHealth;
    private readonly BarChangeAction playerHealthBarChangeAction;
    private readonly EnemySpawner enemySpawner;
    private readonly HealthState enemyHealth;
    private readonly BarChangeAction enemyHealthBarChangeAction;

    //private readonly LevelCounter levelCounter;

    public StateNewLevel(GameStateControl gameStateControl,
                         HealthState playerHealth,
                         BarChangeAction playerHealthBarChangeAction,
                         EnemySpawner enemySpawner,
                         HealthState enemyHealth,
                         BarChangeAction enemyHealthBarChangeAction
                         /*, LevelCounter levelCounter*/) : base(gameStateControl)
    {
        this.gameStateControl = gameStateControl;
        this.playerHealth = playerHealth;
        this.playerHealthBarChangeAction = playerHealthBarChangeAction;
        this.enemySpawner = enemySpawner;
        this.enemyHealth = enemyHealth;
        this.enemyHealthBarChangeAction = enemyHealthBarChangeAction;
        //this.levelCounter = levelCounter;
    }

    public override void Enter()
    {
        Debug.Log("NEW LEVEL!!!");

        playerHealth.RestoreAll();
        playerHealthBarChangeAction.Perform(playerHealth.CurrentHealth);
        enemyHealth.RestoreAll();
        enemyHealthBarChangeAction.Perform(enemyHealth.CurrentHealth);

        //levelCounter.IncreaseLevel();
        LevelCounter.Instance.IncreaseLevel();

        enemySpawner.NewEnemy();

        gameStateControl.ChangeState(gameStateControl.StateNewTurn);
    }

}