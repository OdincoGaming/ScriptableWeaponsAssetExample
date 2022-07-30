using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PhaseEvents/ApplyStatuseffectEventScriptableObject")]
public class ApplyStatusEffectEvent : PhaseEvent
{
    public List<ExampleStatusEffectScriptableObject> statusEffectsToApply;
}
