using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponSO weaponData;

    public CurveAnimator debugHand;

    public List<Collider> colliders;

    private void Awake()
    {
        debugHand.LoadAnimSet(weaponData);
    }

    public void EnableCollider(int i)
    {
        colliders[i].gameObject.SetActive(true);
    }

    public void DisableColliders()
    {
        foreach(Collider c in colliders)
        {
            c.gameObject.SetActive(false);
        }
    }
}
