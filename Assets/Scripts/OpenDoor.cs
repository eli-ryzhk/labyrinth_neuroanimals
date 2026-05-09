using System.Collections;
using UnityEngine;

public class Opener : MonoBehaviour
{
    private Animator anim;
    private LayerMask Layer;
    private float distance;
    private GameObject cam;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if(Physics.Raycast(ray, out hit, distance, Layer))
        {
            if(Input.GetKeyDown(KeyCode.G))
            {
                anim.SetBool("Open",true);
            }
            if(Input.GetKeyDown(KeyCode.H))
            {
                anim.SetBool("Open",false);
            }
        }
    }
}
