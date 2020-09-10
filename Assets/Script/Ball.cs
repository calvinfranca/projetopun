using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public PhotonView pview;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (pview.IsMine)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                gameObject.GetComponent<Rigidbody>().AddExplosionForce(10, transform.position, 20);
            }
        }
    }
}
