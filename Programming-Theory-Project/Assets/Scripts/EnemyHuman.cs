using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHuman : Enemy
{
    public AudioClip angryHumanSound;

    public override void Aggro()
    {
        base.Aggro();

        if (!enemyAudio.isPlaying)
            enemyAudio.PlayOneShot(angryHumanSound, 0.3f);
    }
}
