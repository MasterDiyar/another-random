using Godot;

namespace trash.scripts.resource;

public partial class UnitStatsInstance : RefCounted
{
    public UnitStats BaseStats { get; private set; }

    public float CurrentHp { get; set; }
    public float CurrentMp { get; set; }
    public float CurrentEnergy { get; set; }
    public float CurrentArmor { get; set; }
    public float CurrentShield { get; set; }

    
    public float Speed => BaseStats?.Speed ?? 0f;
    public float MaxHp => BaseStats?.MaxHp ?? 0f;
    public float MaxMp => BaseStats?.MaxMp ?? 0f;
    public float MaxEnergy => BaseStats?.MaxEnergy ?? 0f;
    public float MaxArmor => BaseStats?.MaxArmor ?? 0f;
    public float MaxShield => BaseStats?.MaxShield ?? 0f;
    public float Strength => BaseStats?.Strength ?? 0f;
    public float Agility => BaseStats?.Agility ?? 0f;
    public float Intelligence => BaseStats?.Intelligence ?? 0f;

    public UnitStatsInstance(UnitStats baseStats)
    {
        LoadStats(baseStats);
    }

    public UnitStatsInstance()
    {
    }

    /// <summary>
    /// Loads or resets current stats to match the given UnitStats resource base values.
    /// </summary>
    public void LoadStats(UnitStats baseStats)
    {
        BaseStats = baseStats;

        if (BaseStats == null) return;

        CurrentHp = BaseStats.MaxHp;
        CurrentMp = BaseStats.MaxMp;
        CurrentEnergy = BaseStats.MaxEnergy;
        CurrentArmor = BaseStats.MaxArmor;
        CurrentShield = BaseStats.MaxShield;
    }
}