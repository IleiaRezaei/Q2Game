using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;

    public int health = 100;
    public int maxhealth = 100;

    private Rigidbody2D rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {


    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            int dam = collision.gameObject.transform.parent.gameObject.GetComponent<CharacterControll>().damage;
            Vector2 knock = collision.gameObject.transform.parent.gameObject.GetComponent<CharacterControll>().knockback;
            health -= dam;
            rb.AddForce(knock);
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }       
    }
}
