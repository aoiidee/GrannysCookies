using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Slider progressBar;

    public void Progress(int num)
    {
        progressBar.value += num;
    }

}
