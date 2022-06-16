using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Destructible
{
    public override void Hit()
    {
        anim.SetTrigger("Hit");
    }

    public override void Destroy()
    {
        anim.SetTrigger("Destroy");
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
