using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Animator animator;
    move move;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collision.lastMove == true)
        {
            Debug.Log("ikinci kamera");

            animator.Play("cam02");
        }
        if (collision.lastMove == false)
        {
            Debug.Log("ilk kamera");
            animator.Play("cam01");
        }

    }
}
