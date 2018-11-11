using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BeamMovement : MonoBehaviour //Bogdan C. SU17A\\
{
    public float speed = 25f;
    public Rigidbody2D rb;
    public GameObject Beam;

    public int scoreValue;
    private GameController gameController;
    private float blinkLength = 0.5f;

    void Start()
    {
        rb.velocity = new Vector2(speed, 0);

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "basic" || other.tag == "strong" || other.tag == "tank" || other.tag == "shooting" || other.tag == "dodging" || other.tag == "dodgingshooting")
        {
            StartCoroutine(blinkRed(other.gameObject));
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }

    private IEnumerator blinkRed(GameObject o)
    {
        SpriteRenderer spr = o.GetComponent<SpriteRenderer>();
        spr.color = Color.red;
        yield return new WaitForSeconds(blinkLength);
        spr.color = Color.white;
    }

}
