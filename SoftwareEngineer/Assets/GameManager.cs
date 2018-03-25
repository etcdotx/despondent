using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject deathmenu;
    public GameObject winmenu;
    public GameObject layover;
    public void backtoscene(int number) {
        SceneManager.LoadScene(number);
    }

    public void death() {
        layover.SetActive(true);
        deathmenu.SetActive(true);
    }

    public void Win() {
        layover.SetActive(true);
        winmenu.SetActive(true);
    }

}
