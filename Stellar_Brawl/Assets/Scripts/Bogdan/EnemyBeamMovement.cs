using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]


public class EnemyBeamMovement : MonoBehaviour //Bogdan C. SU17A\\
{
    public float speed = -15f;
    public Rigidbody2D rb;
    public GameObject Beam;
    Transform beamPrefab;

    void Start()
    {
        rb.velocity = new Vector2(speed * 1,0);
        //var b = Instantiate(beamPrefab) as Transform;
        //Physics2D.IgnoreCollision(b.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void OnCollisionEnter2D(Collision2D objectYouCollidedWith)
    {
        Destroy(Beam);
    }
}
