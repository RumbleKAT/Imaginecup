using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToGame : MonoBehaviour {

    public void GoToGames()
    {
        SceneManager.LoadScene(2);
    }
}
