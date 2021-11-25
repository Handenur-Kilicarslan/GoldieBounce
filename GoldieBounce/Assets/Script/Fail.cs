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
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.DOScale(0, 0.2f);
            move.rb.isKinematic = true;
            other.gameObject.transform.DOScale(0, 0.2f);
            FindObjectOfType<GameManager>().GameOver();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.name == "Player")
        {

            move.rb.isKinematic = true;
            collision.gameObject.transform.DOScale(0, 0.2f);
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
