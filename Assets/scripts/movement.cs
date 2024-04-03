using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    
    public float vel;
    Vector3 offset;
    Vector3 lastClicked;
    Vector3 look;
    bool moving = false;
    public Transform respawn;
    Animator anim;
    //stats
    public int hp;
    public heathUI health;
    public int itemCount;
    public Manager manager;

    void Start()
    {
        //transform = GetComponent<Transform>();
        offset = new Vector3(0,0,9);
        anim = GetComponent<Animator>();
        health.setValue(5);
        restart();
    }

    // Update is called once per frame
    void Update()
    {
        look= Camera.main.ScreenToWorldPoint(Input.mousePosition)+offset;
        if (Input.GetMouseButtonDown(0))
        {
            lastClicked = look;
            
            moving = true;
            transform.right = look - transform.position;
            
            
        }

        if (moving && lastClicked!=transform.position )
        {
            transform.position = Vector3.MoveTowards(transform.position, lastClicked, vel * Time.deltaTime);
            //transform.position.Set(transform.position.x, transform.position.y, -1);
            anim.SetBool("walking", true);

        }
        else
        {
            moving = false;
            transform.right = look - transform.position;
            anim.SetBool("walking", false);
        }
  
    }

     public void setHp(int i=1)
    {
        
        hp+=i;
        if (hp >= 5) hp = 5;
        if (hp <= 0)
        {
            
            manager.restartGame();
        }
        health.setValue(hp);
    }

 

    public void restart()
    {
        hp = 5;
        transform.right = Vector3.right;
        moving = false;
        transform.position = respawn.position;
        itemCount = 0;
        health.setValue(5);
        health.setCount(0);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Object"))
        {
            moving = false;
            
        }
        
    }

}
