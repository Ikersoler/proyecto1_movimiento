using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



       

    }
}
