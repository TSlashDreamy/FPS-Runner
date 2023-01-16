using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] float timeBetweenShots = 1f;
    [SerializeField] float pullingWeaponTime = .5f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject impactVFX;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;

    bool canShoot = true;
    bool alreadyShooted = false;

    void OnEnable()
    {
        StartCoroutine(PullWeapon());  
    }

    void Start()
    {
        ammoText = GameObject.FindGameObjectWithTag("AmmoText").GetComponent<TextMeshProUGUI>();    
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCurrentAmmo();
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayCurrentAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    IEnumerator PullWeapon()
    {
        if (alreadyShooted)
        {
            yield return new WaitForSeconds(timeBetweenShots);
        }
        else 
        {
            yield return new WaitForSeconds(pullingWeaponTime);
        }
        
        canShoot = true;
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        alreadyShooted = true;

        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        else
        {
            Debug.Log($"Bruh, you ran out for {ammoType} ammo");
        }

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
        alreadyShooted = false;
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateImpactVFX(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    void CreateImpactVFX(RaycastHit hit)
    {
        GameObject hitVFX = Instantiate(impactVFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitVFX, 0.1f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(FPCamera.transform.position, FPCamera.transform.forward * range);
    }
}
