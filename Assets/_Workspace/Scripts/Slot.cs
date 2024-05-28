using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField]
    private SlotItem[] _slotItems;

    private List<int> _setPositions = new List<int>();

    public SlotItem[] GetSlotItems()
    {
        SlotItem[] slotItems = new SlotItem[_slotItems.Length];

        for (int i = 0; i < slotItems.Length; i++)
        {
            slotItems[i] = _slotItems[i];
        }

        return slotItems;
    }

    public void Spin()
    {
        for (int i = 0; i < _slotItems.Length; i++)
        {
            _slotItems[i].Move();
        }
    }

    public void StopSpin(int random = -1, int line = -1)
    {
        for (int i = 0; i < _slotItems.Length; i++)
        {
            _slotItems[i].StopMove();
            _slotItems[i].ResetPosition();

            if (random >= 0 && i == line)
                _slotItems[i].SetItemAt(random);
        }

        _setPositions.Clear();
    }

    private int GetRandomPos()
    {
        int pos = Random.Range(0, _slotItems.Length);

        if (!_setPositions.Contains(pos))
            _setPositions.Add(pos);
        else
        {
            pos = GetRandomPos();
        }

        return pos;
    }
}
