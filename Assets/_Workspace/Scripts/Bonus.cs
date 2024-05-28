using TMPro;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private BonusAnimations _anim;

    private int _value = 10;

    private string _key = "bonus";

    public bool GetBonus()
    {
        if (_value != 0)
        {
            _value--;
            UpdateText(_value);
            _anim.Play();

            PlayerPrefs.SetInt(_key, _value);
            PlayerPrefs.Save();

            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateText(int value)
    {
        _text.text = $"{value}/10";
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(_key))
        {
            _value = PlayerPrefs.GetInt(_key);
            UpdateText(_value);
        }
        else
        {
            _value = 10;
            PlayerPrefs.SetInt(_key, _value);
            PlayerPrefs.Save();
            UpdateText(_value);
        }
    }
}
