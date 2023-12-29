using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Numerics;

public class roommanager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        Debug.Log("Connecting...");
        PhotonNetwork.ConnectUsingSettings();

    }


    public override void OnConnectedToMaster() {
        base.OnConnectedToMaster();

        Debug.Log("Connected To Server!");

        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        PhotonNetwork.JoinOrCreateRoom("test", null , null);

        Debug.Log("We're Connected and in a room now!");

    }
}
