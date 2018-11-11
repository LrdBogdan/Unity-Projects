using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health // Adam Brodin SU17A \\
{
    #region Variables
    public int moveSpeed, damage, type;
    public float cooldown;
    #endregion
    public new virtual void Start()
    {
        base.Start();
        SetType();
    }

    void SetType()
    {
        // Sets the type for each specific enemy type and then assigns its stats
        switch (gameObject.tag)
        {
            // SetStats = (hp, moveSpeed, damage, type, cooldown)
            case "basic":
                SetStats(3, 100, 0, 1, 0);
                break;
            case "strong":
                SetStats(12, 50, 0, 2, 0);
                break;
            case "tank":
                SetStats(21, 25, 0, 3, 0);
                break;
            case "shooting":
                SetStats(9, 35, 2, 4, 0.5f);
                break;
            case "dodging":
                SetStats(12, 100, 0, 5, 0);
                break;
            case "dodgingshooting":
                SetStats(10, 80, 1, 6, 1f);
                break;
            default:
                Debug.LogError("ERROR OCCURRED: no type found @" + this);
                break;
        }
    }

    void SetStats(int h, int m, int d, int t, float c)
    {
        // Sets the stats for the enemy
        hp = h; // Hp is inherited by Health class
        moveSpeed = m;
        damage = d;
        type = t;
        cooldown = c;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "playerbullet") // If enemy gets hit by player bullet/beam
        {
            hp -= 1;
        }
    }
}
