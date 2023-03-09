using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoblin : Enemy
{
    [SerializeReference]
    AudioClip angryGoblinSound;

    public override void Aggro()
    {
        base.Aggro();

        Yell(angryGoblinSound);
    }
}
