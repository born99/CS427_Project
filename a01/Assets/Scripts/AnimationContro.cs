using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationContro : MonoBehaviour
{
    Animator anim;
    Vector2 curentmove;
    Rigidbody2D rigid;
    BoxCollider2D coli;
    BoxCollider2D colirun;
    public GameObject colliderRun;
    public float movespeed=10f;
    public float jumpSpeed = 100f;
    float curentmovespeed;
    float curentjumpspeed;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coli = GetComponent<BoxCollider2D>();
        colirun = colliderRun.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            curentjumpspeed = rigid.velocity.y + jumpSpeed;
        }
        else curentjumpspeed = rigid.velocity.y;
        if(Input.GetKey(KeyCode.D))
        {
            //rigid.AddForce(new Vector2(speed, 0));
            curentmovespeed = movespeed;
            anim.Play("run");
            GetComponent<SpriteRenderer>().flipX = false;
            colirun.enabled = true;
            coli.enabled = false;


        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                //rigid.AddForce(new Vector2(-movespeed, 0));
                //rigid.velocity = new Vector2(-movespeed, 0);
                curentmovespeed =- movespeed;
                GetComponent<SpriteRenderer>().flipX = true;
                anim.Play("run");
                colirun.enabled = true;
                coli.enabled = false;
            }
            else
            {
                coli.enabled = true;
                colirun.enabled = false;
                curentmovespeed = 0;
            }
        

        }

        rigid.velocity = new Vector2(curentmovespeed, curentjumpspeed);
    }
    private void FixedUpdate()
    {
        
        
    }
}
