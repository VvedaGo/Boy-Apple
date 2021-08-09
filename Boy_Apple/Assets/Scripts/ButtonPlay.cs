using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class ButtonPlay : MonoBehaviour
{
    [SerializeField] GameObject Score;
    [SerializeField] GameObject StartPanel;
    [SerializeField] GameObject Difficilt;
    public void Awake()
    {
        int bestScore = PlayerPrefs.GetInt("s2d3d11");
        Score.GetComponent<Text>().text = Convert.ToString(bestScore);
    }
    public void StartScene() 
    {

        StartPanel.SetActive(false);
        Difficilt.SetActive(true);
    }
    public void EasyLevel()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("difficult", 0);
    }
    public void NormalLevel()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("difficult", 1);
    }
    public void HardLevel()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("difficult", 2);
    }

}
