using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public PhotonView pview;
    public GameObject pointFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pview.IsMine)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject obj = (GameObject)
                    PhotonNetwork.Instantiate("bullet", pointFire.transform.position, pointFire.transform.rotation, 0);
                

            }
        }
    }
}
