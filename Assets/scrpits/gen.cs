using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gen : hitable
{
    public GameData gd;
    public float boost;
    
    public override void Die()
    {

        gd.acceleratetime(boost);
        gd.textrandomize();
        gd.SpawnGen();
        base.Die();
    }
}
