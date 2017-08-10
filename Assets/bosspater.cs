using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class bosspater : MonoBehaviour {

    [SerializeField] private int atcconter = 0;
    [SerializeField] private bool attaccc;
    [SerializeField] private Collider[] col;
    [SerializeField] private Collider[] col1;
    [SerializeField] private bool charge;
    [SerializeField] private bool still;
    private Vector3 charPost;
    private float at;
    private bool dash = false;
    private int dashcont = 0;
    private GameObject player;
    private Transform trans;
    private Rigidbody rb;
    public float speed;
    public ForceMode force;
    public Animator aniamte;
    public GameObject check;
    public float back;
    public GameObject bakctarget;
    public LayerMask lay;


    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        trans = GetComponent<Transform>();
        attaccc = false;
        charge = false;
        charPost = Vector3.zero;
        still = false;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        col = Physics.OverlapSphere(trans.position, 10f, lay);
        col1 = Physics.OverlapSphere(trans.position, 1f, lay);
        if (col.Length != 0 && col1.Length == 0 && !charge && !still)
        {
            Vector3 look = new Vector3(player.transform.position.x, trans.position.y, player.transform.position.z);
            trans.LookAt(look);
            aniamte.SetBool("move", true);
           
        }
        else
        {
            aniamte.SetBool("move", false);
        }
        if(col1.Length!=0 && !attaccc && !dash)
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
            aniamte.SetBool("jump", true);
            Vector3 vec = bakctarget.GetComponent<Transform>().position;
            float speee = 23 * Time.deltaTime;
            trans.position = Vector3.MoveTowards(trans.position, vec, speee);
            dashcont++;
            if(dashcont==15)
            {
                dash = false;
                dashcont = 0;
                still = true;
               
                StartCoroutine(chargueIn());
            }
        }
        if (charge)
        {
            float speee = 15 * Time.deltaTime;
            trans.position = Vector3.MoveTowards(trans.position, charPost, speee);
            if(trans.position==charPost)
            {
                charge = false;
                rb.AddExplosionForce(10f, trans.position, 20,1, ForceMode.Impulse);
               
                charPost = Vector3.zero;
            }
        }
	}
     
    IEnumerator reest()
    {
        AnimatorStateInfo aninfo = aniamte.GetCurrentAnimatorStateInfo(0);
        AnimatorClipInfo[] myclip = aniamte.GetCurrentAnimatorClipInfo(0);
        at = myclip[0].clip.length * aninfo.normalizedTime + 0.4f;
        yield return new WaitForSeconds(0.4f);
        attaccc = false;
        if(atcconter>=2)
        {
            dash = true;
            atcconter = 0;
    
        }
        else
        {
            atcconter++;
        }
    }

    public IEnumerator chargueIn()                                          //metodo que guarda la poscion del jugador antes de uniciar el chargue y luego de T segundos inicia el chargue
    {
        if(charPost==Vector3.zero)
        {
            charPost = player.transform.position;
        }
        yield return new WaitForSecondsRealtime(1.5f);
        aniamte.SetBool("jump", false);
        charge = true;
        still = false;
    }
  
}
