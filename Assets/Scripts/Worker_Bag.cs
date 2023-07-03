using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker_Bag : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int _rsAmount = 0;
    [SerializeField]
    int MaxAmount = 5;
    bool _isEmpty = true;
    bool _isFull = false;
    public bool IsEmpty { get { return _isEmpty; } }
    public bool IsFull { get { return _isFull; } }
    public int RsAmount
    {
        get { return _rsAmount; }
        set
        {
            if(value == MaxAmount)
            {
                _isFull = true;
                _rsAmount = value;
            }
            else if(value <= 0)
            {
                _isEmpty = true;
                _rsAmount = value;
            }
            else
            {
                _isFull = false;
                _isEmpty = false;
                _rsAmount = value;
            }
        }
    }
    


    public void AddRs(int value)
    {
        if (!_isFull)
        {
            RsAmount += 1;
        }
    }

    public int DropRs(int value)
    {
        if (!_isEmpty)
        {
            RsAmount -= value;
            return value;
        }
        else
        {
            return 0;
        }
    }
}
