using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginHandler : MonoBehaviour
{
    [SerializeField] private string _password;
    [SerializeField] private GameObject _content;
    [SerializeField] private TMP_InputField _passwordBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
