using Godot;
using trash.scripts.units;

namespace trash.scripts.item;

public partial class FallenWeapon : Area2D
{
    [Export] public WeaponResource Resource;
    [Export] public Sprite2D Sprite2D;

    private bool _canTake = false;
    Player _player;

    public override void _Ready()
    {
        if (Resource != null)
            Setup(Resource);
        BodyEntered += OnBodyEntered;
        BodyExited += OnBodyExited;
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body is not Player player) return;
        _canTake = true;
        _player = player;
    }

    private void OnBodyExited(Node2D body)
    {
        if (body is not Player player) return;
        _canTake = false;
        _player = null;
    }

    public override void _Process(double delta)
    {
        if (_canTake && _player != null && Input.IsActionJustPressed("e"))
        {
            PickUp(_player.Inventory);
            QueueFree();
        }
    }

    public void Setup(WeaponResource resource)
    {
        Resource = resource;
        Sprite2D.Texture = Resource.WeaponTexture;
    }


    public void PickUp(Inventory inventory)
    {
        inventory.AddWeapon(Resource);
    }
}