using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class bosspater : MonoBehaviour {

    public ForceMode force;
    private GameObject player;
    private Transform trans;
    public Animator aniamte;
    private Rigidbody rb;
    private CharacterController controles;
    public GameObject check;
    [SerializeField] private bool lookat;
    public float back;
    public GameObject bakctarget;
    [SerializeField] private Collider[] col;
    [SerializeField] private Collider[] col1;
    public LayerMask lay;
    public float speed ;
    private float at;
    private bool dash=false;
    private int dashcont = 0;
    [SerializeField] private int atcconter = 0;
    [SerializeField] private bool attaccc = false;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        trans = GetComponent<Transform>();
 
        controles = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        col = Physics.OverlapSphere(trans.position, 10f, lay);
        col1 = Physics.OverlapSphere(trans.position, 1f, lay);
        if (col.Length != 0 && col1.Length == 0)
        {
            Vector3 look = new Vector3(player.transform.position.x, trans.position.y, player.transform.position.z);
            trans.LookAt(look);
            trans.position += trans.forward * Time.deltaTime * speed;
            // nav.SetDestination(player.transform.position);
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

        if(dash)
        {
            Vector3 vec = bakctarget.GetComponent<Transform>().position;
            float speee = 23 * Time.deltaTime;
            trans.position = Vector3.MoveTowards(trans.position, vec, speee);
            dashcont++;
            if(dashcont==15)
            {
                dash = false;
            }
        }
	}
     
    IEnumerator reest()
    {
        AnimatorStateInfo aninfo = aniamte.GetCurrentAnimatorStateInfo(0);
        AnimatorClipInfo[] myclip = aniamte.GetCurrentAnimatorClipInfo(0);
        at = myclip[0].clip.length * aninfo.normalizedTime + 0.4f;
        yield return new WaitForSeconds(0.5f);
        attaccc = false;
        if(atcconter>=1)
        {
            dash = true;
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
      //  Vector3 vec = bakctarget.GetComponent<Transform>().position;
        //rb.AddForce(Vector3.up * 5, force);
        // rb.AddForce(vec*-6, force);
       // float speee = 23 * Time.deltaTime;
        //trans.position = Vector3.MoveTowards(trans.position, vec, speee);
        //    GetComponent<Rigidbody>().AddForce(Vector3.back * (-back), force);



    }
}
