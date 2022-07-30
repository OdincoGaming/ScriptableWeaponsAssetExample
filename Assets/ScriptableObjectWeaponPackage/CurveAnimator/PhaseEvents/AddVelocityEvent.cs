using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PhaseEvents/AddVelocityEventScriptableObject")]
public class AddVelocityEvent : PhaseEvent
{
    public Vector3 newVelocity;
}
