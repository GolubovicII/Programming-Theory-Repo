using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHuman : Enemy
{
    [SerializeReference]
    AudioClip angryHumanSound;

    public override void Aggro()
    {
        base.Aggro();

        Yell(angryHumanSound);
    }
}
