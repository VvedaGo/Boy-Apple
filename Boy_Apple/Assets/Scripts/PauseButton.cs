using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour, IPointerEnterHandler
{
    int i = 0;
    public void OnPointerEnter(PointerEventData eventData)
    {
       
        if (i == 0)
        {
            i = 1;
            Time.timeScale = 0f;
            GameObject.Find("Background").GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 145);
            GameObject.Find("Background").GetComponent<AudioSource>().mute = true;
        }
        else if (i == 1)
        {
            Time.timeScale = 1f;
            GameObject.Find("Background").GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            i = 0;
            GameObject.Find("Background").GetComponent<AudioSource>().mute = false;
        }

    }

    
}
