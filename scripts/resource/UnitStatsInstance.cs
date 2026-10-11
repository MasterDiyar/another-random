using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace trash.scripts.resource;

public partial class UnitStatsInstance : RefCounted
{
    public UnitStats BaseStats { get; private set; }
    public UnitStats[] AccesoryModifiers { get; set; }
    public UnitStats[] AdditionalModifier { get; set; }
    
    public float CurrentHp { get; set; }
    public float CurrentMp { get; set; }
    public float CurrentEnergy { get; set; }
    public float CurrentArmor { get; set; }
    public float CurrentShield { get; set; }

    private float GetTotalStat(Func<UnitStats, float> selector)
    {
        float baseVal = BaseStats != null ? selector(BaseStats) : 0f;
        float accesorySum = AccesoryModifiers?.Where(m => m != null).Sum(selector) ?? 0f;
        float additionalSum = AdditionalModifier?.Where(m => m != null).Sum(selector) ?? 0f;

        return baseVal + accesorySum + additionalSum;
    }

    public float Speed => GetTotalStat(s => s.Speed);
    public float MaxHp => GetTotalStat(s => s.MaxHp);
    public float MaxMp => GetTotalStat(s => s.MaxMp);
    public float MaxEnergy => GetTotalStat(s => s.MaxEnergy);
    public float MaxArmor => GetTotalStat(s => s.MaxArmor);
    public float MaxShield => GetTotalStat(s => s.MaxShield);
    public float Strength => GetTotalStat(s => s.Strength);
    public float Agility => GetTotalStat(s => s.Agility);
    public float Intelligence => GetTotalStat(s => s.Intelligence);

    public UnitStatsInstance(UnitStats baseStats)
    {
        LoadStats(baseStats);
    }

    public UnitStatsInstance()
    {
    }
    
    public void LoadStats(UnitStats baseStats)
    {
        BaseStats = baseStats;

        if (BaseStats == null) return;

        CurrentHp = MaxHp;
        CurrentMp = MaxMp;
        CurrentEnergy = MaxEnergy;
        CurrentArmor = MaxArmor;
        CurrentShield = MaxShield;
    }
}