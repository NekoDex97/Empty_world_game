using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public movement player;
    public enemy[] enemies;
    public GameObject winScreen;
    public GameObject panel;
    public GameObject[] items;
    void Start()
    {
        Time.timeScale = 0;
        restartGame();
    }

    // Update is called once per frame

    public void begin(GameObject pan)
    {
        pan.SetActive(false);
        Time.timeScale = 1;
    }

    public void restartGame()
    {
        winScreen.SetActive(false);
        panel.SetActive(true);
        player.restart();
        respawnEnemies(enemies);
        SetItems(items);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void respawnEnemies(enemy[] enemies)
    {
        foreach(enemy e in enemies)
        {
            e.respawn();
        }
    }

    void SetItems(GameObject[] items)
    {
        foreach(GameObject item in items)
        {
            item.SetActive(true);
        }
    }

    void win()
    {
        Time.timeScale=0;
        winScreen.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && collision.GetComponent<movement>().itemCount >= 3)
        {
            win();
        }
    }
}
