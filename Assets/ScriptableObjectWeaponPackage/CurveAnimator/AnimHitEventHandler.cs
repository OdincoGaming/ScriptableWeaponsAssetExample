using UnityEngine;
public class AnimHitEventHandler : MonoBehaviour,
IGameEventListener<GameObject>
{
    [SerializeField] GameObjectEvent animHitEvent;

    private void OnEnable() => animHitEvent.RegisterListener(this);
    private void OnDisable() => animHitEvent.UnregisterListener(this);

    public void OnEventRaised(GameObject item)
    {
        Debug.Log("Hit: " + item.name);
    }

}

