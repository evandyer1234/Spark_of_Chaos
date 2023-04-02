using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gen : hitable
{
    public GameData gd;
    public float boost;
    bool isdead = false;
    
    public override void Die()
    {
        if (!isdead)
        {
            isdead = true;
            gd.acceleratetime(boost);
            gd.textrandomize();
            gd.SpawnGen();
            base.Die();
        }
    }
}
