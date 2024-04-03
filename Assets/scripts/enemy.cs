using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float vel;
    Vector3 offset;
    public GameObject eyes;
    public int damage;
    [SerializeField]
    float rate;
    float nexthit;
    public Transform spawnPoiint;

    void Start()
    {
        offset = new Vector3(1f, 1f, 0);
        eyes.SetActive(false);
    }

    public void respawn()
    {
        transform.position = spawnPoiint.position;
        eyes.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eyes.SetActive(true);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.isTrigger)
            transform.position = Vector3.MoveTowards(transform.position, collision.transform.position, vel * Time.deltaTime)+offset*Time.deltaTime;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eyes.SetActive(false);

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            nexthit -= Time.deltaTime;
            if (nexthit <= 0)
            {
                collision.transform.GetComponent<movement>().setHp(damage*-1);
                nexthit = rate;
            }

        }
        
    }
}
