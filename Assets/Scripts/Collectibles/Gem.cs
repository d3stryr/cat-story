using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject gemParticle;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.RegisterGems(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerCollectibles>().GemCollected();
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            Instantiate(gemParticle, transform.position, transform.rotation);
            GameManager.RemoveGemFromList(this);
            //Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
