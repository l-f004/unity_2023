using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Script : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private Rigidbody RB;
    private float _jumpingSpeed = 10f;

    private float _nextFireTime = 0f;
    private float _fireCooldownTime = 0.5f; //0.5f

    private int _lives = 3;

    public Vector3 _lastDir = Vector3.forward;



    [SerializeField] private GameObject _bulletPrefab;

    private float _colourchannel = 1f;
    private MaterialPropertyBlock _mpb;

    [SerializeField] private GameObject _spawnManager;

    [SerializeField] private UI_Manager _uiManager;

    public int _level = 1;


    void Start()
    {
        _uiManager.UpdateLives(_lives);

        transform.position = new Vector3(x:0f, y:0f, z:0f);

        // SET MATERIAL
        if (_mpb == null)
        {
            _mpb = new MaterialPropertyBlock();
            _mpb.Clear();
        }
    }

    void Update()
    {
        PlayerMovement();

        //fire bullets
        if (Input.GetKeyDown("e") && _nextFireTime < Time.time)
        {
            Instantiate(_bulletPrefab, transform.position + new Vector3(0f, 0f, 1.1f), Quaternion.identity);
            _nextFireTime = Time.time + _fireCooldownTime;
        }

    }

    //get damage
    public void damage()
    {
        _lives --;
        _uiManager.UpdateLives(_lives);
        _colourchannel -= 0.3f;
        _mpb.SetColor("_Color", new Color(0f, _colourchannel, 0f, 1f));
        this.GetComponent<Renderer>().SetPropertyBlock(_mpb);
        if(_lives == 0)
        {
            if(_spawnManager != null)
            {
                _uiManager.UpdateDeath();
                _spawnManager.GetComponent<Spawn_Manager>().OnPlayerDeath();
                Destroy(this.gameObject); //delete player
            }
            else
            {
                Debug.LogError("SpawnManager not assigned!");
            }

            //delete enemy instances
            foreach(Transform child in _spawnManager.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    void PlayerMovement()
    {
        int count = 0;
        //move to left and right
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
        
        
       
        //move forward and backward
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * _speed * verticalInput);
        

        //jump when space is pressed and come to stop again
        if (Input.GetKeyDown("space") & (RB.velocity[1] == 0) & (count%2 == 0)) //only when on ground
        {
            RB.velocity += new Vector3(0f, _jumpingSpeed, 0f);
            if (RB.velocity[1]==0)
            {
                count += 1;
            }
        }

        //teleporting back if y-position is lower than -20
        if (transform.position.y<-20)
        {
            transform.position = new Vector3(x:0f, y:3f, z:0f);
        }
    }


    //called if new level is entered
    public void NewLevel(int level)
    {
        _lives = 3;
        _uiManager.UpdateLevel(level);
    }

    //called when game is over
    public void EndGame()
    {
        _uiManager.EndGame();
        _spawnManager.GetComponent<Spawn_Manager>().OnPlayerDeath();
        Destroy(this.gameObject);
        foreach(Transform child in _spawnManager.transform)
        {
            Destroy(child.gameObject);
        }
    }

}
