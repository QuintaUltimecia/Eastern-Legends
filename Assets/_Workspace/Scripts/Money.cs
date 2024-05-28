using UnityEngine;

public class Money
{
    public int Value { get; private set; }
    public const int MinValue = 0;

    private string _key = "money";

    public System.Action<int> OnValueChange;

    public void Construct()
    {
        if (PlayerPrefs.HasKey(_key) == true)
            Value = PlayerPrefs.GetInt(_key);
        else Value = 100;
    }

    public void AddMoney(int value)
    {
        Value += value;

        PlayerPrefs.SetInt(_key, Value);
        PlayerPrefs.Save();

        OnValueChange?.Invoke(Value);
    }

    public void RemoveMoney(int value)
    {
        Value -= value;

        if (Value < MinValue)
            Value = MinValue;

        PlayerPrefs.SetInt(_key, Value);
        PlayerPrefs.Save();

        OnValueChange?.Invoke(Value);
    }
}
