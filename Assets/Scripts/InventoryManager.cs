using System.Collections.Generic;

public static class InventoryManager
{
    private static HashSet<string> items = new HashSet<string>();

    public static void AddItem(string itemName)
    {
        items.Add(itemName);
        UnityEngine.Debug.Log("Item added: " + itemName);
    }

    public static bool HasItem(string itemName)
    {
        return items.Contains(itemName);
    }

    public static void ClearInventory()
    {
        items.Clear();
    }
}
