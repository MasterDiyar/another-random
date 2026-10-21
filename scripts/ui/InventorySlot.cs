using Godot;

namespace trash.scripts.ui;

public partial class InventorySlot : Button
{
    public int Index { get; set; }
    public WeaponResource Resource { get; set; }
    
    
}