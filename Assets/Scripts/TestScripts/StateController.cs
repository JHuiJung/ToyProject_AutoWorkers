using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    [SerializeField]
    StateBase currentState = null;
    public Transform[] transforms;
    [SerializeField]
    private int HungryPoint;
    [SerializeField]
    private int IntPoint;
    [SerializeField]
    private int StressPoint;
    [SerializeField]
    private int MusclePoint;
    [SerializeField]
    private int MoneyPoint;
    [SerializeField]
    public NavMeshAgent agent;

    public int _hungryPoint
    {
        get { return HungryPoint; }
        set { HungryPoint = Mathf.Clamp(value, 0, 100); }
    }

    public int _intPoint
    {
        get { return IntPoint; }
        set { IntPoint = Mathf.Clamp(value, 0, 100); }
    }

    public int _stressPoint
    {
        get { return StressPoint; }
        set { StressPoint = Mathf.Clamp(value, 0, 100); }
    }

    public int _musclePoint
    {
        get { return MusclePoint; }
        set { MusclePoint = Mathf.Clamp(value, 0, 100); }
    }

    public int _moneyPoint
    {
        get { return MoneyPoint; }
        set { MoneyPoint = Mathf.Clamp(value, 0, 100); }
    }

    // Start is called before the first frame update
    void Start()
    {
        HungryPoint = 50;
        IntPoint = 0;
        MoneyPoint = 0;
        MusclePoint = 0;
        StressPoint = 0;
        agent = GetComponent<NavMeshAgent>();
        currentState = new State_Idle();
        Change_State(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.Excute(this);
        }
    }

    public void Change_State(StateBase _state)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = _state;
        currentState.Enter(this);
    }
}
