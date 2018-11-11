using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyWeapon : MonoBehaviour //Bogdan C. SU17A\\
{
    public Transform firepointTop;
    public GameObject beamPrefab;

    public void Start()
    {
        StartCoroutine(waitShoot());
    }

    private IEnumerator waitShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Delay between shots
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(beamPrefab, firepointTop.position, Quaternion.Euler(0, 0, 90));
    }
}
