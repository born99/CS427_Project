using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
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
        



    }
    public void Takedamage(int dame)
    {
        health -= dame;
    }
    
   
}
