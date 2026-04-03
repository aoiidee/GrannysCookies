using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GrannyText : MonoBehaviour
{
    [SerializeField] private string[] grannyDialogue;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject dialogeButton;
    public GameObject blur;
    public Image grannyImage;
    [SerializeField] private TMP_Text textShown;
    [SerializeField] private float textSpeed;
    [SerializeField] private float textDelay;
    private Coroutine dialogueCO;
    [SerializeField] private int index = 0;
    public bool dialogueActive;
    [SerializeField] private Animator _anim;

    void Start()
    {
        DisplayDialogue();
    }
    public void DisplayDialogue()
    {
        print("Showing dialogue");
        if (dialogueActive)
        {
            StopCoroutine(dialogueCO);
            index++;
        }
        dialogueCO = StartCoroutine(DialogueHandler());
    }
    IEnumerator DialogueHandler()
    {
        blur.SetActive(true);   
        dialogueActive = true;
        textShown.text = " ";
        string dialogue = grannyDialogue[index];
        dialogueBox.SetActive(true);
        grannyImage.gameObject.SetActive(true);
        if (index == 0 || index == 4)
        {
            _anim.Play("GrannyPortraitDefault");
        }
        else if (index == 1 || index == 7)
        {
            _anim.Play("GrannyPortraitExcited");
        }
        else if (index == 2 || index == 5)
        {
            _anim.Play("GrannyPortraitConfused");
        }
        else
        {
            _anim.Play("GrannyPortraitShocked");
        }
        foreach (char go in dialogue)
        {
            textShown.text += go;
            yield return new WaitForSeconds(textSpeed);
        }
        dialogeButton.SetActive(true);
    }
    public void EndDialogue()
    {
        blur.SetActive(false);  
        dialogeButton.SetActive(false); 
        dialogueActive = false;
        index++;
        dialogueBox.SetActive(false);
        grannyImage.gameObject.SetActive(false);
    }
}