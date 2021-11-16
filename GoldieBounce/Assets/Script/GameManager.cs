using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject followCam;
    public GameObject Player;
    public GameObject[] dizi;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //followCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = Player.transform;
    }

}
