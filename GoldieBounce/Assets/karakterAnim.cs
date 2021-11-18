using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterAnim : MonoBehaviour
{
    Animator animator;
    int durmaHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        durmaHash = Animator.StringToHash("durma");
    }

    // Update is called once per frame
    void Update()
    {

        bool durma = animator.GetBool(durmaHash);
        if (move.kontrol == true)
        {
            Debug.Log("animasyonda");
            animator.SetBool("durma", false);
        }
    }
    public static void takla()
    {


    }
}
