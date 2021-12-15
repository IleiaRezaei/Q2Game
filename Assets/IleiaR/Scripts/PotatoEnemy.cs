using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoEnemy : MonoBehaviour
{

    public Sprite sprite1;
    public Sprite sprite2;

    private SpriteRenderer spriteRenderer;

    private Animator anim_potato;
    public bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite1;

        anim_potato = GetComponent<Animator>();

        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking == true)
        {
            anim_potato.SetBool("isAttacking", true);

        }
        if (isAttacking == false)
        {
            anim_potato.SetBool("isAttacking", false);
        }
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
            //ChangeColor();
            Invoke("ChangeColor", 1);
            //anim_potato.SetBool("isAttacking", true);
            //anim_potato.Play("attackD");
            Debug.Log("Fart");
            isAttacking = true;
        }
        else
        {
            Debug.Log("baljeet");
            isAttacking = false;
            //anim_potato.SetBool("isAttacking", false);
        }
    }
}
