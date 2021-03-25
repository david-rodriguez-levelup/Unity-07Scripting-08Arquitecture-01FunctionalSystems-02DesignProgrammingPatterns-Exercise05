using UnityEngine;

public class LevelCounter : Singleton<LevelCounter>
{

    [SerializeField] LevelCounterChangeAction levelCounterChangeAction;

    private int level = 0;

    protected override void Awake()
    {
        base.Awake();

        if (levelCounterChangeAction == null)
        {
            levelCounterChangeAction = FindObjectOfType<LevelCounterChangeAction>();
        }
    }

    public void ResetLevel()
    {
        level = 0;
        levelCounterChangeAction.Perform(level);
    }

    public void IncreaseLevel()
    {
        level++;
        levelCounterChangeAction.Perform(level);
    }

}
