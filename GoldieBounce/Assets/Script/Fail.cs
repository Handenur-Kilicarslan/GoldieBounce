using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name == "Player")
        {
            gameObject.transform.DOScale(0, 0.2f).OnComplete(() => Destroy(transform.gameObject));            
            other.gameObject.transform.DOScale(0, 0.2f).OnComplete(() => Destroy(other.transform.gameObject));
            //game over
        }
    }
}
