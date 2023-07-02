using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private TMP_Text _livestext;
    [SerializeField] private TMP_Text _scoretext;
    [SerializeField] private TMP_Text _levelstext;
    [SerializeField] private TMP_Text _usertext;

    //text for lives
    public void UpdateLives(int health)
    {
        _livestext.text = "Lives: " + health;
    }

    //text for game over
    public void UpdateDeath()
    {
        _usertext.text = "GAME OVER!";
    }

    //text for score
    public void UpdateScore(int score)
    {
        _scoretext.text = "Score: " + score;
    }

    //text for instructions
    public void UpdateUserText()
    {
        _usertext.text = "Find the pole!";
    }

    //other text for instructions
    public void ResetUserText()
    {
        _levelstext.text = "Let´s shoot some enemies (press \"e\")!";
    }

    //text for level
    public void UpdateLevel(int level)
    {
        _levelstext.text = "Level: " + level;
        ResetUserText();
    }

    //text for winning game
    public void EndGame()
    {
        _usertext.text = "YOU WON!";
    }




}
