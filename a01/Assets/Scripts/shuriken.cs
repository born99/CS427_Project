using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuriken : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float lifetime;
    public LayerMask whatisSolid;
    public float distance;
    public int damage;
    void Start()
    {
        Invoke("destroy", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, distance, whatisSolid);
        if (hitinfo.collider!=null)
        {
            if(hitinfo.collider.CompareTag("enemy"))
            {
                hitinfo.collider.GetComponent<Enemy>().Takedamage(damage);

            }
            destroy();
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void destroy()
    {
        Destroy(gameObject);
    }
}
