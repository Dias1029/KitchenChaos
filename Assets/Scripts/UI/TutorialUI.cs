using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyMoveUpText;
    [SerializeField] private TextMeshProUGUI keyMoveDownText;
    [SerializeField] private TextMeshProUGUI keyMoveRightText;
    [SerializeField] private TextMeshProUGUI keyMoveLeftText;
    [SerializeField] private TextMeshProUGUI KeyInteractText;
    [SerializeField] private TextMeshProUGUI KeyInteractAlternateText;
    [SerializeField] private TextMeshProUGUI keyPauseText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractAlternateText;
    [SerializeField] private TextMeshProUGUI keyGamepadPauseText;

    private void Start()
    {
        Game_Input.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        UpdateVisual();
        Show();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
    }

    private void GameInput_OnBindingRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        keyMoveUpText.text = Game_Input.Instance.GetBindingText(Game_Input.Binding.Move_Up);
        keyMoveDownText.text = Game_Input.Instance.GetBindingText(Game_Input.Binding.Move_Down);
        keyMoveRightText.text = Game_Input.Instance.GetBindingText(Game_Input.Binding.Move_Right);
        keyMoveLeftText.text = Game_Input.Instance.GetBindingText(Game_Input.Binding.Move_Left);
        KeyInteractText.text = Game_Input.Instance.GetBindingText(Game_Input.Binding.Interact);
        KeyInteractAlternateText.text = Game_Input.Instance.GetBindingText(Game_Input.Binding.InteractAlternate);
        keyPauseText.text = Game_Input.Instance.GetBindingText(Game_Input.Binding.Pause);
        keyGamepadInteractText.text = Game_Input.Instance.GetBindingText(Game_Input.Binding.Gamepad_Interact);
        keyGamepadInteractAlternateText.text = Game_Input.Instance.GetBindingText(Game_Input.Binding.Gamepad_InteractAlternate);
        keyGamepadPauseText.text = Game_Input.Instance.GetBindingText(Game_Input.Binding.Gamepad_Pause);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
