using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Slots : MonoBehaviour
{
    [SerializeField]
    private Slot[] _slots;

    [SerializeField]
    private float _spinInterval = 1f;

    [SerializeField]
    private float _spinTime = 5f;

    [SerializeField]
    private LineController _lineController;

    [SerializeField]
    private Player _player;

    [SerializeField]
    private TextMeshProUGUI _winningText;

    [SerializeField]
    private Bonus _bonus;

    private Camera _camera;

    private int _notARandom = 0;
    private int _random = -1;
    private int _randomLine = -1;

    private bool _isSpin = false;

    public void Spin()
    {
        if (_isSpin == true)
            return;

        if (_player.Money.Value < _player.Bet.Value)
        {
            if (_bonus.GetBonus() == true)
                _player.Money.AddMoney(Random.Range(1, 5) * 1000);

            return;
        }

        Debug.Log($"{_player.Money.Value} < {_player.Bet.Value}");

        _isSpin = true;

        StartCoroutine(SpinRoutine());
        StartCoroutine(StopRoutine());

        _lineController.GetRendererAt(0).CleadPoints();
        _lineController.GetRendererAt(1).CleadPoints();
        _lineController.GetRendererAt(2).CleadPoints();

        _player.Money.RemoveMoney(_player.Bet.Value);
    }

    private void Awake()
    {
        _camera = Camera.main;
    }

    private IEnumerator SpinRoutine()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].Spin();
            yield return new WaitForSeconds(_spinInterval);
        }
    }

    private IEnumerator StopRoutine()
    {
        yield return new WaitForSeconds(_spinTime);

        SetNotARandom();

        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].StopSpin(_random, _randomLine);

            yield return new WaitForSeconds(_spinInterval);
        }

        CheckLines();

        _isSpin = false;
    }

    private void CheckLines()
    {
        LinesCheker linesCheker = new LinesCheker();
        List<SlotItem> list;

        bool[] line = new bool[3];

        if (linesCheker.CheckOneLine(_slots, 1, out list) == true)
        {
            line[0] = true;

            foreach (var item in list)
                _lineController.GetRendererAt(0).AddPoint(_camera.ScreenToWorldPoint(item.transform.position));
        }

        if (linesCheker.CheckOneLine(_slots, 2, out list) == true)
        {
            line[1] = true;

            foreach (var item in list)
                _lineController.GetRendererAt(1).AddPoint(_camera.ScreenToWorldPoint(item.transform.position));
        }

        if (linesCheker.CheckOneLine(_slots, 3, out list) == true)
        {
            line[2] = true;

            foreach (var item in list)
                _lineController.GetRendererAt(2).AddPoint(_camera.ScreenToWorldPoint(item.transform.position));
        }

        if (line[0] == false)
            line[0] = CheckOtherLines(0);
        if (line[1] == false)
            line[1] = CheckOtherLines(1);
        if (line[2] == false)
            line[2] = CheckOtherLines(2);

        _winningText.text = $"Winning {0}";

        if (line[0] == false)
            _lineController.GetRendererAt(0).CleadPoints();
        else
        {
            _player.Money.AddMoney(_player.Bet.Value * 5);
            _winningText.text = $"Winning {_player.Bet.Value * 5}";
        }

        if (line[1] == false)
            _lineController.GetRendererAt(1).CleadPoints();
        else
        {
            _player.Money.AddMoney(_player.Bet.Value * 5);
            _winningText.text = $"Winning {_player.Bet.Value * 5}";
        }

        if (line[2] == false)
            _lineController.GetRendererAt(2).CleadPoints();
        else
        {
            _player.Money.AddMoney(_player.Bet.Value * 5);
            _winningText.text = $"Winning {_player.Bet.Value * 5}";
        }

    }

    private bool CheckOtherLines(int line)
    {
        LinesCheker linesCheker = new LinesCheker();
        List<SlotItem> list;

        bool value = false;

        if (linesCheker.CheckConvertLineUp(_slots, out list) == true)
        {
            value = true;

            foreach (var item in list)
                _lineController.GetRendererAt(0).AddPoint(_camera.ScreenToWorldPoint(item.transform.position));
        }
        else
        {
            if (linesCheker.CheckConvertLineDown(_slots, out list) == true)
            {
                value = true;

                foreach (var item in list)
                    _lineController.GetRendererAt(0).AddPoint(_camera.ScreenToWorldPoint(item.transform.position));
            }
            else
            {
                if (linesCheker.CheckOneTriangleLineUp(_slots, out list) == true)
                {
                    value = true;

                    foreach (var item in list)
                        _lineController.GetRendererAt(0).AddPoint(_camera.ScreenToWorldPoint(item.transform.position));
                }
                else
                {
                    if (linesCheker.CheckOneTriangleLineDown(_slots, out list) == true)
                    {
                        value = true;

                        foreach (var item in list)
                            _lineController.GetRendererAt(0).AddPoint(_camera.ScreenToWorldPoint(item.transform.position));
                    }
                    else
                    {
                        if (linesCheker.CheckTwoTriangleLineUp(_slots, out list) == true)
                        {
                            value = true;

                            foreach (var item in list)
                                _lineController.GetRendererAt(0).AddPoint(_camera.ScreenToWorldPoint(item.transform.position));
                        }
                        else
                        {
                            if (linesCheker.CheckTwoTriangleLineDown(_slots, out list) == true)
                            {
                                value = true;

                                foreach (var item in list)
                                    _lineController.GetRendererAt(0).AddPoint(_camera.ScreenToWorldPoint(item.transform.position));
                            }
                            else
                            {
                                if (linesCheker.CheckWrenchLineUp(_slots, out list) == true)
                                {
                                    value = true;

                                    foreach (var item in list)
                                        _lineController.GetRendererAt(0).AddPoint(_camera.ScreenToWorldPoint(item.transform.position));
                                }
                                else
                                {
                                    if (linesCheker.CheckWrenchLineDown(_slots, out list) == true)
                                    {
                                        value = true;

                                        foreach (var item in list)
                                            _lineController.GetRendererAt(0).AddPoint(_camera.ScreenToWorldPoint(item.transform.position));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        return value;
    }

    private void SetNotARandom()
    {
        if (_notARandom == 0)
        {
            _random = Random.Range(0, 10);
            _randomLine = Random.Range(1, 4);
        }
        else
        {
            _random = -1;
            _randomLine = -1;
        }

        _notARandom++;

        if (_notARandom > 6)
        {
            _notARandom = 0;
        }
    }
}