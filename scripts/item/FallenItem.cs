using Godot;

namespace trash.scripts.item;

public partial class FallenItem : Area2D
{
    [Export] public ItemResource Resource;
    [Export] public Sprite2D Sprite2D;
    [Export] public int Count=1;
    public override void _Ready()
    {
        if (Resource != null)
            Setup(Resource, Count);
    }

    public void Setup(ItemResource resource, int count = 1)
    {
        Resource = resource;
        Sprite2D.Texture = Resource.ItemTexture;
        Count = count;
    }


    public void PickUp(Inventory inventory)
    {
        
    }
}