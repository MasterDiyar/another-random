using Godot;

namespace trash.scripts.item;

public partial class FallenWeapon : Area2D
{
    [Export] public WeaponResource Resource;
    [Export] public Sprite2D Sprite2D;

    public override void _Ready()
    {
        if (Resource != null)
            Setup(Resource);
    }

    public void Setup(WeaponResource resource)
    {
        Resource = resource;
        Sprite2D.Texture = Resource.WeaponTexture;
    }


    public void PickUp(Inventory inventory)
    {
        
    }
}