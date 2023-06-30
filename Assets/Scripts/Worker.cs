using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public enum Worker_State
{
    idle = 0,
    work = 1,
    rest = 2,
    hungry = 3,
}
public class Worker : MonoBehaviour
{
    // Start is called before the first frame update
    public int stress
    {
        get { return _stress; }
        set
        { 
            _stress = Mathf.Clamp(value, 0, 100);
        }
    }
    public int hungry
    {
        get { return _hungry; }
        set
        {
            _hungry = Mathf.Clamp(value, 0, 100);
        }
    }
    public Worker_State state
    {
        get { return _State; }
        set
        {
            switch (value)
            {
                case Worker_State.idle:
                    _State = Worker_State.idle;
                    break; 
                case Worker_State.work:
                    _State = Worker_State.work;
                    break; 
                case Worker_State.rest:
                    _State = Worker_State.rest;
                    break;
                case Worker_State.hungry:
                    _State = Worker_State.hungry;
                    break;
            }
        }
    }
    protected Worker_State _State = Worker_State.idle;
    protected int _stress = 0;
    protected int _hungry = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
