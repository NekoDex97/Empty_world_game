using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        movement p = collision.GetComponent<movement>();
        if (collision.CompareTag("Player"))
        {
            p.setHp(3);
            if(p.itemCount<=3)
                p.itemCount+=1;
            if (p.itemCount == 3)
                p.manager.GetComponent<SpriteRenderer>().color = Color.clear;
            p.health.setCount(p.itemCount);
            this.gameObject.SetActive(false);

        }
    }
}
