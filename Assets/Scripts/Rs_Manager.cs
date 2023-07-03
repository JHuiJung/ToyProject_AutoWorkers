using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Rs_Manager : MonoBehaviour
{
    private static Rs_Manager _instance;

    public static Rs_Manager Inst
    {
        get
        {

            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(Rs_Manager)) as Rs_Manager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        getAllRs();
    }
    [SerializeField]
    GameObject[] Rs;
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        getAllRs();
        
    }

    void getAllRs()
    {
        Rs = GameObject.FindGameObjectsWithTag("Rs");
    }

    public GameObject GetNearObj(Vector3 unitPosition)
    {
        
        Vector3 minPosition = Vector3.zero;
        
        for (int i = 0; i < Rs.Length; i++)
        {
            Vector3 rst = Rs[i].GetComponent<Transform>().position;
            float min = (unitPosition - Rs[0].GetComponent<Transform>().position).magnitude;
            int minIndex = i;
            for(int j=i; j < Rs.Length; j++)
            { 
                if ((unitPosition - Rs[j].GetComponent<Transform>().position).magnitude <= min) 
                { 
                    minIndex = j;
                }
            }
            if(Rs[minIndex].GetComponent<Rs_Base>().isKey() && !Rs[minIndex].GetComponent<Rs_Base>().isEmpty)
            {
                return Rs[minIndex];
            }
        }
        return null;
    }



}
