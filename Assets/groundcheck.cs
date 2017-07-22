using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour {

    public LayerMask ground;
    [SerializeField] private bool grounded;
    private Collider[] col;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        col =   Physics.OverlapSphere(GetComponent<Transform>().position, 1, ground);
        if(col.Length!=0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
	}

    public bool getGround()
    {
        return grounded;
    }
}
