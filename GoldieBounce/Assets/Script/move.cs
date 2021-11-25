using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public GameObject karakter;
    
    GameManager gm;
    public static Rigidbody rb;
    public static float force = 17f;
    public static float vectorUp = 17f;
    float torque = 10f;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();   
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.isKinematic = false;
        if (Input.GetMouseButtonDown(0))
        {
            rb.mass = 1.5f;
            rb.velocity = Vector3.forward * force;
            rb.AddForce(Vector3.up * vectorUp, ForceMode.VelocityChange);
            rb.AddTorque(torque, 0, 0);
            //rotate();
        }
        else
        {

            force = 13;
            vectorUp = 8;
            torque = 10;
            rb.mass = 1000;
            //force = -1.5f;
        }
        
    }
        void rotate()
    {
        transform.DORotate(new Vector3(transform.rotation.x - 180, transform.rotation.y, transform.rotation.z), 1f, RotateMode.LocalAxisAdd);
    }

}
