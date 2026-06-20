using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //tập hợp các đối tướng.

   public Guns  [] LoadOut;
   private int index;
   public Transform WeaponParent;
  private GameObject CurrentWeapon;
  public GameObject BulletPrefabs;
  public LayerMask canBeShot;
  private Vector3 currentRotation;
private Vector3 targetRotation;

private Vector3 currentPosition;
private Vector3 targetPosition;

public float snappiness = 10f;
public float returnSpeed = 20f;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        Eqiup(0);
        if(CurrentWeapon!=null)
        {
            aim(Input.GetMouseButton(1));
            if(Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero,returnSpeed * Time.deltaTime);

        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappiness * Time.deltaTime);

        targetPosition = Vector3.Lerp(targetPosition, Vector3.zero, returnSpeed * Time.deltaTime);

        currentPosition = Vector3.Lerp(currentPosition, targetPosition,snappiness * Time.deltaTime);

        CurrentWeapon.transform.localRotation =Quaternion.Euler(currentRotation);

         CurrentWeapon.transform.localPosition = currentPosition;
    }
    void Eqiup(int p_ind)
    {
        if (CurrentWeapon!=null)
        Destroy(CurrentWeapon);
        index = p_ind;
        GameObject newWeapon  = Instantiate(LoadOut[p_ind].prefads ,WeaponParent.position, WeaponParent.rotation, WeaponParent) as GameObject;
        //đối tượng sinh ra (súng nục,......)
        newWeapon.transform.localPosition = Vector3.zero;
        newWeapon.transform.localEulerAngles = Vector3.zero;
        CurrentWeapon = newWeapon;
    }
    void aim(bool p_aim)
    {
        Transform anchor = CurrentWeapon.transform.GetChild(0);
        Transform Status_hip = CurrentWeapon.transform.GetChild(0).GetChild(1);
        Transform Status_ads = CurrentWeapon.transform.GetChild(1).GetChild(1);
        if(p_aim)
        {
            anchor.position = Vector3.Lerp(anchor.position, Status_ads.position, Time.deltaTime*LoadOut[index].AimSpeed);
        }
        else
        {
            anchor.position = Vector3.Lerp(anchor.position, Status_hip.position, Time.deltaTime*LoadOut[index].AimSpeed);
        }
        
    }
  void Shoot()
{
    Transform t_cam = transform.Find("Camera");
    RaycastHit hit;

    if (Physics.Raycast(t_cam.position, t_cam.forward,
        out hit, 100f, canBeShot))
    {
        GameObject NewHole = Instantiate(
            BulletPrefabs,
            hit.point + hit.normal * 0.001f,
            Quaternion.identity);

        NewHole.transform.LookAt(hit.point + hit.normal);
        Destroy(NewHole, 5f);
    }

    // Giật lên
    targetRotation += new Vector3(-LoadOut[index].Recoil,Random.Range(-1f, 1f), 0f);

    // Lùi về sau
    targetPosition += new Vector3(0, 0, -LoadOut[index].KickBack);
}

public float swayAmount = 2f;
public float swaySmooth = 8f;

void WeaponSway()
{
    float mouseX = Input.GetAxis("Mouse X");
    float mouseY = Input.GetAxis("Mouse Y");

    Quaternion target =Quaternion.Euler(-mouseY * swayAmount,mouseX * swayAmount, 0);

    CurrentWeapon.transform.localRotation *=Quaternion.Slerp( Quaternion.identity, target,swaySmooth * Time.deltaTime);
}
}
