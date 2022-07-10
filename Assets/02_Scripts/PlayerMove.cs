using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rigid = null;
    float speed = 5f;
    SpriteRenderer spR;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spR = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 pos = new Vector2(h, v);
        rigid.velocity = pos.normalized * speed;

        Vector3 dir = new Vector3(h, v, 0);
        transform.position += dir * speed * Time.deltaTime;

        if (Input.GetButton("Horizontal"))
        {
            spR.flipX = Input.GetAxisRaw("Horizontal") == +1;
        }

        if (h < 0 || v < 0)
        {
            anim.SetBool("run", true);
        }
        else if (h > 0 || v > 0)
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }
    }
}
