using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingShootingEnemy : DodgingEnemy // Adam Brodin SU17A \\
{
    public override void Start() // Adjusts some basic stats to fit this enemy better
    {
        base.Start();
        rotationAmount = -1;
        rotationTime = 1f;
        rotDelay = 0.01f;
        randomChance = 70f;
        fastRotMultiplier = 10;
    }
}


