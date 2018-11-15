using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBStat : CharacterStat {
    public float Phase1HpPercent = .7f;
    public float Phase2HpPercent = .3f;
    public GameObject ps;
    public GameObject matpi;

    protected override void Awake()
    {
        base.Awake();
        GoblinStatData stat = playerStat as GoblinStatData;
        Phase1HpPercent = stat.Phase1HpPercent;
        Phase2HpPercent = stat.Phase2HpPercent;
        matpi = stat.matpi;
    }
}