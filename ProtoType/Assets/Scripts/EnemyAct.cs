using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //네비게이션에 필요

public class EnemyAct : MonoBehaviour
{

    
    public Transform playerPos;
    NavMeshAgent nv;



    // Start is called before the first frame update
    void Start()
    {

        nv = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        nv.SetDestination(playerPos.position);

    }
}
