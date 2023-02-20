using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    GameObject target, treasureTarget;
    public GameObject grave;
    Player player;
    Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Cart");
        player = GameObject.Find("Player").GetComponent<Player>();
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.currentHealth > 0)
        {
            if (target != null)
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, spawner.ghostSpeed * Time.deltaTime);
            else
                target = null;
        }
    }

    private void OnDestroy()
    {

        player.totalGhostsKilled++;
        spawner.currentGhostsAlive--;
        spawner.remainingGhosts--;
        spawner.UpdateUI();
        float randomChance = Random.Range(0f, 10f);

        if (randomChance > 5)
        {
            if(this.gameObject.scene.isLoaded)
                Instantiate(grave, this.transform.position, Quaternion.identity);
        }
        player.ChangeScore(10, "Ghost Killed");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Spear")
        {
            player.GetComponent<AudioSource>().PlayOneShot(player.ghostKilledAudio);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
