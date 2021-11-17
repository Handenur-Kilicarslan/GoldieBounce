using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class x_move : MonoBehaviour
{
    private void Start()
    {
        domove();
        /*
        for (int i = 1; i <= transform.childCount; i++)
        {
            Debug.Log(gameObject.transform.GetChild(i - 1));
            if (gameObject.transform.GetChild(i - 1).name == i + "x")
            {
                Debug.Log(gameObject.transform.GetChild(i - 1));

                
                //Debug.Log(gameObject.transform.childCount);
            }
           
        }
        */

    }
    
    private void Update()
    {
        

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Karakter")
        {
            Debug.Log("geçti");
        }

    }
   
    private void domove()
    {
        gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 6), 0.2f);

    }

}
