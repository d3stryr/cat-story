using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingAttack : EnemyAttack
{
    private PlayerMoveControls playerMove;
    public float ForceX;
    public float ForceY;
    public float duration;



    public override void SpecialAttack()
    {
        base.SpecialAttack();
        playerMove = playerStats.GetComponentInParent<PlayerMoveControls>();
        StartCoroutine(playerMove.KnockBack(ForceX, ForceY, duration, transform.parent));
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
