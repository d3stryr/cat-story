using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public int lvlToLoad;
    public Sprite unlockedSprite;

    private BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        GameManager.RegisterDoor(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            boxCollider2D.enabled = false;
            collision.GetComponent<GatherInput>().DisableControls();
            PlayerStats playerStats = collision.GetComponentInChildren<PlayerStats>();
            PlayerCollectibles playerCollectibles = collision.GetComponent<PlayerCollectibles>();
            PlayerPrefs.SetInt("GemsKey", playerCollectibles.gemNumber);
            PlayerPrefs.SetFloat("HealthKey", playerStats.health);
            GameManager.ManagerLoadLevel(lvlToLoad);
        }
    }

    public void UnlockDoor()
    {
        GetComponent<SpriteRenderer>().sprite = unlockedSprite;
        boxCollider2D.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
