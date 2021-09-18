using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundCheck : MonoBehaviour
{
    public LayerMask GroundMask;
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 1f, GroundMask);
        foreach (Collider hitCollider in hitColliders)
        {
            GameObject Inside = hitCollider.gameObject;
            transform.root.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if(transform.position.y < -15)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
