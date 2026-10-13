using System.Collections.Generic;
using System.Linq;
using Godot;

namespace trash.scripts.item;

public record struct InventoryItem(ItemResource item, int amount);
public partial class Inventory : Node2D
{
    public WeaponResource[] Weapons = new WeaponResource[3];
    public List<InventoryItem> Stockpile = [];

    public void AddItem(InventoryItem inventoryItem)
    {
        int index = Stockpile.FindIndex(a => a.item == inventoryItem.item);
        if (index == -1) {
            Stockpile.Add(inventoryItem);
        }else {
            var existing = Stockpile[index];

            Stockpile[index] = existing with { amount = existing.amount + inventoryItem.amount };
        }
    }
    
    
}