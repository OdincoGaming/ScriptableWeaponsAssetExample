using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/WeaponScriptableObject")]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    public List<CurveAnimSO> MoveSet;
}
