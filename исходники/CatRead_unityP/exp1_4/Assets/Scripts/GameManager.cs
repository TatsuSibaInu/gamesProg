using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject pnlSetings, pnlLib;

    private void Start()
    {
        if(pnlSetings != null)
            pnlSetings.SetActive(false);
        if (pnlLib != null)
            pnlLib.SetActive(false);
    }

    public void Play() 
    {
        SceneManager.LoadScene("Play");
    }

    public void Read()
    {
        SceneManager.LoadScene("MyLibery");
    }

    public void Back()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BackPlay()
    {
        SceneManager.LoadScene("Play");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Reset()
    {
        PlayerPrefs.SetFloat("satiety", 100);
        PlayerPrefs.SetFloat("happy", 100);
        PlayerPrefs.SetFloat("enegy", 100);
        PlayerPrefs.SetFloat("coins", 0);
        PlayerPrefs.SetInt("eat", 0);
    }

    public void Settings()
    {
        if (pnlSetings.activeSelf == false) 
        {
            pnlSetings.SetActive(true);
        }
        else
        {
            pnlSetings.SetActive(false);
        }
    }

    public void LiberySet()
    {
        if (pnlLib.activeSelf == false)
        {
            pnlLib.SetActive(true);
        }
        else
        {
            pnlLib.SetActive(false);
        }
    }


   
}
