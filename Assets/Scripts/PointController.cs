using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{
    public KeyCode KeyCode1;
    public KeyCode PauseButton;
    public KeyCode PlayButton;

    private Animator anim;
    private Touch theTouch;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode1)) {
            anim.SetTrigger("toNextPoint");

        }
        if (Input.GetKeyUp(PauseButton)) {
            anim.speed = 0;
        }
        if (Input.GetKeyUp(PlayButton)) {
            anim.speed = 1;
        }

        //IF SCREEN IS TOUCHED BY ONE FINGER THEN...
        /*if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
            Debug.Log("hit!");
            anim.speed = 1;
        }*/

        //IF SCREEN IS TOUCHED BY ONE FINGER THEN CAST A 3D RAYCAST
        /*if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) {
                if(hit.collider != null) {
                    Debug.Log("hit!");
                }
            }
        }*/

        //IF SCREEN IS TOUCHED BY ONE FINGER THEN CAST A 2D RAYCAST
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {

            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider.CompareTag("Button1")) {
                    Debug.Log("Button1 hit!");
                }
            }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)) {

            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider.CompareTag("Button1")) {
                Debug.Log("Button1 hit!");
                anim.speed = 1;
            }
        }
    }
#endif

    public void Pause() {
        anim.speed = 0;
    }

    public void Play() {
        anim.speed = 1;
    }
}


