using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PhaseEventType {ActivateHitboxes, DeactivateHitboxes, Move, AddVelocity, ApplyStatusEffect, ActivateParticleSystem, None}

[CreateAssetMenu(menuName = "ScriptableObjects/PhaseEvents/PhaseEventScriptableObject")]
public class PhaseEvent : ScriptableObject
{
    public PhaseEventType eventType;

}
