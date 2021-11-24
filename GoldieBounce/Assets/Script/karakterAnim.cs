using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterAnim : MonoBehaviour
{
    Animator animator;
    int taklaHash;
    int sevinHash;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        taklaHash = Animator.StringToHash("takla");
        sevinHash = Animator.StringToHash("sevin");
    }

    // Update is called once per frame
    void Update()
    {

        bool bosta = animator.GetBool(taklaHash);
        bool sevin = animator.GetBool(sevinHash);
        
        if (move.taklakontrol == true)
        {
            Debug.Log("animasyonda");
            animator.SetBool("takla", true);
        }
        if (move.taklakontrol == false)
        {
            Debug.Log("animasyonda deðil");
            animator.SetBool("takla", false);
        } 
        
        if (move.sevinkontrol == true)
        {
            Debug.Log("animasyonda 2");
            animator.SetBool("sevin", true);
        }
        if (move.sevinkontrol == false)
        {
            Debug.Log("animasyonda deðil2");
            animator.SetBool("sevin", false);
        }

    }
    public static void takla()
    {


    }
}
