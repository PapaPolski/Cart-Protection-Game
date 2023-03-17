using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : EnemyParentScript
{

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        target = GameObject.Find("Cart");
    }

    public override void OnDestroy()
    {
        player.totalGhostsKilled++;
        spawner.currentGhostsAlive--;
        spawner.remainingGhosts--;
        spawner.UpdateUI();
        base.OnDestroy();
        player.ChangeScore(10, "Ghost Killed");
    }
}
