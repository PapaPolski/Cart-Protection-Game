using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gremlin : EnemyParentScript
{
    TreasureChest tC;
    bool hadFirstTarget;

    // Start is called before the first frame update
    public override void Start()
    {
        hadFirstTarget = false;
        base.Start();
        tC = GameObject.Find("TreasureChest").GetComponent<TreasureChest>();
        GetClosestTreasure(tC.currentTreasuresInScene);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if(target == null && hadFirstTarget)
        {
            if(tC.currentTreasuresInScene.Count > 0)
            {
                GetClosestTreasure(tC.currentTreasuresInScene);
            }
        }
    }

    GameObject GetClosestTreasure(List<GameObject> treasures)
    {
        target = null;
        float closestDistanceSqe = Mathf.Infinity;
        Vector3 curPos = this.transform.position;
        for (int i = 0; i < treasures.Count; i++)
        {
            Vector3 directionToTarget = treasures[i].transform.position - curPos;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqe && !target.GetComponent<Treasure>().isBeingTargeted)
            {
                closestDistanceSqe = dSqrToTarget;
                target = treasures[i].gameObject;
            }
        }
        hadFirstTarget = true;
        target.GetComponent<Treasure>().isBeingTargeted = true;
        return target;
    }

    public override void OnDestroy()
    {
        target.GetComponent<Treasure>().isBeingTargeted = false;
        base.OnDestroy();
        player.ChangeScore(pointValue, "Crab Killed");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == target)
        {
            collision.transform.SetParent(this.gameObject.transform);
        }
    }
}
