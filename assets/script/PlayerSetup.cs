using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public movement movement;

    public GameObject cammera;

    public string nickname;

    public TMP_Text nicknameText;
    public void IsLocalPlayer()
    {
        movement.enabled = true;
        cammera.SetActive(true);
    }

    [PunRPC]
    public void SetNickName(string name)
    {
        name=nickname;
        nicknameText.text = nickname;
    }

}