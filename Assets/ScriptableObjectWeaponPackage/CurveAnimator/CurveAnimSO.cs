using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CurveAnimScriptableObject")]
public class CurveAnimSO : ScriptableObject
{
    public string nameOfAnim;
    public float animLength;

    public AnimationCurve posX;
    public AnimationCurve posY;
    public AnimationCurve posZ;

    public AnimationCurve rotX;
    public AnimationCurve rotY;
    public AnimationCurve rotZ;

    public int phaseIndex;
    public List<PhaseDataSO> phaseData;
}
