using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damage;

    public float forceX;
    public float forceY;
    public float duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Stats"))
        {
            if (collision.GetComponent<PlayerStats>().health <= 0)
                return;
            collision.GetComponent<PlayerStats>().TakeDamage(damage);
            PlayerMoveControls playerMove = collision.GetComponentInParent<PlayerMoveControls>();
            StartCoroutine(playerMove.KnockBack(forceX, forceY, duration, transform));
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
