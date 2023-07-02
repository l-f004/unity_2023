using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Spawn_Manager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _delay = 0.7f;

    [SerializeField] private UI_Manager _uiManager;

    [SerializeField] private GameObject _portal;

    public int _score = 0;

    private bool _alive = true;

    void Start()
    {
        _portal.gameObject.SetActive(false); //make pole invisible
        StartCoroutine(SpawnSystem());
    }

    void Update()
    {
        ActivatePortal();
    }

    //Spawn enemies
    IEnumerator SpawnSystem()
    {
        while(_alive)
        {
            Instantiate(_enemyPrefab, transform.position + new Vector3(Random.Range(-15f,15f), 10f, Random.Range(-5f, 25f)), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(_delay);
        }
        
    }

    public void OnPlayerDeath()
    {
        _alive = false;
    }

    //update score
    public void UpdateScore()
    {
        _score++;
        _uiManager.UpdateScore(_score);
    }

    //pole is made visible if score is high enough (pole is not the real portal but its indicator)
    private void ActivatePortal()
        {
            if((SceneManager.GetActiveScene().name=="Game Scene" &&_score > 2) || (SceneManager.GetActiveScene().name=="Level 2" &&_score > 4) || (SceneManager.GetActiveScene().name=="Level 3" &&_score > 7))
            {
                _portal.gameObject.SetActive(true);
                if(SceneManager.GetActiveScene().name!="Level 3")
                {
                    _uiManager.UpdateUserText();
                }
            }
        }
}
