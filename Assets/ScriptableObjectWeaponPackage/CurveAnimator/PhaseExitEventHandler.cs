using UnityEngine;
public class PhaseExitEventHandler : MonoBehaviour,
IGameEventListener<GameObject>
{
    [SerializeField] GameObjectEvent phaseExitEvent;

    private void OnEnable() => phaseExitEvent.RegisterListener(this);
    private void OnDisable() => phaseExitEvent.UnregisterListener(this);

    public void OnEventRaised(GameObject item)
    {
        CurveAnimator hand = item.GetComponent<CurveAnimator>();

        PhaseEvent pe = hand.animSet[hand.indexOfAnimSet].phaseData[hand.animSet[hand.indexOfAnimSet].phaseIndex].phaseEvents[1];

        hand.SetEventsToNone();


        switch (pe.eventType)
        {
            case PhaseEventType.ActivateHitboxes:
                hand.GetComponentInChildren<Weapon>().colliders[0].gameObject.SetActive(true);
                break;
            case PhaseEventType.DeactivateHitboxes:
                hand.GetComponentInChildren<Weapon>().colliders[0].gameObject.SetActive(false);
                break;
            case PhaseEventType.Move:
                MovementEvent mve = (MovementEvent)pe;
                Debug.Log("Move " + mve.destination + " units of space over a course of " + mve.timeToTravel + " units of time.");
                break;
            case PhaseEventType.AddVelocity:
                AddVelocityEvent ave = (AddVelocityEvent)pe;
                Debug.Log("Physics move with velocity of: " + ave.newVelocity);
                break;
            case PhaseEventType.ApplyStatusEffect:
                ApplyStatusEffectEvent asee = (ApplyStatusEffectEvent)pe;
                foreach (ExampleStatusEffectScriptableObject se in asee.statusEffectsToApply)
                {
                    Debug.Log("Apply " + se.statusName);
                }
                break;
            case PhaseEventType.ActivateParticleSystem:
                ActivateParticlePhaseEvent appe = (ActivateParticlePhaseEvent)pe;
                Debug.Log("Activate " + appe.nameOfParticle);
                break;
            case PhaseEventType.None:
                break;
            default:
                break;
        }
    }

}

