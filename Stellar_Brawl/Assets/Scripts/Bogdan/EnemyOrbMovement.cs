using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrbMovement : MonoBehaviour
{
    public float speed = -10f;
    public Rigidbody2D rb;
    public GameObject Beam;
    Transform beamPrefab;

    void Start()
    {
        rb.velocity = new Vector2(speed * 1, 0);
       // var beam = Instantiate(beamPrefab) as Transform;
        Physics2D.IgnoreCollision(Beam.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void OnCollisionEnter2D(Collision2D objectYouCollidedWith)
    {
        Destroy(Beam);
    }
}
