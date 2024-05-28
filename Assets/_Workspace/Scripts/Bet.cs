public class Bet
{
    public int Value { get; private set; }
    public const int MinValue = 100;

    public System.Action<int> OnValueChange;

    public Bet()
    {
        Value = MinValue;
    }

    public void Add()
    {
        Value += 100;

        OnValueChange?.Invoke(Value);
    }

    public void Remove()
    {
        Value -= 100;

        if (Value < MinValue) Value = MinValue;

        OnValueChange?.Invoke(Value);
    }
}
