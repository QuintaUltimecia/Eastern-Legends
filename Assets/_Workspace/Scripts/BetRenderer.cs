using TMPro;
using UnityEngine;

public class BetRenderer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private Player _player;

    private void Awake()
    {
        _player.Bet.OnValueChange += (value) => UpdateText(value);
    }

    private void Start()
    {
        UpdateText(_player.Bet.Value);
    }

    private void UpdateText(int value)
    {
        _text.text = value.ToString();
    }
}
