using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class move : MonoBehaviour
{
    public GameObject karakter;
    Animator anim;
    GameManager gm;
    public static Rigidbody rb;
    public static float force = 17f;
    float vectorUp = 17;
    float torque = 10;
    int toplam = 0;
    static int hesap = 0;
    public static bool taklakontrol = false;
    public static bool sevinkontrol = false;
    public static bool lastMove = false;

    Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        scale = transform.localScale;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        anim = GameObject.Find("tahterevalli").GetComponent<Animator>();
       
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
            rotate();
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
       

        if (other.gameObject.name == "finish") //finish �izgisini ge�me
        {
            StartCoroutine(bekleiki());
            

        }
        if (other.gameObject.tag == "cube") //karakteri yukar� f�rlatma
        {
            lastMove = true;
            anim.enabled = true;
            StartCoroutine(bekle());
            taklakontrol = true;
            for (int i = 1; i <= hesap; i++)
            {
                karakter.transform.DOMove(new Vector3(9.8f, 61 + (i * 8.8f), 27), (i*0.3f));
                sevinkontrol = true;
            }
            StartCoroutine(beklewin());
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "taht")
        {
            Debug.Log("deneme");
        }
        if (collision.gameObject.name == "Armature")
        {
        }
    }
    IEnumerator bekle()
    {
        //kodlar
        if (toplam < 100)
        {
            hesap = toplam / 4;
            for (int i = 1; i <= hesap; i++)
            {

                gm.dizi[i - 1].GetComponent<x_move>().enabled = true;
                yield return new WaitForSeconds(0.2f);
            }
        }
        else
        {
            hesap = 25;
            for (int i = 1; i <= hesap; i++)
            {

                gm.dizi[i - 1].GetComponent<x_move>().enabled = true;
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
    IEnumerator bekleiki()
    {
        //kodlar
        gameObject.transform.DOMove(new Vector3(9.94f, 124, -13f), 2f);
        rb.mass = 20000;
        yield return new WaitForSeconds(2f);
        gameObject.transform.DOMove(new Vector3(9.94f, 55, -13f), 1f);
    }
    IEnumerator beklewin()
    {
        //kodlar
        Debug.Log("bekliyor");
        yield return new WaitForSeconds(7f);
        FindObjectOfType<GameManager>().Win();
    }
}
