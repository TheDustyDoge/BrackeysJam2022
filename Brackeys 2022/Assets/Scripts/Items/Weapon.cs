using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 10;
    public float attackDelay = 0.5f;

    // ==================================================

    public bool IsAttacking { get; private set; }
    public bool AttackReady { get {return remainingDelay < 0; } }
    private float remainingDelay = 0;

    private Quaternion TEMP_defaultRotation;

    // ==================================================

    private void Awake()
    {
        SetWeaponActive(false);
        TEMP_defaultRotation = transform.rotation;
    }

    public void SetWeaponActive(bool isActive)
    {
        gameObject.SetActive(isActive);
        remainingDelay = attackDelay;
        transform.rotation = TEMP_defaultRotation;
        IsAttacking = false;
    }

    // ==================================================

    private void Update()
    {
        if (!AttackReady)
        {
            remainingDelay -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (!AttackReady)
        {
            return;
        }

        // TODO: real attack / remove temp objects
        StartCoroutine(TEMP_Attack());
        remainingDelay = attackDelay;
    }

    // ==================================================

    private IEnumerator TEMP_Attack()
    {
        IsAttacking = true;
        transform.rotation = transform.rotation * Quaternion.Euler(0, 0, -45);
        yield return new WaitForSeconds(attackDelay);
        transform.rotation = TEMP_defaultRotation;
        IsAttacking = false;
    }

}
