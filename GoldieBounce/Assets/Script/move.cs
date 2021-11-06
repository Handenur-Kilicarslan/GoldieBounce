using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class move : MonoBehaviour
{

    Rigidbody rb;
    float force = -2;
    float vectorUp = 10;
    float torque = 100;
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

        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
            rb.AddForce(Vector3.up * vectorUp, ForceMode.Impulse);
            rb.AddTorque(torque, 0, 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "coin")
        {
            transform.DOScaleX(scale.x += 0.01f, 1f);
            transform.DOScaleY(scale.y += 0.01f, 1f);
            transform.DOScaleZ(scale.z += 0.01f, 1f);
            other.gameObject.transform.DOScale(0, 1f);
            other.gameObject.name = "coin";
        }
    }

}
