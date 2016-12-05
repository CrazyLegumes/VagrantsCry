using UnityEngine;
using System.Collections;




public class Controls : MonoBehaviour
{

    private CharacterController body;
    private bool canmove;
    private Vector3 inp = Vector3.zero;
    private const float gravity = 30f;


    [SerializeField]
    private float movespeed;

    [SerializeField]
    private float jumpheight;

    // Use this for initialization
    void Start()
    {
        canmove = true;
        body = GetComponent<CharacterController>();

    }




    // Update is called once per frame
    void Update()
    {
        Movement();



    }


    private void Movement()
    {
        if (canmove)
        {
            
            inp.x = Inputs.HorizontalAxis();
            inp.z = Inputs.VerticalAxis();
            inp.x *= movespeed;
            inp.z *= movespeed;

            if (body.isGrounded)
            {
                inp.x = Inputs.HorizontalAxis();
                inp.z = Inputs.VerticalAxis();


                inp = transform.TransformDirection(inp);

                inp.x *= movespeed;
                inp.z *= movespeed;


                if (Inputs.B_Button())
                {
                    inp.y = jumpheight;
                }
            }

            inp.y -= gravity * Time.deltaTime;
            body.Move(inp * Time.deltaTime);
        }
    }

}

