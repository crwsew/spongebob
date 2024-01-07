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

 public TextMeshProUGUI nicknameText;
public void IsLocalPlayer(){
    movement.enabled = true;
    cammera.SetActive(true);
}

[PunRPC]
public void SetNickName(string _name) {
    nickname = _name;
    nicknameText.text = nickname;
}

}