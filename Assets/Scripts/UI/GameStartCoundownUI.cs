using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCoundownUI : MonoBehaviour
{
    private const string NUMBER_POPUP = "NumberPopUp";
    [SerializeField] private TextMeshProUGUI countDownText;

    private Animator animator;
    private int previousCountdownNumber;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        Hide();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountdownToStartActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Update()
    {
        int countDownNumber = Mathf.CeilToInt(GameManager.Instance.GetCountDownToStartTimer());
        countDownText.text = countDownNumber.ToString();

        if (previousCountdownNumber != countDownNumber)
        {
            previousCountdownNumber = countDownNumber;
            animator.SetTrigger(NUMBER_POPUP);
            SoundManager.Instance.PlayCountdownSound();
        }
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
