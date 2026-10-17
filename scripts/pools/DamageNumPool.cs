using Godot;
using System;
using System.Collections.Generic;

public partial class DamageNumPool : Node2D
{
    [Export] public int LabelCount = 30;
    private List<Label> Labels = [];
    private int currentLabel = 0;

    public static DamageNumPool Instance { get; private set; }

    private RandomNumberGenerator _rng = new RandomNumberGenerator();

    public override void _Ready()
    {
        Instance = this;
        _rng.Randomize(); 
        Init();
    }

    public void Init()
    {
        for (int i = 0; i < LabelCount; i++)
        {
            var label = new Label();
            label.Visible = false;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            AddChild(label);
            Labels.Add(label);
        }
    }

    public void SetDamage(Vector2 position, float damage)
    {
        if (Labels.Count == 0) return;

        Label label = Labels[currentLabel];
        currentLabel = (currentLabel + 1) % LabelCount;

        label.Text = Mathf.RoundToInt(damage).ToString();
        label.Visible = true;
        label.ZIndex = 10; 
        label.GlobalPosition = position;

        Color modulate = label.Modulate;
        modulate.A = 1.0f;
        label.Modulate = modulate;

        float fadeTime = 0.5f; 
        
        float randomAngle = _rng.RandfRange(0, Mathf.Tau);
        float randomDistance = _rng.RandfRange(30.0f, 60.0f);
        
        Vector2 travelDirection = Vector2.FromAngle(randomAngle);
        Vector2 targetPosition = position + travelDirection * randomDistance;

        Tween tween = label.CreateTween().SetParallel(true);

        tween.TweenProperty(label, "modulate:a", 0.0f, fadeTime);

        tween.TweenProperty(label, "global_position", targetPosition, fadeTime)
             .SetTrans(Tween.TransitionType.Back)
             .SetEase(Tween.EaseType.Out);

        tween.Finished += () =>
        {
            label.Visible = false;
        };
    }
}