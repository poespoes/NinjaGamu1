using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCheck : MonoBehaviour
{
    public bool RayCheckIsTrue;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RayCheckIsTrue) {
            anim.SetTrigger("isPlaying");
        }
    }

    /*private RaycastHit2D CheckRaycast(Vector2 direction) {

    }*/
}
