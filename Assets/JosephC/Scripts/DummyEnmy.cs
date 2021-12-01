using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnmy : MonoBehaviour
{
    public int hp = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            int dam = collision.gameObject.transform.parent.gameObject.GetComponent<CharacterControll>().damage;
            hp -= dam;
            if (hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}

