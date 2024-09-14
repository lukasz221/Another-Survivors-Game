using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public string weaponName;
    public int damage;
    public float range;
    public float fireRate; // czas między strzałami
    public int maxAmmo;
    public int currentAmmo;
    public bool isReloading = false;

    public Transform firePoint; // Punkt, z którego wystrzeliwane są pociski
    public GameObject bulletPrefab; // Prefab pocisku

    public virtual void Shoot() { }

    public virtual void Reload()
    {
        if (isReloading) return;
        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(2f); // czas przeładowania
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
