using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolStateController : StateMachineBehaviour
{
    float stateTimer;
    List<Transform> waypoints = new List<Transform>();
    NavMeshAgent navmeshagent;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navmeshagent = animator.GetComponent<NavMeshAgent>();
        stateTimer = 0;
        GameObject gameobject = GameObject.FindGameObjectWithTag("Waypoints");
        foreach (Transform transform in gameobject.transform)
            waypoints.Add(transform);

        navmeshagent.SetDestination(waypoints[Random.Range(0, waypoints.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (navmeshagent.remainingDistance <= navmeshagent.stoppingDistance)
            navmeshagent.SetDestination(waypoints[Random.Range(0, waypoints.Count)].position);
        stateTimer += Time.deltaTime;
        if (stateTimer > 10)
            animator.SetBool("isPatrolling", false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navmeshagent.SetDestination(navmeshagent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
