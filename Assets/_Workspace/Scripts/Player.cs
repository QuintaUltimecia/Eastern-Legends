using UnityEngine;

public class Player : MonoBehaviour
{
    public Money Money { get; private set; } = new Money();
    public Bet Bet { get; private set; } = new Bet();

    public void AddBet()
    {
        Bet.Add();
    }

    public void RemoveBet()
    {
        Bet.Remove();
    }

    private void Awake()
    {
        Money.Construct();
    }
}