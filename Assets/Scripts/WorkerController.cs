using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Worker_States;

public class WorkerController : Worker
{
    Worker_StateBase w_state = null;
    NavMeshAgent agent;
    public Worker_Bag bag;
    public GameObject attachedObj;
    
    // Start is called before the first frame update
    void Start()
    {
        bag = this.GetComponent<Worker_Bag>();
        if(bag == null )
        {
            bag = this.AddComponent<Worker_Bag>();
        }
        agent = this.GetComponent<NavMeshAgent>();
        if( agent == null )
        {
            agent = this.AddComponent<NavMeshAgent>();
        }
        Change_State(new GoWork());
        
    }

    // Update is called once per frame
    void Update()
    {
        if(w_state != null)
        {
            w_state.Excute(this);
        }
    }

    public void Change_State(Worker_StateBase _state)
    {
        if (w_state != null)
        {
            w_state.Exit(this);
        }
        w_state = _state;
        w_state.Enter(this);
    }

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }

    public void MoveAgent(Vector3 _pos)
    {
        agent.destination = _pos;
    }
    private void OnTriggerEnter(Collider other)
    {
        attachedObj = other.gameObject;
    }
    
    private void OnTriggerExit(Collider other)
    {
        attachedObj = null;
    }
}
