using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private enum State {
        Stop,
        ChasePlayer,
        AttackPlayer
    }

    [SerializeField]
    private State state;

    private GameObject player;

    [SerializeField]
    private GameObject leftLaser;

    [SerializeField]
    private GameObject rightLaser;

    [SerializeField]
    private GameObject leftLaserPosition;

    [SerializeField]
    private GameObject rightLaserPosition;

    private bool allowAttack;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Stop;
        player = GameObject.Find("Player Ship");
        allowAttack = true;
    }

    void Update() {
        /*HandleStateMachine();
        ActionsStateMachine();*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleStateMachine();
        ActionsStateMachine();
    }

    void ChasePlayer() {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        
        if (distanceToPlayer > 150.0f) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 50f * Time.deltaTime);
        }

        transform.LookAt(player.transform.position);
    }

    void AttackPlayer() {
        if (allowAttack) {
            GameObject newLeftLaser = Instantiate(leftLaser, leftLaserPosition.transform.position, leftLaserPosition.transform.rotation);
            GameObject newRightLaser = Instantiate(rightLaser, rightLaserPosition.transform.position, rightLaserPosition.transform.rotation);
            newLeftLaser.SetActive(true);
            newRightLaser.SetActive(true);
            allowAttack = false;
            StartCoroutine(WaitSeconds(5));
        }
    }

    void HandleStateMachine() {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distanceToPlayer > 150.0f) {
            state = State.ChasePlayer;
        } else if (distanceToPlayer < 300.0f) {
            state = State.AttackPlayer;
        } else if (distanceToPlayer > 300.0f) {
            state = State.Stop;
        }
    }

    void ActionsStateMachine() {
        switch(state) {
            default:
            case State.Stop:
                break;
            case State.ChasePlayer:
                ChasePlayer();
                break;
            case State.AttackPlayer:
                AttackPlayer();
                break;
        }
    }

    IEnumerator WaitSeconds(int seconds) {
        yield return new WaitForSeconds(2);
        allowAttack = true;
    }
}
