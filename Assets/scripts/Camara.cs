using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

    public Transform player;
    public float vel;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        player = player.GetComponent<Transform>();
        offset = new Vector3(3, 0, -9);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,player.position+offset,vel*Time.deltaTime);
    }
}
