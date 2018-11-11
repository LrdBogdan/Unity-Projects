using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour //Bogdan C. SU17A\\
{
    public Transform firepointTop;
    public Transform firepointDown;
    public GameObject beamPrefab;
    bool canShoot = true;
	
	void Update ()
    {
		if (Input.GetButton("Jump") && canShoot)
        {
            canShoot = false;
            StartCoroutine(Shoot());
        }
	}

    // Spawns BeamPrefabs wich as bullets
    private IEnumerator Shoot()
    {
        Instantiate(beamPrefab, firepointTop.position, firepointTop.rotation);
        Instantiate(beamPrefab, firepointDown.position, firepointDown.rotation);
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
        //  Debug.Log("SHOOT!");
    }


}
