using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class EnemyGoblin : Enemy
{
    [SerializeReference]
    AudioClip angryGoblinSound;

    // POLYMORPHISM
    public override void Aggro()
    {
        base.Aggro();

        Yell(angryGoblinSound);
    }
}
