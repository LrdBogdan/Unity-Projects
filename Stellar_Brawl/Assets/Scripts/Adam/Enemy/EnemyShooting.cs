using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : Enemy // Adam Brodin SU17A \\
{
    #region Variables
    public Transform[] shootingSpots = new Transform[5]; // Total of 5 shooting spots
    public GameObject bullet;
    #endregion

    public override void Start()
    {
        base.Start();
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        for (int i = 0; i < shootingSpots.Length; i++) // Loops through every single shooting spot and shoots from each one
        {
            Instantiate(bullet, shootingSpots[i].position, shootingSpots[i].rotation); // Spawn one bullet accordingly ^
            yield return new WaitForSeconds(cooldown); // Waits before looping again
        }

        StartCoroutine(Shoot());
    }
}
