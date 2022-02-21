using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    [SerializeField] private Text timerTxt;

    public bool isGameOver = false;

    private float timeValue = 100;

    void Start()
    {
        
    }

    void Update()
    {
        if (!isGameOver)
        {
            timeValue -= 1 * Time.deltaTime;
            timerTxt.text = Mathf.Round(timeValue).ToString();
        }

        if (timeValue <= 0)
        {
            isGameOver = true;
            timerTxt.text = "Game Over";
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("MainMenu");
    }
}
