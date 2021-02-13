using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{ 
    [SerializeField] private Image _progressBar;
    [SerializeField] private Image _nextLevel;
    private Color _color;
    private UIController _uiController;
    private GameObject[] _enemies;

    private int _deadEnemy = 0;
    private double _onEnemyDeathFill;
    public double targetProgress = 0;
    private float _fillSpeed = 0.4f;

    // Start is called before the first frame update

    private void Start()
    {
        _color = _nextLevel.color;
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        _onEnemyDeathFill = 1.0f / _enemies.Length;
    }

    // Update is called once per frame
    private void Update()
    {
        if(_progressBar.fillAmount < targetProgress)
        {
            _progressBar.fillAmount += _fillSpeed * Time.deltaTime;
        }
    }

    public void FillLevelIcon()
    {
        if (_progressBar.fillAmount == 1)
        {
            _color.a = 1.0f;
            _nextLevel.color = _color;
        }
    }

    public void EnemyCounter()
    {
        _deadEnemy += 1;
        IncrementProgress(_deadEnemy);
    }

    public void IncrementProgress(int newProgress)
    {
        targetProgress = newProgress * _onEnemyDeathFill;
    }
}