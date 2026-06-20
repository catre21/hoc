using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks // kế thừa từ MonoBehaviourPunCallbacks để có thể sử dụng các callback của Photon
{
    public void OnEnble()
    {
        PhotonNetwork.AutomaticallySyncScene = true;// đồng bộ hóa cảnh giữa các người chơi
        Connect();
    }
    public override void OnConnectedToMaster() // callback được gọi khi kết nối thành công với máy chủ Photon
    {
        Debug.Log("Connected to Master Server");
        Join();
    }
   public void Connect()
    {
        Debug.Log("Trying to connect to ...");
      PhotonNetwork.GameVersion = "0.0.0"; // phiên bản trò chơi, giúp đảm bảo rằng người chơi đang sử dụng cùng một phiên bản
      PhotonNetwork.ConnectUsingSettings(); // kết nối với máy chủ Photon bằng cách sử dụng c  }ấu hình đã định nghĩa trong PhotonServerSettings
    }
    public void Join()
    {
        
    }
    public void StartGame()
    {
        
    }
}
