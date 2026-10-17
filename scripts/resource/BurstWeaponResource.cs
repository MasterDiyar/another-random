using Godot;
using trash.scripts.resource;

[GlobalClass]
public partial class BurstWeaponResource : WeaponResource
{
    [Export] public int BurstCount = 4;          
    [Export] public float BurstDuration = 0.3f; 
    [Export] public float BurstSpread = 0f;
    [Export] public float BetweenAngle = 0f;

    public override async void SpawnBullet(Node spawnNode, Vector2 spawnPosition, float rotation)
    {
        float delayBetweenShots = BurstDuration / (BurstCount - 1);

        for (int i = 0; i < BurstCount; i++) {
            if (!IsInstanceValid(spawnNode)) break;
            base.SpawnBullet(spawnNode, spawnPosition, rotation + i * BetweenAngle + GD.Randf() * BurstSpread);

            if (i < BurstCount - 1)
                await spawnNode.GetTree().ToSignal(spawnNode.GetTree().CreateTimer(delayBetweenShots), SceneTreeTimer.SignalName.Timeout);
            
        }
    }
}