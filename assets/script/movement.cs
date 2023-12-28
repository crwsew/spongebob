using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private CharacterController control;
    public float speed=20;
    public Vector3 groundcheckpos;
    public float groundcheckedradus;
    public float jumpp=5;
    public LayerMask grlayer;
    private bool isgrounded=false;
    public float gravity=-19.81f;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        control=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics.CheckSphere(transform.position+groundcheckpos,groundcheckedradus,grlayer);
        if(isgrounded && velocity.y<0f)
        {
            velocity.y=-2f;
        }
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y=Mathf.Sqrt(jumpp* -2f *gravity);
        }
        float x= Input.GetAxis("Horizontal");
        float z=Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward *z;
        velocity.y += gravity*Time.deltaTime;
        control.Move(move*speed*Time.deltaTime);
        control.Move(velocity*Time.deltaTime);

    }
    private void ongreeze(){
        Gizmos.color=Color.white;
        Gizmos.DrawWireSphere(transform.position+groundcheckpos,groundcheckedradus);

    }
}
