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
    public GameObject number;
    public GameObject Player;
    public GameObject[] dizi;
    public GameObject light;
    public GameObject bomb;
    public static Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        number.GetComponent<move>().enabled = false;
        Player.GetComponent<collision>().enabled = false;
        move.rb.isKinematic = true;
        collision.rb.isKinematic = true;
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
        number.GetComponent<move>().enabled = true;
        Player.GetComponent<collision>().enabled = true;
        move.rb.isKinematic = false; 
        collision.rb.isKinematic = false;
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
        number.GetComponent<move>().enabled = false;
        Player.GetComponent<collision>().enabled = false;
        tapPlayUI.SetActive(true);
        Time.timeScale = 1;
        ResetGame();

        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void next() //Win UI butonu
    {
        Debug.Log("next");
        winUI.SetActive(false);
        number.GetComponent<move>().enabled = false; 
        Player.GetComponent<collision>().enabled = false;
        tapPlayUI.SetActive(true);
        collision.lastMove = false;
        Time.timeScale = 1;
        ResetGame(); //??MD?L?K

    }

    public void ResetGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        //transform.position = startPos;
    }
    /// <summary>
    /// /////////////////////////////////////////7777
    /// </summary>
    public void StartGame()  //UI A?ILI?I
    {
        //Debug.Log("handeyi seviyorum <3333");

        number.GetComponent<move>().enabled = false; 
        Player.GetComponent<collision>().enabled = false;
        tapPlayUI.SetActive(true);
        //PlayUI.SetActive(true);
        Time.timeScale = 1;
    }
    public void GameOver()  //UI A?ILI?I
    { 
        Time.timeScale = 1;
        number.GetComponent<move>().enabled = false;
        Player.GetComponent<collision>().enabled = false;
        failUI.SetActive(true);
    }

    public void Win() //UI A?ILI?I
    {
        number.GetComponent<move>().enabled = false;
        Player.GetComponent<collision>().enabled = false;
        winUI.SetActive(true);
        camkonfeti.SetActive(true);
    }



}
