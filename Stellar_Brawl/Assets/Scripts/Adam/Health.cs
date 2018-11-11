using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour // Adam Brodin SU17A \\
{
    #region Variables
    public GameObject explosion;
    private bool isDead = false;
    private Rigidbody2D rb2d_2;
    public GameObject gameoverUI;
    private float explosionTime = 0.25f;
    public int hp = 10;
    #endregion

    public void Start()
    {
        rb2d_2 = GetComponent<Rigidbody2D>();
        if (gameObject.tag == "player")
        {
            hp = 5; // The player's start hp
        }
    }

    protected virtual void Update()
    {
        CheckIfDead();
    }

    void CheckIfDead()
    {
        if (hp <= 0)
        {
            if (gameObject.tag == "player") // If gameObject is the player
            {
                if (!isDead)
                {
                    isDead = true;
                    gameOver();
                }
            }
            else // If this gameObject isn't a player, aka is an enemy
            {
                if (!isDead)
                {
                    isDead = true;
                    Destroy(gameObject); // Destroy enemy
                    GameObject clone = Instantiate(explosion, transform.position, transform.rotation); // Spawn the explosion prefab
                    Destroy(clone, explosionTime); // Destroy after x time
                }
            }
        }
    }

    void gameOver()
    {
        gameoverUI.SetActive(true); // Toggles the gameover ui
        Time.timeScale = 0f; // Freezes the game by setting the time to 0
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "playerbullet":
                if (gameObject.tag != "player")
                {
                    hp -= 1;
                    rb2d_2.AddForce(new Vector3(10, 0, 0));
                }
                break;
            case "shootingbullet":
                if (gameObject.tag == "player")
                {
                    hp -= 1;
                }
                break;
            case "dodgingshootingbullet":
                if (gameObject.tag == "player")
                {
                    hp -= 1;
                }
                break;
            default:
                Debug.Log("ERROR OCCURED @" + this);
                break;
        }
    }
}
