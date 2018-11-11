using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenceline : MonoBehaviour
{
    public GameObject gameoverUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "shootingbullet")
        {
            GameOver();
            Debug.Log("entered");
        }

    }

    public void GameOver()
    {
        gameoverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
