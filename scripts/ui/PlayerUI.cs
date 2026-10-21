using Godot;
using System;
using System.Collections.Generic;
using trash.scripts.item;
using trash.scripts.ui;
using trash.scripts.units;

public partial class PlayerUI : Control
{
	[Export] public HBoxContainer HUD;
	
	[Export] public Player Player;
	private List<InventorySlot> InventorySlots = [];
	private Inventory _inventory;
	public override void _Ready()
	{
		if (Player != null)
		{
			_inventory = Player.Inventory;
			_inventory.OnWeaponAdded += SetSlots;
		}
	}

	public void SetSlots(WeaponResource[] items)
	{
		foreach (var slot in InventorySlots)
			slot.QueueFree();
		
		InventorySlots.Clear();
		for (int i = 0; i < items.Length; i++) {
			var weaponResource = items[i];

			var slot = new InventorySlot();
			slot.Index = i;
			slot.Resource = weaponResource;

			if (weaponResource is { WeaponTexture: not null })
				slot.Icon = weaponResource.WeaponTexture;
			
			int currentIndex = i;
			slot.Pressed += () => OnSlotPressed(weaponResource);

			HUD.AddChild(slot);
			InventorySlots.Add(slot);
		}
	}

	private void OnSlotPressed(WeaponResource resource)
	{
		if (Player != null && resource != null)
			Player.SetWeapon(resource);
		
	}

}
