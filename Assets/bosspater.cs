using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class bosspater : MonoBehaviour {

    public ForceMode force;
    private GameObject player;
    private Transform trans;
    public Animator aniamte;
    private NavMeshAgent nav;
    private Rigidbody rb;
    private CharacterController controles;
    public GameObject check;
   
    public float back;
    [SerializeField] private Collider[] col;
    [SerializeField] private Collider[] col1;
    public LayerMask lay;
    public float speed ;
    private float at;
    [SerializeField] private int atcconter = 0;
    [SerializeField] private bool attaccc = false;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        trans = GetComponent<Transform>();
        nav = GetComponent<NavMeshAgent>();
        controles = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (rb.velocity.y == 0)
        {
            nav.enabled = true;
        }
        col = Physics.OverlapSphere(trans.position, 10f, lay);
        col1 = Physics.OverlapSphere(trans.position, 3f, lay);
        if (col.Length != 0 && col1.Length == 0)
        {
            nav.SetDestination(player.transform.position);
            aniamte.SetBool("move", true);
           
        }
        else
        {
            aniamte.SetBool("move", false);
        }
        if(col1.Length!=0 && !attaccc)
        {
         
            
            
              
            
            aniamte.SetBool("attack", true);
            attaccc = true;
            StartCoroutine(reest());
        }
        else
        {
            aniamte.SetBool("attack", false);
        }

	}
     
    IEnumerator reest()
    {
        AnimatorStateInfo aninfo = aniamte.GetCurrentAnimatorStateInfo(0);
        AnimatorClipInfo[] myclip = aniamte.GetCurrentAnimatorClipInfo(0);
        at = myclip[0].clip.length * aninfo.normalizedTime + 0.4f;
        yield return new WaitForSeconds(at);
        attaccc = false;
        if(atcconter>=1)
        {
            
            jumpbak();
            atcconter = 0;
            
   
        }
        else
        {
            atcconter++;
        }
    }

    private void jumpbak()
    {


        nav.velocity = Vector3.back * -back;
        //    GetComponent<Rigidbody>().AddForce(Vector3.back * (-back), force);
            
        
      
    }
}
