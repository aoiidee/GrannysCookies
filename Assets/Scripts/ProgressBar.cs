using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private int _progressSpeed;
    [SerializeField] Slider progressBar;
    [SerializeField] private UnityEvent _halfwayActions;
    [SerializeField] private UnityEvent _almostDoneActions;

    private bool hitHalf = false;
    private bool completed = false;

    public void Start()
    {
        PopupFunctions.minigameComplete += StartProgress;
    }
    public void Progress(int num)
    {
        progressBar.value += num;
    }

    public void StartProgress()
    {
        if(isActiveAndEnabled)
        StartCoroutine(IncreaseProgressCoroutine());
    }

    public void StopProgress()
    {
        StopAllCoroutines();
    }

    IEnumerator IncreaseProgressCoroutine()
    {
        while(progressBar.value < progressBar.maxValue)
        {
            Progress(_progressSpeed);

            if(progressBar.value > progressBar.maxValue / 2 && !hitHalf)
            {
                hitHalf = true;
                _halfwayActions.Invoke();
            }
            yield return new WaitForFixedUpdate();
        }
        completed = true;
        _almostDoneActions.Invoke();
    }

    private void OnDestroy()
    {
        PopupFunctions.minigameComplete -= StartProgress;
    }

}
