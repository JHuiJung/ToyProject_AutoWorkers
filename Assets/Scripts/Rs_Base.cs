using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rs_Base : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int keys = 5;

    
    [SerializeField]
    int _resource_Cnt = 100;
    [SerializeField]
    bool _isEmpty = false;
    public int resource_Cnt
    {
        get { return _resource_Cnt; }
        set 
        {
            if (value < 0)
            {
                _resource_Cnt = 0;
                _isEmpty = true;
            }
            else
            {
                _resource_Cnt = value;
                _isEmpty = false;
            }
            
        }
    }
    public bool isEmpty { get { return _isEmpty; } }
    void Start()
    {
        
    }

    // Update is called once per frame


    public bool isKey()
    {
        return keys != 0;
        
    }

    public void getKey()
    {
        if (isKey())
        {
            keys -= 1;
        }
    }

    public void return_Key()
    {
        keys += 1;
        keys %= 6;
    }
    
}
