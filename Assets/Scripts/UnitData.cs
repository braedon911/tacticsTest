using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Unit", order = 1)]
public class UnitData : ScriptableObject
{
    [SerializeField] string unitName;
    [SerializeField] int level;
    [SerializeField] UnitBaseStats baseStats;
}
[System.Serializable]
public class UnitBaseStats
{
    [SerializeField] int health;
    [SerializeField] int magic;
    [SerializeField] int defense;
    [SerializeField] int atk;
    [SerializeField] int speed;
}
