using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    Animator anim;
    BoxCollider2D boxcoli2d;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        boxcoli2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <=0)
        {
            anim.SetBool("death",true);
            
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("death2"))
        {
            Destroy(gameObject);
        }

        RaycastHit2D raycasthit2D = Physics2D.BoxCast(boxcoli2d.bounds.center, boxcoli2d.bounds.size, 0f, Vector2.left, .1f, layer);

        if (raycasthit2D ==true)
        {
            if (raycasthit2D.collider.CompareTag("main"))
            {
                raycasthit2D.collider.GetComponent<NarutoMoveControl>().Death();
                
            }    
        }

    }
    public void Takedamage(int dame)
    {
        health -= dame;
    }
    
   
}
