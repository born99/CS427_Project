using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarutoMoveControl : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid;
    public float jumpspeed;
    public float movespeed;
    public LayerMask layer;
    BoxCollider2D boxcoli2d;
    Animator anim;
    void Start()
    {
        rigid = transform.GetComponent<Rigidbody2D>();
        boxcoli2d = transform.GetComponent<BoxCollider2D>();
        anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Isground() && Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = Vector2.up * jumpspeed;
        }
         HandleMovement();
        if(Isground())
        {
            if(rigid.velocity.x!=0)
            {
                anim.Play("run");
            }
           
        }
        else
        {
            anim.Play("jump");
        }
    }
    bool Isground()
    {
        RaycastHit2D raycasthit2D = Physics2D.BoxCast(boxcoli2d.bounds.center, boxcoli2d.bounds.size, 0f, Vector2.down, .1f, layer);
        Debug.Log(raycasthit2D.collider);
        return raycasthit2D.collider != null;
    }
    void HandleMovement()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rigid.velocity = new Vector2(-movespeed, rigid.velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            if(Input.GetKey(KeyCode.D))
            {
                rigid.velocity = new Vector2(+movespeed, rigid.velocity.y);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                rigid.velocity = new Vector2(0, rigid.velocity.y);

            }
        }
    }

}
