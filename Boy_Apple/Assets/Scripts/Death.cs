using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour
{
    public GameObject deathImage;
    GameObject spawnDeath;
    public GameObject menu;
    public GameObject reset;
    [SerializeField] GameObject mainCamera;
    public void ClickMenu() 
    {
        SceneManager.LoadScene(0);
    }
    public void ClickReset()
    {
        
        SceneManager.LoadScene("Game");
    }
    public void DeathPlayer()
    {
        mainCamera.GetComponent<Spawner>().enabled = false;
        spawnDeath = Instantiate(deathImage, new Vector3(0, 2, 2), Quaternion.identity);
        StartCoroutine(FadeOn());
    }

    IEnumerator FadeOn()
    {
        Color32 colorFade = spawnDeath.GetComponent<SpriteRenderer>().color;
        for (int i = 0; i < 255; i++)
        {
            colorFade.a += 1;
            spawnDeath.GetComponent<SpriteRenderer>().color = colorFade;
            
            yield return new WaitForSeconds(0.01f);
            if (i == 254)
            {
                menu.transform.position = new Vector3(-1.5f, -2, 1);
                reset.transform.position = new Vector3(1.5f, -2, 1);
            }
        }

    }
}
