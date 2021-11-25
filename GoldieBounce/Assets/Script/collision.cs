using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class collision : MonoBehaviour
{
    public GameObject karakter;
    int toplam = 0;
    Vector3 scale;
    Animator anim;
    GameManager gm;
    static int hesap = 0;
    public static bool taklakontrol = false;
    public static bool sevinkontrol = false;
    public static bool lastMove = false;

    public Text goldText;

    void Start()
    {
        scale = transform.localScale;
        anim = GameObject.Find("tahterevalli").GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "" + toplam;
        if (Input.GetMouseButtonDown(0))
        {
            rotate();
        }


    }
    void rotate()
    {
        transform.DORotate(new Vector3(transform.rotation.x - 180, transform.rotation.y, transform.rotation.z), 1f, RotateMode.LocalAxisAdd);
    }

    //eþdost
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "coin")
        {
            StartCoroutine(light());
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

        if (other.gameObject.name == "finish") //finish çizgisini geçme
        {
            StartCoroutine(bekleiki());
            transform.DORotate(new Vector3(0, -180, 0), 0.1f, RotateMode.LocalAxisAdd);

        }
        if (other.gameObject.tag == "cube") //karakteri yukarý fýrlatma
        {
            lastMove = true;
            anim.enabled = true;
            StartCoroutine(bekle());
            StartCoroutine(beklekonfeti());
            taklakontrol = true;
            for (int i = 1; i <= hesap; i++)
            {
                karakter.transform.DOMove(new Vector3(9.8f, 61 + (i * 8.8f), 27), (i * 0.3f));
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

                gm.konfeti[i].SetActive(true);

                gm.dizi[i - 1].GetComponent<x_move>().enabled = true;
                yield return new WaitForSeconds(0.2f);
            }
        }
        else
        {
            hesap = 25;
            for (int i = 1; i <= hesap; i++)
            {
                gm.konfeti[i].SetActive(true);
                gm.dizi[i - 1].GetComponent<x_move>().enabled = true;
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
    IEnumerator beklekonfeti()
    {
        //kodlar
        if (toplam < 100)
        {
            hesap = toplam / 4;
            for (int i = 1; i <= hesap; i++)
            {

                gm.konfeti[i].SetActive(true);
                yield return new WaitForSeconds(0.5f);
            }
        }
        else
        {
            hesap = 25;
            for (int i = 1; i <= hesap; i++)
            {
                gm.konfeti[i].SetActive(true);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    IEnumerator bekleiki()
    {
        //kodlar
        gameObject.transform.DOMove(new Vector3(9.94f, 124, -13f), 2f);
        move.rb.mass = 20000;
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
    IEnumerator light()
    {
        Debug.Log("light");
        gm.light.SetActive(true);
        yield return new WaitForSeconds(0.8f);

        gm.light.SetActive(false);


    }
}
