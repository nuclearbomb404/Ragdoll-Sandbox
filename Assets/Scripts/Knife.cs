using UnityEngine;

public class Knife : MonoBehaviour
{
    public float KnifeRange = 5f;
    float m_MaxDistance = 10f;
    public Transform aliveCheck;
    public float radius = 10f;
    public LayerMask aliveMask;
    public bool aliveinside;
    public LayerMask playerMask;
    public bool playerinside;
    public GameObject enemy;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q"))
        {
            stab();
        }
    }
    
    void stab()
    {
        
        Collider john = GetComponent<Collider>();
        
        {
            Collider[] hitColliders = Physics.OverlapSphere(aliveCheck.transform.position, radius);
            foreach (Collider hitCollider in hitColliders)
            {
                GameObject Inside = hitCollider.gameObject;
                if(Inside.tag == "Alive")
                {
                    Death death2 = Inside.gameObject.GetComponent<Death>();
                    death2.TakeDamage(25f);
                }


            }
        }

    }
}
