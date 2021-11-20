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
    public GameObject[] dizi;
    // Start is called before the first frame update
    void Start()
    {
        Player.GetComponent<move>().enabled = false;
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
        tapPlayUI.SetActive(false);
        for (int i = 0; i <25; i++) {
            konfeti[i].SetActive(false);
        }
        camkonfeti.SetActive(false);
        Time.timeScale = 1;
    }
    public void restart() //Fail UI butonu
    {
        Debug.Log("restart");
        Player.GetComponent<move>().enabled = false;
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
        tapPlayUI.SetActive(true);
        move.lastMove = false;
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
        tapPlayUI.SetActive(true);
        //PlayUI.SetActive(true);
        Time.timeScale = 1;
    }
    public void GameOver()  //UI AÇILIÞI
    {
        Time.timeScale = 1;
        Player.GetComponent<move>().enabled = false;
        failUI.SetActive(true);
    }

    public void Win() //UI AÇILIÞI
    {
        Player.GetComponent<move>().enabled = false;
        winUI.SetActive(true);
        camkonfeti.SetActive(true);
    }



}
