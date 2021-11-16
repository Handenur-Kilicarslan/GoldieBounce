using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class move : MonoBehaviour
{

    Rigidbody rb;
    float force = 10f;
    float vectorUp = 10;
    float torque = -100;
    int toplam = 0;
    Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0f, 70f), transform.position.z);

        if (Input.GetMouseButtonDown(0))
        {
            rb.mass = 1.5f;

            //rb.transform.Translate(Vector3.forward * Time.deltaTime * force);
            //rb.transform.Translate(Vector3.up * vectorUp * Time.deltaTime);

            rb.AddForce(Vector3.forward * force, ForceMode.VelocityChange);
            rb.AddForce(Vector3.up * vectorUp, ForceMode.VelocityChange);
            rb.AddTorque(torque, 0, 0);
            rotate();
        }
        else
        {
            force = 2;
            vectorUp = 7;
            torque = -100;
            rb.mass = 100;
            //force = -1.5f;
        }
        
    }
    void rotate()
    {
        transform.DORotate(new Vector3(transform.rotation.x + 360, transform.rotation.y, transform.rotation.z), 1f, RotateMode.LocalAxisAdd);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "coin")
        {
            //transform.DOScale(transform.localScale * 1.5f, 0.1f).OnComplete(() => transform.DOScale(transform.localScale / 1.5f, 0.1f));
            transform.DOScaleX(scale.x += 6, 0.3f).OnComplete(() => transform.DOScaleX(scale.x += 0.015f, 0.017f));
            transform.DOScaleY(scale.y += 6, 0.3f).OnComplete(() => transform.DOScaleY(scale.y += 0.015f, 0.017f));
            transform.DOScaleZ(scale.z += 6, 0.3f).OnComplete(() => transform.DOScaleZ(scale.z += 0.015f, 0.017f));
            transform.DOScaleX(scale.x -= 6, 0.3f);
            transform.DOScaleY(scale.y -= 6, 0.3f);
            transform.DOScaleZ(scale.z -= 6, 0.3f);
            other.gameObject.transform.DOScale(0, 0.1f).OnComplete(() => Destroy(other.transform.gameObject));
            other.gameObject.name = "coin";
            toplam += 1;

        }
        //Debug.Log(toplam);

        if (other.gameObject.name == "finish")
        {
            gameObject.transform.DOMove(new Vector3(9.94f, 124, -43), 2f).OnComplete(() => gameObject.transform.DOMove(new Vector3(9.94f, 55, -43f), 0.9f));
            rb.mass = 20000;
            
        }
       
       

    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "taht")
        {
            Debug.Log("deneme");
            //other.gameObject.transform.GetChild(0).DORotate(new Vector3(0,102,0), 1.5f);
        }
        if (collision.gameObject.name == "Armature")
        {
            Debug.Log("çarptý");
            collision.gameObject.transform.DORotate(new Vector3(90,-90,-13), 1, RotateMode.Fast);
        }
    }
    */

}
