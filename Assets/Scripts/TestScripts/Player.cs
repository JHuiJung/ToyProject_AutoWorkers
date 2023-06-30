using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//���(agent=enemy)���� �������� �˷��༭ �������� �̵��ϰ� �Ѵ�.
public class Player : MonoBehaviour
{
    //������
    public Transform target;
    //���
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //����� �������༭
        agent = GetComponent<NavMeshAgent>();
        //�����ɶ� ������(Player)�� �O�´�.
        agent.destination = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

}