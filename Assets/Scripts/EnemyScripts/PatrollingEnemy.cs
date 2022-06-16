using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : Enemy
{
    public float speed;
    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask layerToCheck;
    public float radius;

    private int direction = -1;
    private bool detectGround;
    private bool detectWall;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Flip();
        rb.velocity = new Vector2(direction*speed, rb.velocity.y);
    }
    private void Flip()
    {
        detectGround = Physics2D.OverlapCircle(groundCheck.position, radius,layerToCheck);
        detectWall = Physics2D.OverlapCircle(wallCheck.position, radius,layerToCheck);

        if(!detectGround||detectWall)
        {
            direction *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y,transform.localScale.z);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);
        Gizmos.DrawWireSphere(wallCheck.position, radius);
    }

    public override void DamageSequence()
    {
        anim.SetTrigger("Damage");
    }

    public override void DeathSequence()
    {
        anim.SetTrigger("Death");
        speed = 0;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponentInChildren<PolygonCollider2D>().enabled = false;
        rb.gravityScale = 0;
    }
}
