using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed = 40.0f;
    [SerializeField] private float lateralSpeed = 40.0f;
    [SerializeField] private GameObject camera;
    private Vector3 o = new Vector3(0, 5, -3);
    //[SerializeField] private Vector3 offset = new Vector3(x:5.605632f, y:4.228873f, z:0.8375549f);

    private float horizontalImput;
    private float verticalImput;
    private float rotationImput;

    private int lives;
    private float lowerLimit = -3f;
    private bool isGameOver;
    private Vector3 initialPosition;

    private Rigidbody playerRigidbody;

    private uiManager ui;

    private void Awake()
    {
        lives = 3;
        isGameOver = false;
        initialPosition = Vector3.zero;
        playerRigidbody = GetComponent<Rigidbody>();
        ui = FindObjectOfType<uiManager>();
        ui.livestext(lives);
        ui.hidePanels();

    }



    void Update()
    {
        //la deteccion de imputs siempre en el update
        horizontalImput = Input.GetAxis("Horizontal");
        verticalImput = Input.GetAxis("Vertical");
        //rotationImput = Input.GetAxis("");

        //rotar
        transform.Rotate(Vector3.up, lateralSpeed * Time.deltaTime * horizontalImput);

        //para alante
        transform.Translate(translation:Vector3.forward * speed * Time.deltaTime * verticalImput);

        //pa los laos
        //transform.Translate(translation:Vector3.right * lateralSpeed * Time.deltaTime * horizontalImput);

        camera.transform.position = transform.position + o;// + offset;

        if (isGameOver)
        {
            return;
        }

        if (transform.position.y < lowerLimit)
        {
            lives--;
            if (lives <= 0)
            {
                //GAME OVER
                isGameOver = true;
                Time.timeScale = 0f;
                ui.livestext(lives);
                ui.GameOverPanel();
                
            }
            else
            {
                transform.position = initialPosition;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                playerRigidbody.velocity = Vector3.zero;
                ui.livestext(lives);
            }
        }

        if (transform.position.z > 75) 
        {
            Time.timeScale = 0f;
            ui.winPanel(3 - lives);
        }


    }


    public bool GetIsGameOver()
    {
        return isGameOver;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }


}
