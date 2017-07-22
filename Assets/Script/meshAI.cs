using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class meshAI : MonoBehaviour {
    public GameObject[] waypoints;
    public int num = 0;
    public bool rand = false;
    GameObject currentTarget;
    NavMeshAgent agent;
    
    // Use this for initialization
    void Start () {

        agent = GetComponent<NavMeshAgent>();
        agent.destination = waypoints[num].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(transform.position, waypoints[num].transform.position);
         currentTarget = waypoints[num];
        if(dist<=agent.stoppingDistance)
        {
            if (!rand)
            {
                if (num + 1 == waypoints.Length)
                {
                    num = 0;
                }
                else
                {
                    num++;
                }
            }
            else
            {
                num = Random.Range(0, waypoints.Length);
            }

            agent.destination = waypoints[num].transform.position;
        }
        

        
	}
}
