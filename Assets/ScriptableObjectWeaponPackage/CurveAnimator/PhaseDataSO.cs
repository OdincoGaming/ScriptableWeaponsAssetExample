using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ScriptableObjects/PhaseDataScriptableObject")]
public class PhaseDataSO : ScriptableObject
{
    public string NameOfPhase;
    public PhaseConstraints phaseConstraints;
    public bool hasBeenEntered;
    public bool hasBeenExited;
    public List<PhaseEvent> phaseEvents;
}
