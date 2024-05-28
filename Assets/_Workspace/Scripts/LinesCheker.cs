using System.Collections.Generic;

public class LinesCheker
{
    public bool CheckOneLine(Slot[] slots, int lineNumber, out List<SlotItem> items)
    {
        items = new List<SlotItem>();

        bool isIdenty = true;

        for (int i = 0; i < slots.Length; i++)
        {
            if (items.Count > 0 && items[0].ItemID != slots[i].GetSlotItems()[lineNumber].ItemID)
                return false;
            else
                items.Add(slots[i].GetSlotItems()[lineNumber]);
        }

        return isIdenty;
    }

    public bool CheckConvertLineUp(Slot[] slots, out List<SlotItem> items)
    {
        items = new List<SlotItem>();

        SlotItem checkedSlot = null;
        bool isIdenty = true;

        int line = 1;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i > 0)
                line = 2;
            else if (i == slots.Length - 1)
                line = 1;

            if (checkedSlot != null && checkedSlot.ItemID != slots[i].GetSlotItems()[line].ItemID)
            {
                isIdenty = false;
                break;
            }
            else
            {
                checkedSlot = slots[i].GetSlotItems()[line];
                items.Add(checkedSlot);
            }
        }

        return isIdenty;
    }

    public bool CheckConvertLineDown(Slot[] slots, out List<SlotItem> items)
    {
        items = new List<SlotItem>();

        SlotItem checkedSlot = null;
        bool isIdenty = true;

        int line = 3;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i > 0)
                line = 2;
            else if (i == slots.Length - 1)
                line = 3;

            if (checkedSlot != null && checkedSlot.ItemID != slots[i].GetSlotItems()[line].ItemID)
            {
                isIdenty = false;
                break;
            }
            else
            {
                checkedSlot = slots[i].GetSlotItems()[line];
                items.Add(checkedSlot);
            }
        }

        return isIdenty;
    }

    public bool CheckOneTriangleLineUp(Slot[] slots, out List<SlotItem> items)
    {
        items = new List<SlotItem>();

        SlotItem checkedSlot = null;
        bool isIdenty = true;

        int line = 1;

        for (int i = 0; i < slots.Length; i++)
        {
            if (checkedSlot != null && checkedSlot.ItemID != slots[i].GetSlotItems()[line].ItemID)
            {
                isIdenty = false;
                break;
            }
            else
            {
                checkedSlot = slots[i].GetSlotItems()[line];
                items.Add(checkedSlot);
            }

            if (i > 2)
                line--;
            else
                line++;

            if (line > 3)
                line = 3;

            if (line < 0)
                line = 0;
        }

        return isIdenty;
    }

    public bool CheckOneTriangleLineDown(Slot[] slots, out List<SlotItem> items)
    {
        items = new List<SlotItem>();

        SlotItem checkedSlot = null;
        bool isIdenty = true;

        int line = 3;

        for (int i = 0; i < slots.Length; i++)
        {
            if (checkedSlot != null && checkedSlot.ItemID != slots[i].GetSlotItems()[line].ItemID)
            {
                isIdenty = false;
                break;
            }
            else
            {
                checkedSlot = slots[i].GetSlotItems()[line];
                items.Add(checkedSlot);
            }

            if (i < 2)
                line--;
            else
                line++;
        }

        return isIdenty;
    }

    public bool CheckTwoTriangleLineUp(Slot[] slots, out List<SlotItem> items)
    {
        items = new List<SlotItem>();

        SlotItem checkedSlot = null;
        bool isIdenty = true;

        int line = 2;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i == 1)
                line = 1;
            else if (i == 2)
                line = 2;
            else if (i == 3)
                line = 1;
            else if (i == 4)
                line = 2;

            if (checkedSlot != null && checkedSlot.ItemID != slots[i].GetSlotItems()[line].ItemID)
            {
                isIdenty = false;
                break;
            }
            else
            {
                checkedSlot = slots[i].GetSlotItems()[line];
                items.Add(checkedSlot);
            }
        }

        return isIdenty;
    }

    public bool CheckTwoTriangleLineDown(Slot[] slots, out List<SlotItem> items)
    {
        items = new List<SlotItem>();

        SlotItem checkedSlot = null;
        bool isIdenty = true;

        int line = 2;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i == 1)
                line = 3;
            else if (i == 2)
                line = 2;
            else if (i == 3)
                line = 3;
            else if (i == 4)
                line = 2;

            if (checkedSlot != null && checkedSlot.ItemID != slots[i].GetSlotItems()[line].ItemID)
            {
                isIdenty = false;
                break;
            }
            else
            {
                checkedSlot = slots[i].GetSlotItems()[line];
                items.Add(checkedSlot);
            }
        }

        return isIdenty;
    }

    public bool CheckWrenchLineUp(Slot[] slots, out List<SlotItem> items)
    {
        items = new List<SlotItem>();

        SlotItem checkedSlot = null;
        bool isIdenty = true;

        int line;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i == 2)
                line = 2;
            else
                line = 1;

            if (checkedSlot != null && checkedSlot.ItemID != slots[i].GetSlotItems()[line].ItemID)
            {
                isIdenty = false;
                break;
            }
            else
            {
                checkedSlot = slots[i].GetSlotItems()[line];
                items.Add(checkedSlot);
            }
        }

        return isIdenty;
    }

    public bool CheckWrenchLineDown(Slot[] slots, out List<SlotItem> items)
    {
        items = new List<SlotItem>();

        SlotItem checkedSlot = null;
        bool isIdenty = true;

        int line;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i == 2)
                line = 2;
            else
                line = 3;

            if (checkedSlot != null && checkedSlot.ItemID != slots[i].GetSlotItems()[line].ItemID)
            {
                isIdenty = false;
                break;
            }
            else
            {
                checkedSlot = slots[i].GetSlotItems()[line];
                items.Add(checkedSlot);
            }
        }

        return isIdenty;
    }
}
