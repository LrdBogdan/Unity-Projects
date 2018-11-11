using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovement : Enemy // Adam Brodin SU17A \\
{
    #region Variables
    public Rigidbody2D rb2d;
    SpriteRenderer spr;
    #endregion
    public override void Start()
    {
        base.Start();
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        spr.flipX = false; // All enemys should be pointing to the left
    }

    public virtual void Movement()
    {
        float x, y, rot;

        // For types 1-4 only \\
        rot = 90; // Sets default rotation
        x = moveSpeed; // Moves the enemy at the enemy type's speed
        y = 0;
        rb2d.rotation = rot;
        // For types 1-4 only \\

        rb2d.velocity = new Vector2((x * -1) * Time.deltaTime, y);
    }

    protected override void Update()
    {
        base.Update();
        Movement();
    }

}
