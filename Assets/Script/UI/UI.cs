using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _pauseInterface;
    [SerializeField] private GameObject _playInterface;

    [Header("Buttons to listen")]
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;

    public UnityEvent PauseButtonClicked => _pauseButton.onClick;

    public UnityEvent ResumeButtonClicked => _resumeButton.onClick;

    public void ShowPlayInterface() => _playInterface.SetActive(true);

    public void HidePlayInterface() => _playInterface.SetActive(false);

    public void ShowPauseInterface() => _pauseInterface.SetActive(true);

    public void HidePauseInterface() => _pauseInterface.SetActive(false);
}
