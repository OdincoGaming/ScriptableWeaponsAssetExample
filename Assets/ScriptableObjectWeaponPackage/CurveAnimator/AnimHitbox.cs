using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class AnimHitbox : MonoBehaviour
{
    [SerializeField] GameObjectEvent AttackHitEvent;


    private void OnTriggerEnter(Collider other)
    {
        AttackHitEvent.Raise(other.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        AttackHitEvent.Raise(other.gameObject);
    }
}
