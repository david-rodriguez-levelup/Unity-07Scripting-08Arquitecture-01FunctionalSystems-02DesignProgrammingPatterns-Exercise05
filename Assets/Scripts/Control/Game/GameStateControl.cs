using System.Collections.Generic;
using UnityEngine;

public class GameStateControl : MonoBehaviour
{

    [SerializeField] PlayerSlotArrayControl playerSlotArrayControl;
    [SerializeField] EnemySlotArrayControl enemySlotArrayControl;
    [SerializeField] HealthState playerHealth;
    [SerializeField] BarChangeAction playerHealthBarChangeAction;
    [SerializeField] HealthState enemyHealth;
    [SerializeField] BarChangeAction enemyHealthBarChangeAction;

    private readonly List<ICommand> playerCommands = new List<ICommand>();
    private readonly List<ICommand> enemyCommands = new List<ICommand>();

    private EnemySpawner enemySpawner;
    private LevelCounter levelCounter;

    public IState StateNewGame { get; private set; }
    public IState StateNewLevel { get; private set; }
    public IState StateNewTurn { get; private set; }
    public IState StatePlayerSelection { get; private set; }
    public IState StateEnemySelection { get; private set; }
    public IState StateResolveTurn { get; private set; }
    public IState StateGameOver { get; private set; }

    private IState currentState;

    private void Awake()
    {
        enemySpawner = GetComponent<EnemySpawner>();

        levelCounter = GetComponent<LevelCounter>();

        StateNewGame = new StateNewGame(this /*, levelCounter*/);
        StateNewLevel = new StateNewLevel(this, playerHealth, playerHealthBarChangeAction, enemySpawner, enemyHealth, enemyHealthBarChangeAction /*, levelCounter*/);
        StateNewTurn = new StateNewTurn(this, playerSlotArrayControl, playerCommands, enemySlotArrayControl, enemyCommands);
        StatePlayerSelection = new StatePlayerSelection(this, playerSlotArrayControl, playerCommands);
        StateEnemySelection = new StateEnemySelection(this, enemySlotArrayControl, enemyCommands);
        StateResolveTurn = new StateResolveTurn(this, playerHealth, playerHealthBarChangeAction, enemyHealth, enemyHealthBarChangeAction, playerCommands, enemyCommands);
        StateGameOver = new StateGameOver(this);
    }

    private void Start()
    {
        ChangeState(StateNewGame);
    }

    private void Update()
    {
        currentState.Update();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

    public void ChangeState(IState state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }

}
