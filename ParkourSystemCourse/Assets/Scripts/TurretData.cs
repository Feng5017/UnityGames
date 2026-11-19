using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//可以显示
public class TurretData{
    //升级前
    public GameObject turretPrefab;
    public int cost;
    //升级后
    public GameObject turretUpgradedPrefab;
    public int costUpgraded;

    public TurretType type;
}

public enum TurretType
{
    LaserTurret,
    MissileTurret,
    StandardTurret
}
