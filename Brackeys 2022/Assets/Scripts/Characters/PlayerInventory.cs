using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Weapon> weapons;

    // ==================================================

    public Weapon equippedWeapon { get; private set; }
    private int weaponIndex = -1;

    // ==================================================

    private void Start()
    {
        ModWeaponIndex(1);
    }

    // ==================================================

    public void NextWeapon()
    {
        ModWeaponIndex(1);
    }

    public void PreviousWeapon()
    {
        ModWeaponIndex(-1);
    }

    private void ModWeaponIndex(int mod)
    {
        if (weapons.Count <= 0)
        {
            return;
        }

        int newWeaponIndex = weaponIndex + mod;
        if (newWeaponIndex < 0)
        {
            newWeaponIndex += weapons.Count;
        }
        else if (newWeaponIndex >= weapons.Count)
        {
            newWeaponIndex -= weapons.Count;
        }

        equippedWeapon?.SetWeaponActive(false);
        weaponIndex = newWeaponIndex;
        equippedWeapon = weapons[weaponIndex];
        equippedWeapon?.SetWeaponActive(true);
    }


}
