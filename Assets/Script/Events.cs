using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;


public class Events : MonoBehaviour
{
    public GameObject[] bodies;
    public GameObject bodyparent;
    public static int selectedBody;

    public void PlayGame()
    {
        PlayerManager.isGameStarted = true;
        FindObjectOfType<AudioManager>().PlaySound("BGM");
        Instantiate(bodies[selectedBody], bodyparent.transform);
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void P1()
    {
        selectedBody = 0;
    }
    public void P2()
    {
        selectedBody = 1;
    }
    public void P3()
    {
        selectedBody = 2;
    }
}
