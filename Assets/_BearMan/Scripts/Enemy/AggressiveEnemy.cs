using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveEnemy : MonoBehaviour
{
    public float seeDistance = 30.5f;
    public float attacDistance = 5.0f;
    private UnityEngine.AI.NavMeshAgent nav;
    public Transform target;
    public Animator anim;

    public Transform startPoisition;

    public float damage = 20; 

    private bool walk;
    private bool attack;
    bool stopGame = false;

    private void OnEnable()
    {
        ManagerGame.OnChangeStateGame += Restart;
    }

    private void OnDisable()
    {
        ManagerGame.OnChangeStateGame -= Restart;
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Restart(int eventGame)
    {
        if(eventGame == StateGame.RESTART_GAME) {
            transform.position = startPoisition.position;
        } else if(eventGame == StateGame.STOP_GAME) {
            IdleState();
            stopGame = true;
        }
        else if(eventGame == StateGame.START_GAME) {
            stopGame = false;
        }

    }

    void IdleState()
    {
        nav.enabled = false;
        anim.SetBool("death", false);
        anim.SetBool("attack", false);
        anim.SetBool("walk", false);
    }

    void Update()
    {
        if(target == null) {
            IdleState();
        }
        if (stopGame)
            return;
        if(Vector3.Distance(transform.position, target.transform.position) <= seeDistance ) {
            if(Vector3.Distance(transform.position, target.transform.position) > attacDistance) {
                anim.SetBool("death", false);
                anim.SetBool("attack", false);
                anim.SetBool("walk", true);
                walk = true;
                nav.enabled = true;
                nav.SetDestination(target.position);
            } else {
                PlayerCharacter player = target.GetComponent<PlayerCharacter>();
                if (player != null) {
                    nav.enabled = false;
                    
                    anim.SetBool("death", false);
                    anim.SetBool("walk", false);
                    anim.SetBool("attack", true);
                    player.Hurt(damage);
                    walk = false;
                    Vector3 lookAtPosition = target.position;
                    lookAtPosition.y = transform.position.y;
                    transform.LookAt(lookAtPosition);
                }
            }
        } else {
            anim.SetBool("death", false);
            anim.SetBool("walk", false);
            anim.SetBool("attack", false);
            walk = false;
            nav.enabled = false;
        }
    }
}
