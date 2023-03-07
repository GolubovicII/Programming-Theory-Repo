using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoblin : Enemy
{
    public AudioClip angryGoblinSound;

    public override void Aggro()
    {
        base.Aggro();

        if (!enemyAudio.isPlaying)
            enemyAudio.PlayOneShot(angryGoblinSound, 0.3f);
    }
}
