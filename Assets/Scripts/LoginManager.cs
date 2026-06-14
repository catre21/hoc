using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour

{
    public TMP_InputField usernameInput;
    public TMP_InputField passworInput;
    public  TMP_Text messageText;
    public void Register()
    {
        string username = usernameInput.text;
        string password = passworInput.text;
        if (username == "" || password == "")
        {
            messageText.text = "vui lòng nhập đầy đủ thông tin!";
            return;
        }
        PlayerPrefs.SetString("Username", username);
        PlayerPrefs.SetString("Password", password);
        messageText.text = "Đăng ký thành công!";
    }
    public void Login()
    {
        string username = usernameInput.text;
        string password = passworInput.text;
        string savedUser = PlayerPrefs.GetString("Username");
        string savedPass = PlayerPrefs.GetString("Password");
        if (username == savedUser && password == savedPass)
        {
            messageText.text = "Đăng nhật thành công!";
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            messageText.text = "Sai tài khoản hoạc mật khẩu!";
        }
    }
}
