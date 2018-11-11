using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingEnemy : EnemyMovement // Adam Brodin SU17A \\
{
    #region Variables
    public int rotationAmount = 180; // How many degrees the enemy rotates back and forth at a time
    public float randomChance = 50f; // Chance of the movement to be randomized (10%)
    public float fastRotMultiplier = 1f; // How fast the fast rotation is compared to normal (2 = 2x)
    public float rotationTime = 1f; // The total time it takes to rotate x degrees ^
    public float rotDelay = 0f;
    float y = 100f;
    float minY = -4.3f, maxY = 4.3f; // Set values for boundries of the world
    public bool fastRot = false;

    // MoveSpeed is inherited by Enemy class
    #endregion
    public override void Start()
    {
        base.Start();

        StartCoroutine(RandomMovement()); // Starts the movement coroutine
        StartCoroutine(RandomRotate(rotationTime, rotationAmount)); // Starts the rotation coroutine
    }

    public override void Movement()
    {
    }

    public IEnumerator RandomRotate(float time, float rotAm)
    {
        float t = 0f;

        if (Random.Range(0, 100) <= randomChance) // Randomly decides whether or not to rotate quickly
        {
            fastRot = true;
        }
        else
        {
            fastRot = false;
        }

        Quaternion startRot = transform.rotation; // Sets the base rotation to a variable for later usage

        while (t < time) // While x amount of time hasn't passed
        {
            t += Time.deltaTime;
            if (t >= time * 0.75f && fastRot == true) // When 75% of the loop is complete, change speed and rotation amount
            {
                rotAm = rotAm * fastRotMultiplier;
                t = 0; // Start the loop over again
                fastRot = false;
            }
            transform.rotation = startRot * Quaternion.AngleAxis(t / time * rotAm, Vector3.forward); // Change the rotation on the > axis under a certain amount of time
        }

        yield return new WaitForSeconds(rotDelay);

        StartCoroutine(RandomRotate(rotationTime, rotationAmount)); // Loops the method over and over again
    }

    private IEnumerator RandomMovement()
    {
        if (transform.position.y >= maxY) // If the enemy moves too far up on the screen (above 80% of full height)
        {
            y = (2 * moveSpeed) * -1; // Reverses the velocity to make it go down
        }
        else if (transform.position.y <= minY) // If the enemy moves too far down on the screen (below 20% of full height)
        {
            y = 2 * moveSpeed; // Adds velocity to make it go up
        }
        rb2d.velocity = new Vector2(-moveSpeed * Time.deltaTime, y * Time.deltaTime); // Sets the velocity of the enemy to go left (-x) and up/down (y) (y speed is 2x of x speed)

        yield return null;
        StartCoroutine(RandomMovement());
    }
}