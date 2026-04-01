using UnityEngine;


public class GrannyDog : MonoBehaviour
{
    public void Bark()
    {
        AudioManager.PlaySound("DogBark");
    }

    public void DialUp()
    {
        AudioManager.PlaySound("DialUp");
    }
    public void TextBubble()
    {
        AudioManager.PlaySound("IconAsc");
    }
}
