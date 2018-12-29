using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //네비게이션에 필요

public class EnemyAct : MonoBehaviour
{

    
    public Transform playerPos;
    NavMeshAgent nv;
    Rigidbody rb;
    bool getHurt;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        nv = GetComponent<NavMeshAgent>();

        rb.isKinematic = true;
        getHurt = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (!getHurt)
        {
            nv.SetDestination(playerPos.position);
        }

    }


    //OnTriggerEnter 함수 시작(충돌체)
    private void OnTriggerEnter(Collider collision)
    {

        //조건문1 시작(충돌체의 태그 = "Weapon")
        if (collision.gameObject.tag == "Weapon")
        {

            //print("Ouch"); 아파

            getHurt = true; //피격 플래그 변수

            //네비메쉬 에이전트 비활성화
            nv.enabled = false;
            //Rigidbody.IsKinematic 비활성화
            rb.isKinematic = false;
            //위 방향으로(5f 만큼) 힘을 가한다 ForceMode는 가하는 힘의 종류.
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);

        }

        //조건문2 시작(충돌체의 태그 = "Ground")
        if (collision.gameObject.tag == "Ground")
        {

            //네브메쉬 에이전트 활성화
            nv.enabled = true;

            getHurt = false; //네브메쉬 에이전트를 활성화 한 후에 적용해야 오류가 발생하지 않는다.

            //Rigidbody.IsKinematic 활성화
            rb.isKinematic = true;


        }
    }
    //OnTriggerEnter 함수 종료
}
