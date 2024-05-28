using TMPro;
using UnityEngine;

public class MoneyRenderer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private Player _player;

    private void Awake()
    {
        _player.Money.OnValueChange += (value) => UpdateText(value);
    }

    private void Start()
    {
        UpdateText(_player.Money.Value);
    }

    private void UpdateText(int value)
    {
        _text.text = value.ToString();
    }
}