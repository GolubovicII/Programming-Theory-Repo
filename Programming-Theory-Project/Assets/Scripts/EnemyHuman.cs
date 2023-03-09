using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class EnemyHuman : Enemy
{
    [SerializeReference]
    AudioClip angryHumanSound;

    // POLYMORPHISM
    public override void Aggro()
    {
        base.Aggro();

        Yell(angryHumanSound);
    }
}
