using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PLayer : MonoBehaviour
{
    GameObject score;
    public int point;
    
    public Animator animRun;
    public AudioClip clip;
   

    void Start()
    {
        
        score = GameObject.Find("Score");
        gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 1);
               
    }

    public void PlayAudio()
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int checkBestPoint;
        if (collision.gameObject.tag == "Apple")
        {
            PlayAudio();
            Destroy(collision.gameObject);
            point += 1;
            GameObject.FindWithTag("MainCamera").GetComponent<Spawner>().reload -= 50;
            score.GetComponent<Text>().text = Convert.ToString(point);

        }
        else if (collision.gameObject.tag == "Box")
        {
            checkBestPoint = PlayerPrefs.GetInt("s2d3d11");
            Destroy(gameObject);
            if (checkBestPoint < point)
            {
                PlayerPrefs.SetInt("s2d3d11", point);
            }
            GameObject.FindWithTag("MainCamera").GetComponent<Death>().DeathPlayer();
        }
    }
    

}