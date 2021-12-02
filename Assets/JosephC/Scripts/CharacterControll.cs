﻿using System.Collections;
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

    public int maxHP = 100;
    public int currentHP = 100;

    public object[,] text; 

    public int damage = 0;
    public int knockback = 0;

    public GameObject texbox;
    private RaycastHit2D intercast;

    public LayerMask lm;
    // Start is called before the first frame update
    void Start()
    {
        text = new object[,] { {"testtext","neutral",false}, { "testtext", "neutral", true } };
        RigidBoy = GetComponent<Rigidbody2D>();
        Coli = GetComponent<CircleCollider2D>();
        hitbox = transform.GetChild(0).GetComponent<CapsuleCollider2D>();
        anim_player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentHP == 0)
        {
            Destroy(this);
        }

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        float movex = (Input.GetAxis("Horizontal"));
        float movey = (Input.GetAxis("Vertical"));
        if(new Vector2(movex,movey) != new Vector2(0, 0))
        {
            intercast = Physics2D.Raycast(transform.position, new Vector2(movex, movey), Mathf.Infinity, lm);
            if (attacking == false)
            {
                Direction = new Vector2(movex, movey);
                anim_player.Play("Idle");
            }
        }
        else
        {
            if (attacking == false)
            {
                anim_player.Play("Idle");
            }
            
        }
        if (attacking == false)
        {
            knockback = 0;
            damage = 0;
            RigidBoy.AddForce(new Vector2(movex, movey) * MoveSpeed * Time.deltaTime);
            RigidBoy.velocity = new Vector2(Mathf.Clamp(RigidBoy.velocity.x, -MaxSpeed, MaxSpeed), Mathf.Clamp(RigidBoy.velocity.y, -MaxSpeed, MaxSpeed));
        }
        else
        {
            RigidBoy.velocity = new Vector2(0, 0);
        }
        if (Direction.x > 0)
        {
            hitbox.offset = new Vector2(0.8322865F, hitbox.offset.y);
        }
        if (Direction.x < 0)
        {
            hitbox.offset = new Vector2(-0.8322865F, hitbox.offset.y);
        }
        if (Input.GetButtonDown("Jump"))
        {
            Coli.enabled = false;
            RigidBoy.velocity = Direction * 50F;
        }
        if (Input.GetButtonDown("Light"))
        {
            damage = attack(false);
            anim_player.Play("LightAtk");
        }
        if (Input.GetButtonDown("Heavy"))
        {
            damage = attack(true);
            anim_player.Play("HeavyAtk");
        }
        if (intercast.collider != null && intercast.collider.tag != "Player")
        {
            if (intercast.collider)
            {
                if (Input.GetButtonDown("interact"))
                {
                    NPC npcscripy = intercast.collider.GetComponent<NPC>();
                    textbox texscrp = texbox.GetComponent<textbox>();
                    texscrp.DoText(npcscripy.InterAct());
                }
            }
        }
    }
    int attack(bool heavy)
    {
        if (attacking == false)
        {
            if (heavy)
            {
                print("heavy");
                attacking = true;
                return 69;
                knockback = 15;
            }
            else
            {
                print("light");
                hitbox.enabled = true;
                attacking = true;
                return 40;
                knockback = 10;
            }
        }
        return damage;

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "regularBean")
        {
            currentHP += 20;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "EnemyHitbox")
        {

        }
    }
}
