using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent navmeshagent;

    void Update()
    {
        navmeshagent.destination = player.position;
    }
}
