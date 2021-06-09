using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BubbleScript : MonoBehaviour
{
    [SerializeField] GameObject scoreText, playCanvas, winCanvas, loseCanvas;
    int score = 0;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score = " + score + "/20";

        if (score < 0)
        {
            playCanvas.SetActive(false);
            loseCanvas.SetActive(true);
            StartCoroutine(QuitRoutine());
        }

        if (score >= 20)
        {
            playCanvas.SetActive(false);
            winCanvas.SetActive(true);
            StartCoroutine(QuitRoutine());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.gameObject;

        if (otherObject.tag == "redfish")
        {
            score--;
            Destroy(otherObject.transform.parent.gameObject);
        }

        if (otherObject.tag == "bluefish")
        {
            score++;
            Destroy(otherObject.transform.parent.gameObject);
        }
    }
    IEnumerator QuitRoutine()
    {
        //Do something before waiting.


        //yield on a new YieldInstruction that waits for X seconds.
        yield return new WaitForSeconds(5);

        //Do something after waiting.
        Application.Quit();
    }
}
