using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mouselook : MonoBehaviour
{
    public GameObject car;
    public GameObject Player;
    public float xrotation = 0f;
    public Transform playerbody;
    public float mousesensitivity = 100f;
    public bool inputD = false;
    public bool inputA = false;
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        Car carscript = Player.GetComponent<Car>();
        float mousex =  Input.GetAxis("Mouse X") * mousesensitivity * Time.deltaTime;
        float mousey =  Input.GetAxis("Mouse Y") * mousesensitivity * Time.deltaTime;


        xrotation -= mousey;
        xrotation = Mathf.Clamp(xrotation,-90f, 90);
        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        playerbody.Rotate(Vector3.up * mousex );
        
        if(carscript.MovDisabled)
        {
            xrotation -= mousey;
            xrotation = Mathf.Clamp(xrotation,-90f, 90);
            transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
            if(Input.GetKeyDown("d"))
            {
                inputD = true;

            }
            if(inputD)
            {
                car.transform.Rotate(Vector3.up * 100 * Time.deltaTime);
            }
            if(!Input.GetKey("d"))
            {
                inputD = false;
            }
            
            //Same but with "A" dumbass
            
            if(Input.GetKeyDown("a"))
            {
                inputA = true;

            }
            if(inputA)
            {
                car.transform.Rotate(Vector3.up * -100 * Time.deltaTime);
            }
            if(!Input.GetKey("a"))
            {
                inputA = false;
            }
            
            
        }
        
        
    }
}
