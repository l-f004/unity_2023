using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private GameObject _spawnManager;
    [SerializeField] private GameObject _player;

    private int _level = 1;

    void Start()
    {
        //_level = _player.gameObject.GetComponent<Player_Script>()._level;
        _level = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        //check collision with player
        if(other.CompareTag("Player"))
        {
            
            //in level 1
            if(_level == 1 && _spawnManager.gameObject.GetComponent<Spawn_Manager>()._score > 2)
            {
                SceneManager.LoadScene(1);
                _player.gameObject.GetComponent<Player_Script>().NewLevel(_level);
            }
            //in level 2
            else if(_level == 2 && _spawnManager.gameObject.GetComponent<Spawn_Manager>()._score > 4)
            {
                SceneManager.LoadScene(2);
                _player.gameObject.GetComponent<Player_Script>().NewLevel(_level);
            }
            //in level 3
            else if(_level == 3 && _spawnManager.gameObject.GetComponent<Spawn_Manager>()._score > 7)
            {
                _player.gameObject.GetComponent<Player_Script>().EndGame();
            }
        }
    }


}
