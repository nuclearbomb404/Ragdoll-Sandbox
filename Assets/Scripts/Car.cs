using UnityEngine;
using UnityEngine.Animations;

public class Car : MonoBehaviour
{
    public Rigidbody Prb;
    public Rigidbody rb;
    public GameObject Player;
    public GameObject car;
    public GameObject seat;
    public bool MovDisabled = false;
    public GameObject thirdPersonCam;
    public CharacterController carcontroller;
    public GameObject Gun;
    // Update is called once per frame
    void Update ()
    {
        if(Input.GetKey("e"))
        {
         RaycastHit hit;
          if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10))
          {
              if(hit.transform.tag == "Car")
              {
                 disablemovement();
              }
          }
        }


        if (MovDisabled)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.forward * z;
            carcontroller.Move(move * 100 * Time.deltaTime);
        }

    }



    public void disablemovement()
    {

        Player.GetComponent<CapsuleCollider>().enabled = true;
        Player.GetComponent<ParentConstraint>().enabled = true;
        playermovement Playermovement = Player.GetComponent<playermovement>();
        Playermovement.enabled = false;
        Player.transform.position = seat.transform.position;
        MovDisabled = true;
        Camera.main.transform.position = thirdPersonCam.transform.position;
    }
}
