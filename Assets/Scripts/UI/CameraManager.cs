using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{

    Transform target;
    bool following;
    float xpos, ypos; //Standsfor how far extra the camera is behind or in front;
    Vector3 veloc;




    void Init()
    {
        following = true;
        target = GameObject.Find("Player").transform;

    }
    // Use this for initialization
    void Start()
    {
        if (Game.Instance.state == GameState.InWorld)
        {
            Init();
            transform.LookAt(target);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Game.Instance.state == GameState.InWorld && target != null)
        {
            ;
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x, target.position.z, transform.position.y), ref veloc, .5f);
        }
    }

    
}
