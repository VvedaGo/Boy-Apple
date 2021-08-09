using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject player;
    Rigidbody2D Rb;
    public float speed = 3;
    public Vector2 Move = new Vector2(0, 0);
    bool on = false;
   
    public Animator animRun;

    void Start()
    {
        Rb = player.GetComponent<Rigidbody2D>();
        animRun = player.GetComponent<Animator>();
    }

    void FixedUpdate()
    { if (on)

            Rb.velocity = new Vector2(-speed, Rb.velocity.y);

}
public void OnPointerEnter(PointerEventData eventData)
    {
        on = true;
        player.transform.localScale = new Vector3(-0.7f, 0.7f, 1);
        animRun.SetBool("isRunning", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        on = false;
        Rb.velocity = Move;
        animRun.SetBool("isRunning", false);
    }
}
