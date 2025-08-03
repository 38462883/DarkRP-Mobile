using System;
using System.Collections.Generic;

public class InventorySystem
{
    public event Action OnInventoryUpdated;
    
    public List<Item> Items { get; private set; }
    public int MaxItemCount { get; } = 20;

    public InventorySystem()
    {
        Items = new List<Item>();
    }

    public bool AddItem(Item item)
    {
        if (Items.Count >= MaxItemCount)
        {
            Console.WriteLine("Envanter dolu!");
            return false;
        }

        Items.Add(item);
        OnInventoryUpdated?.Invoke();
        Console.WriteLine($"{item.Name} envantere eklendi.");
        return true;
    }

    public void RemoveItem(Item item)
    {
        if (Items.Remove(item))
        {
            OnInventoryUpdated?.Invoke();
            Console.WriteLine($"{item.Name} envanterden çıkarıldı.");
        }
    }
}
