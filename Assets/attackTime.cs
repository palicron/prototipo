using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTime : MonoBehaviour {

    public float attackT;
    public float cont = 0;
    public bool inc=false;
    public ForceMode force;
	// Update is called once per frame
	void Update () {


      
        if (inc)
        {
            cont += 1 * Time.deltaTime;
            if(cont>=attackT)
            {
                GetComponent<SapphiArtChan_AnimManager>().Attack();
                
                cont = 0;
              
            }
        }
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inc = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inc = false;
            cont = 0;
        }
    }

}
