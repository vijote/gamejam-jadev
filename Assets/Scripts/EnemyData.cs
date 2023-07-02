public class EnemyData
{
    public enum EnemyState
    {
        Idle,
        Chase,
        Attack
    }

    public enum EnemySize
    {
        Small,
        Medium,
        Large
    }

    public EnemyState state;
    public EnemySize size;

    public EnemyData(EnemyState initialState, EnemySize initialSize)
    {
        state = initialState;
        size = initialSize;
    }

    public void UpdateState(EnemyState newState)
    {
        state = newState;
        // Perform any additional logic or actions based on the new state
    }
}
