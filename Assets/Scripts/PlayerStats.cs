using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public bool canTakeDamage = true;

    private Image healthUI;
    private Animator anim;
    private PlayerMoveControls playerMove;
    private PlayerAttackControls pAC;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponentInParent<PlayerMoveControls>();
        pAC = GetComponentInParent<PlayerAttackControls>();
        anim = GetComponentInParent<Animator>();
        healthUI = GameObject.FindGameObjectWithTag("HealthUI").GetComponent<Image>();
        health = PlayerPrefs.GetFloat("HealthKey",maxHealth);
        UpdateHealthUI();
    }

    public void TakeDamage(float damage)
    {
        if(canTakeDamage)
        {
            health -= damage;
            anim.SetBool("Damage", true);
            playerMove.hasControl = false;
            UpdateHealthUI();
            pAC.ResetAttack();
            if (health<=0)
            {
                //anim.SetBool("Death", true);
                GetComponent<PolygonCollider2D>().enabled = false;
                GetComponentInParent<GatherInput>().DisableControls();
                PlayerPrefs.SetFloat("HealthKey", maxHealth);
                GameManager.ManagerRestartLevel();
            }
            StartCoroutine(DamagePrevention());
        }
    }
    public void AddHealth(float healthval)
    {
        health += healthval;
        if (health > maxHealth)
            health = maxHealth;
        UpdateHealthUI();
    }
    IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);
        if(health>0)
        {
            canTakeDamage = true;
            playerMove.hasControl = true;
            anim.SetBool("Damage", false);
        }
        else
        {
            anim.SetBool("Death", true);
        }
    }

    public void UpdateHealthUI()
    {
        healthUI.fillAmount = health /(float) maxHealth;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("HealthKey");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
