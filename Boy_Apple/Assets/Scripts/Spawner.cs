using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject box;
    public GameObject apple;
    int timer=900;
    Vector3 spawnPos;
    public int reload = 900;
    private double waitBox=0.9f;
    private int _timeForSpawn;
    private float _difficult;
    private float _waitForBlock;
    private float _difficultLevel;
    private void Start()
    {
        _difficult = PlayerPrefs.GetInt("difficult");
        _waitForBlock = Difficult;
        box.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
    }

    private float Difficult
    {
        set 
        {
            _difficult = value;
        }
        get
        {
            switch (_difficult)
            {
                case 0:
                    _difficultLevel = 0.2f;
                    break;
                case 1:
                    _difficultLevel = 0.1f;
                    break;
                case 2:
                    _difficultLevel = 0.05f;
                    break;

            }
         return _difficultLevel;
        }
    }
    void FixedUpdate()
    {
       
        _timeForSpawn = (int)(reload * waitBox);
        timer--;
        
        if (timer == 0 && reload > 100)//speed up for spawn block
        {
            timer = reload;
            spawner(2);
        }
        
        else if (timer ==_timeForSpawn)
        {
           
            spawner(1);
            waitBox -= _waitForBlock;
            if (waitBox <= 0)
            {
                waitBox = 0.9f;
            }
           
        }
     
    } 
    void spawner(int thing)//1-box 2-apple
    {
        spawnPos = new Vector3(Random.Range(-8, 8), 8, 0);
        switch (thing)
        {
            case 1:
                
               GameObject spawnBox= Instantiate(box, spawnPos, Quaternion.identity);
                if (spawnBox.GetComponent<Rigidbody2D>().gravityScale <= 1)
                {
                    box.GetComponent<Rigidbody2D>().gravityScale += 0.05f;
                }
                break;
            case 2:
                
                Instantiate(apple, spawnPos, Quaternion.identity);
                break;
        }
    }
   
}
