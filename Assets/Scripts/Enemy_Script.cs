//#include <cstdlib>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Script : MonoBehaviour
{

    [SerializeField] private float _enemySpeed = 5;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _enemySpeed); //downwards movement
        
        //make enemies vanish below ground
        if(transform.position.y < 0f)
        {
            Destroy(this.gameObject);
        }
    }

    //collisions
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            this.transform.parent.gameObject.GetComponent<Spawn_Manager>().UpdateScore();
            Destroy(this.gameObject);
        }
        else if(other.CompareTag("Player"))
        {
            //Debug.Log("Enemy collided with player");
            other.gameObject.GetComponent<Player_Script>().damage();
        }
    }
}
