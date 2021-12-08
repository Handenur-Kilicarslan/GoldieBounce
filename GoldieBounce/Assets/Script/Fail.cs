using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fail : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

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
            StartCoroutine(bomb());
            gameObject.transform.DOScale(0, 0.2f);
            //move.rb.isKinematic = true;
            Debug.Log("bomba");
            //other.gameObject.transform.parent.DOScale(0, 0.2f);
            //FindObjectOfType<GameManager>().GameOver();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.name == "Player")
        {

            move.rb.isKinematic = true;
            collision.gameObject.transform.parent.DOScale(0, 0.2f);
            FindObjectOfType<GameManager>().GameOver();
        }
    }
    IEnumerator bomb()
    {
        Debug.Log("light");
        gm.bomb.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        gm.bomb.SetActive(false);


    }
}
