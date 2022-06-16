using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public float heal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponentInChildren<PlayerStats>().health == collision.gameObject.GetComponentInChildren<PlayerStats>().maxHealth)
                return;
            collision.gameObject.GetComponentInChildren<PlayerStats>().AddHealth(heal);
            Destroy(gameObject);
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
