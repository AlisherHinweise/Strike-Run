using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPlatform : MonoBehaviour
{
    private EndPanel _endPanel;
    private ProgressBar _progressBar;

    private void Awake()
    {
        _endPanel = FindObjectOfType<EndPanel>();
        _progressBar = FindObjectOfType<ProgressBar>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11 && _progressBar.targetProgress == 1)
        {
            _progressBar.FillLevelIcon();   
            _endPanel.EnableFinishPanel();
        }
    }
}
