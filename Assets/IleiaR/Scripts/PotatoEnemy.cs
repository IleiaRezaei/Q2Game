using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoEnemy : MonoBehaviour
{

    public Sprite sprite1;
    public Sprite sprite2;

    private SpriteRenderer spriteRenderer;

    private Animator anim_potato;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite1;

        anim_potato = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeColor()
    {
        if(spriteRenderer.sprite == sprite1)
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ChangeColor();
            Invoke("ChangeColor", 1);
            anim_potato.Play("attackD");

        }
    }
}
