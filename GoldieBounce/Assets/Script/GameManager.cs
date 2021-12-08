using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject tapPlayUI;
    public GameObject failUI;
    public GameObject winUI;


    public GameObject[] konfeti;
    public GameObject camkonfeti;
    public GameObject followCam;
    public GameObject Player;
    public GameObject Playerchild;
    public GameObject[] dizi;
    public GameObject light;
    public GameObject bomb;
    public static Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player.GetComponent<move>().enabled = false;
        Playerchild.GetComponent<collision>().enabled = false;
        move.rb.isKinematic = true;
        tapPlayUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
    /*
    void PauseGame()
    {

        //Player.GetComponent<SwipeTest>().enabled = false;
        Time.timeScale = 0;
    }
    */

    /*
    public void resume()
    {
        Time.timeScale = 1;
    }
    */
    

    public void tapstart()  //Start UI butonu
    {
        //Debug.Log("handeyi seviyorum <3");
        Player.GetComponent<move>().enabled = true;
        Playerchild.GetComponent<collision>().enabled = true;
        move.rb.isKinematic = false;
        tapPlayUI.SetActive(false);
        for (int i = 0; i <25; i++) {
            konfeti[i].SetActive(false);
        }
        camkonfeti.SetActive(false);
        light.SetActive(false);
        bomb.SetActive(false);
        Time.timeScale = 1;
    }
    public void restart() //Fail UI butonu
    {
        Debug.Log("restart");
        Player.GetComponent<move>().enabled = false;
        Playerchild.GetComponent<collision>().enabled = false;
        tapPlayUI.SetActive(true);
        Time.timeScale = 1;
        ResetGame();

        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void next() //Win UI butonu
    {
        Debug.Log("next");
        winUI.SetActive(false);
        Player.GetComponent<move>().enabled = false; 
        Playerchild.GetComponent<collision>().enabled = false;
        tapPlayUI.SetActive(true);
        collision.lastMove = false;
        Time.timeScale = 1;
        ResetGame(); //ÞÝMDÝLÝK

    }

    public void ResetGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        //transform.position = startPos;
    }
    /// <summary>
    /// /////////////////////////////////////////7777
    /// </summary>
    public void StartGame()  //UI AÇILIÞI
    {
        //Debug.Log("handeyi seviyorum <3333");

        Player.GetComponent<move>().enabled = false; 
        Playerchild.GetComponent<collision>().enabled = false;
        tapPlayUI.SetActive(true);
        //PlayUI.SetActive(true);
        Time.timeScale = 1;
    }
    public void GameOver()  //UI AÇILIÞI
    { 
        Time.timeScale = 1;
        Player.GetComponent<move>().enabled = false;
        Playerchild.GetComponent<collision>().enabled = false;
        failUI.SetActive(true);
    }

    public void Win() //UI AÇILIÞI
    {
        Player.GetComponent<move>().enabled = false;
        Playerchild.GetComponent<collision>().enabled = false;
        winUI.SetActive(true);
        camkonfeti.SetActive(true);
    }



}
