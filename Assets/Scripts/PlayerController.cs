using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    float speed = 5.0f;
    public GameObject gameScoreGO;
    int iCount = 10;
    int iTotalPowerUpLeft;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Winning Condition
        iTotalPowerUpLeft = GameObject.FindGameObjectsWithTag("PowerUp").Length;
        Debug.Log("Power Ups have left: " + iTotalPowerUpLeft.ToString());

        if (iTotalPowerUpLeft == 0)
        {
            Debug.Log("Going Over to new SCENE NOW when All power ups are taken!");
            SceneManager.LoadScene("GameWinScene");
        }

        //Forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        //Backward
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        //Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //Right
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        //Decrease Health
        if (Input.GetKeyDown(KeyCode.Space))
        {
            iCount--;
            gameScoreGO.GetComponent<Text>().text = "Game Score: " + iCount.ToString();

            if (iCount == 0)
            {
                Debug.Log("Going Over to new SCENE NOW");
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

    //Increase Score && Losing Condition
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            iCount++;
            gameScoreGO.GetComponent<Text>().text = "Game Score: " + iCount.ToString();

            Destroy(other.gameObject);
            
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOverScene");

            Destroy(other.gameObject);
        }
    }
}
