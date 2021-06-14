using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public Camera dialogueCam;
    public Camera gameCam;
    public Animator transition;
    public Text topText;

    public static GameController instance;

    bool transitioning = false;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameCam.gameObject.SetActive(false);
        gameCam.enabled = false;

        dialogueCam.gameObject.SetActive(true);
        dialogueCam.enabled = true;

        player.gameObject.SetActive(false);
    }

    public void switchCam()
    {
        dialogueCam.enabled = !dialogueCam.enabled;
        dialogueCam.gameObject.SetActive(dialogueCam.enabled);

        gameCam.enabled = !gameCam.enabled;
        gameCam.gameObject.SetActive(gameCam.enabled);

        if (!gameCam.enabled)
        {
            player.gameObject.SetActive(false);
        }
        else
        {
            player.gameObject.SetActive(true);
        }
    }

    public void Transition()
    {
        StartCoroutine(startTransition());
    }

    public void LoadNextLevel()
    {
        StartCoroutine(startLevel());
    }

    public void MovePlayer(float x, float y)
    {
        StartCoroutine(startMove(x, y));
    }

    public void DisplayText(string s)
    {
        StartCoroutine(startText(s));
    }

    public void StopText()
    {
        topText.gameObject.SetActive(false);
        transition.SetTrigger("TopNext");
    }

    IEnumerator startTransition()
    {
        transitioning = true;

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        switchCam();

        transition.SetTrigger("Next");

        transitioning = false;
    }

    IEnumerator startLevel()
    {
        transitioning = true;

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        transitioning = false;
    }

    IEnumerator startMove(float x, float y)
    {
        transitioning = true;

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        playerMove(x, y);

        transition.SetTrigger("Next");

        transitioning = false;
    }

    IEnumerator startText(string s)
    {
        transition.SetTrigger("TopStart");

        yield return new WaitForSeconds(1);

        topText.gameObject.SetActive(true);
        topText.text = s;
    }

    public float playerPos()
    {
        return player.transform.position.x;
    }

    public void playerMove(float x, float y)
    {
        player.transform.position = new Vector3(x, y, 9);
    }

    public bool camEnabled()
    {
        return dialogueCam.enabled;
    }

    public bool isTransitioning()
    {
        return transitioning;
    }

    public float mouseCoords()
    {
        return gameCam.ScreenToWorldPoint(Input.mousePosition).x;
    }

}
