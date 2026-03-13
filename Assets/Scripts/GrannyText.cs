using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GrannyText : MonoBehaviour
{
    [SerializeField] private string[] grannyDialogue;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private Image grannyImage;
    [SerializeField] private TMP_Text textShown;
    [SerializeField] private float textSpeed;
    [SerializeField] private float textDelay;
    private Coroutine dialogueCO;
    [SerializeField] private int index = 0;
    private bool dialogueActive;
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
        dialogueActive = true;
        textShown.text = " ";
        string dialogue = grannyDialogue[index];
        dialogueBox.SetActive(true);
        grannyImage.gameObject.SetActive(true);
        foreach (char go in dialogue)
        {
            textShown.text += go;
            yield return new WaitForSeconds(textSpeed);
        }
        if(index != 0)
        {
            yield return new WaitForSeconds(textDelay);
            EndDialogue();
        }
    }
    private void EndDialogue()
    {
        dialogueActive = false;
        index++;
        dialogueBox.SetActive(false);
        grannyImage.gameObject.SetActive(false);
    }
}