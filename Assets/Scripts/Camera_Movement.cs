using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    public Vector3 offset;

    void Start()
    {
        //offset = transform.position - target.transform.position; //follow player at certain distance
        offset = new Vector3(0f, 10f, -10f);
    }
    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(45, 0, 0); //get 45° angle
        transform.rotation = rotation;
        //check if target exists
        if (target != null)
        {
            //change camera position with player position
            Vector3 newPosition = target.transform.position + offset;
            transform.position = newPosition;
        }
    }
}
