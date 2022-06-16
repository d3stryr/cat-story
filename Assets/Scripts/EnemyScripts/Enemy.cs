using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;

    protected Rigidbody2D rb;
    protected Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage(float Damage)
    {
        DamageSequence();
        health -= Damage;
        if (health <= 0)
        {
            DeathSequence();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void DamageSequence()
    {

    }

    public virtual void DeathSequence()
    {

    }
}
