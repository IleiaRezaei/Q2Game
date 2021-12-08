using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;

    public int health = 100;
    public int maxhealth = 100;

    private CharacterControll bool_script;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        bool_script = player.GetComponent<CharacterControll>();
    }

    // Update is called once per frame
    void Update()
    {
        bool_script.attacking = bool_script.attacking;

        Debug.Log(bool_script.attacking);

        if (health <= 0)
        {
            Destroy(this);
        }
    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
        if (collision.gameObject.tag == "Player")
=======
        if (collision.gameObject.tag == "PlayerAttack")
>>>>>>> 9fdfa67342b8392b21dc42b3db90bd89d8c7e291
        {
            if (bool_script.attacking = true)
            {
                health -= 10;
                rb.velocity = Direction * -50F;
            }

        }       
    }
}
