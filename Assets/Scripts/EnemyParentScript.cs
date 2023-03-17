using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParentScript : MonoBehaviour
{
    public float moveSpeed;
    public int pointValue;
    protected GameObject target;
    protected Player player;
    protected Spawner spawner;
    public GameObject grave;

    public virtual void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
    }
    public virtual void Update()
    {
        if (player.currentHealth > 0)
        {
            if (target != null)
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, spawner.ghostSpeed * Time.deltaTime);
            else
                target = null;
        }
    }

    public void PickTarget()
    {

    }

    public virtual void OnDestroy()
    {
        float randomChance = Random.Range(0f, 10f);

        if (randomChance > 5)
        {
            if (this.gameObject.scene.isLoaded)
                Instantiate(grave, this.transform.position, Quaternion.identity);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spear")
        {
            player.GetComponent<AudioSource>().PlayOneShot(player.ghostKilledAudio);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
