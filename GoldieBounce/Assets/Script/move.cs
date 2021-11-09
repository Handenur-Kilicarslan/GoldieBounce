using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class move : MonoBehaviour
{

    Rigidbody rb;
    float force = -2.5f;
    float vectorUp = 15;
    float torque = -100;
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
            
            rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
            rb.AddForce(Vector3.up * vectorUp, ForceMode.Impulse);
            rb.AddTorque(torque, 0, 0);
            rotate();
        }
        else
        {
            force = -1;
            vectorUp = 8;
            torque = -100;
            rb.mass = 100;
            //force = -1.5f;
        }
        
    }
    void rotate()
    {
        transform.DORotate(new Vector3(transform.rotation.x - 360, transform.rotation.y, transform.rotation.z), 1f, RotateMode.LocalAxisAdd);
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
            other.gameObject.transform.DOScale(0, 0.1f);
            other.gameObject.name = "coin";

        }
    }

}
