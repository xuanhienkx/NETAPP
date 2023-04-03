namespace CS.UI.Common.Interfaces
{
    public enum StateType
    {
        Cancel,
        Executed
    }

    public struct State<T>
    {
        public State(T result, StateType stateType = StateType.Cancel)
        {
            Result = result;
            Type = stateType;
        }

        public T Result { get; }
        public StateType Type { get; }
    }
}