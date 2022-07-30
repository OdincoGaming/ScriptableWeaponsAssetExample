using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PhaseEvents/MovementEventcriptableObject")]
public class MovementEvent : PhaseEvent
{
    public Vector3 destination;
    public float timeToTravel;
}
