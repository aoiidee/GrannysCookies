using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginHandler : MonoBehaviour
{
    [SerializeField] private string _password;
    [SerializeField] private GameObject _content;
    [SerializeField] private TMP_InputField _passwordBox;
    public void CheckPassword()
    {
        
        if(_passwordBox.text == _password)
        {
            Debug.Log("Password correct!");
            _content.SetActive(false);
        }
        else
        {
            Debug.Log("Wrong password!");
        }
    }
}
