using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behavior : MonoBehaviour
{

    [SerializeField] private Rigidbody RB;
    [SerializeField] private float _bulletSpeed = 5f;


    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _bulletSpeed); //bullet forward movement

        //bullets vanish when out of game area
        if(transform.position[0] >40 || transform.position[2] > 40 || transform.position[0] < -30|| transform.position[2] < -30)
        {
            Destroy(this.gameObject);
        }
    }
}
