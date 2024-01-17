using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public int gemCount = 10;
    public int killCount = 0;

    public TextMeshProUGUI gemText;
    public TextMeshProUGUI killText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI timerText;
    public AudioSource source;
    public AudioClip gemClip;


    void Start()
    {
        gemText.text = "Gems left = " + gemCount;
        killText.text = "Enemies Killed = 0";
    }

    public void IncreaseGemCount()
    {
        source.PlayOneShot(gemClip);
        gemCount--;
        gemText.text = "Gems Left = " + gemCount;

        if(gemCount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void IncreaseKillCount()
    {
        killCount++;
        killText.text = "Enemies Killed = " + killCount;
    }

    public void SetHealth(int health)

    {
        healthText.text = "Player Health = " + health;
    }

    public void SetTimer(float timer)

    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("OXYGEN- {0:00}:{1:00}", minutes, seconds);
    }
}