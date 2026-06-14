using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   public GameObject [] LoadOut;
   public Transform WeaponParent;
   public GameObject CurrentWeapon;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        Eqiup(0);
        
    }
    void Eqiup(int p_ind)
    {
        if (CurrentWeapon!=null)
        Destroy(CurrentWeapon);
        GameObject newWeapon  = Instantiate(LoadOut[p_ind] ,WeaponParent.position, WeaponParent.rotation, WeaponParent) as GameObject;
        newWeapon.transform.localPosition = Vector3.zero;
        newWeapon.transform.localEulerAngles = Vector3.zero;
        CurrentWeapon = newWeapon;
    }
}
