using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    private GameObject player;
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
        player = GameObject.Find("Player Ship");
        enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isActiveAndEnabled) {
            transform.position += transform.forward * Time.deltaTime * 500;
        }
    }

    void OnCollisionEnter(Collision col) {
        Debug.Log("Hit: " + col.gameObject.tag + " / " + col.gameObject.name);
        SendDamage(col.gameObject.tag);
        Destroy(gameObject);
    }

    void SendDamage(string tagObject) {
        if (enemy != null && tagObject == "Enemy") {
            EnemyAI scriptEnemy = enemy.GetComponent<EnemyAI>();
            scriptEnemy.DamageForEnemy();
        } else if (player != null && tagObject == "Player") {
            PlayerController scriptPlayer = player.GetComponent<PlayerController>();
            scriptPlayer.DamageForPlayer();
        }
    }

}
