

using System;
using Godot;
using trash.scripts.weapons;

public enum TrailType
{
    Line,
    TextureShade
}


[GlobalClass]
public partial class TrailBulletResource : BulletResource
{
    [Export] public TrailType Type;
    
    [Export] public float Width;
    [Export] public Color TrailColor;
    
    [Export] public int Count = 4;
    [Export] public float Difference = 0.33f;
    [Export] public float MaxDistance = 6f;

    private Line2D _trail;
    private Sprite2D[] _sprites;
    
    public override void OnSpawn(Bullet bullet)
    {
        if (Type == TrailType.Line) {
            _trail = new Line2D();
            _trail.AddPoint(Vector2.Zero);
            _trail.DefaultColor = TrailColor;
            _trail.WidthCurve = new Curve();
            _trail.WidthCurve.AddPoint(Vector2.One);
            _trail.WidthCurve.AddPoint(Vector2.Zero);
            _trail.Width = Width;
        }else {
            _sprites = new Sprite2D[Count];
            for (int i = 0; i < Count; i++) {
                _sprites[i] = new Sprite2D();
                bullet.AddChild(_sprites[i]);
                _sprites[i].Texture = Texture;
                _sprites[i].Modulate = _sprites[i].Modulate * Difference * (Count - i);
                
            }
        }
        base.OnSpawn(bullet);
    }

    public override void PerFlight(float lifetime, ref Bullet bullet)
    {
        var distance = LifeTime - lifetime;
        if (Type == TrailType.TextureShade) {
            for (int i = 0; i < Count; i++)
                _sprites[i].Position = distance / LifeTime * MaxDistance * i * Vector2.Left;
    
            base.PerFlight(lifetime, ref bullet);
        }else {
            _trail.AddPoint(Vector2.FromAngle(bullet.Rotation+Single.Pi) * MaxDistance * distance);
        }
    }
}