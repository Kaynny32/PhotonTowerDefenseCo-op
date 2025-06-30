using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnerPlayer : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
       GameObject player = PhotonNetwork.Instantiate("Player", new Vector3(0, 1, 0), Quaternion.identity);
        player.GetComponent<PlayerSetup>().IsLocalPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
