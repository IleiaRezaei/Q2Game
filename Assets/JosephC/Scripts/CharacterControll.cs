using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    private float MoveSpeed = 5000;
    private float MaxSpeed = 5000;
    private Rigidbody2D RigidBoy;
    private CircleCollider2D Coli;
    private bool Friction = false;
    private Vector2 Direction = new Vector2(1, 0);
    private CapsuleCollider2D hitbox;
    private Animator anim_player;
    public bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        RigidBoy = GetComponent<Rigidbody2D>();
        Coli = GetComponent<CircleCollider2D>();
        hitbox = transform.GetChild(0).GetComponent<CapsuleCollider2D>();
        anim_player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movex = (Input.GetAxis("Horizontal"));
        float movey = (Input.GetAxis("Vertical"));
        if(new Vector2(movex,movey) != new Vector2(0, 0))
        {
            Direction = new Vector2(movex, movey);
        }
        else
        {
            if (attacking == false)
            {
                anim_player.Play("Idle");
            }
            
        }

        RigidBoy.AddForce(new Vector2(movex, movey) * MoveSpeed * Time.deltaTime) ;
        RigidBoy.velocity = new Vector2(Mathf.Clamp(RigidBoy.velocity.x, -MaxSpeed, MaxSpeed), Mathf.Clamp(RigidBoy.velocity.y, -MaxSpeed, MaxSpeed));
        if (Input.GetButtonDown("Jump"))
        {
            Coli.enabled = false;
            RigidBoy.velocity = Direction * 50F;
        }
        if (Input.GetButton("Light"))
        {
            attack(false);
            anim_player.Play("LightAtk");
        }
        if (Input.GetButton("Heavy"))
        {
            attack(true);
            anim_player.Play("HeavyAtk");
        }
    }
    void attack(bool heavy)
    {
        if (attacking == false)
        {
            if (heavy)
            {
                print("heavy");
                attacking = true;
            }
            else
            {
                print("light");
                hitbox.enabled = true;
                attacking = true;

            }
        }
    }
}
