using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovment : MonoBehaviour
{
    [SerializeField]
    Transform targetObj;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        targetObj = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = targetObj.position;
    }
}
