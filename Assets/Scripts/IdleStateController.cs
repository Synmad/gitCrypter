using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class IdleStateController : StateMachineBehaviour
{
    float stateTimer;
    float chaseRange = 20;

    Transform player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateTimer = 0;

        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //float distance = Vector3.Distance(player.position, animator.transform.position);
        //if (distance < chaseRange)
            //animator.SetBool("isChasing", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateTimer += Time.deltaTime;
        if (stateTimer > 5)
            animator.SetBool("isPatrolling", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
