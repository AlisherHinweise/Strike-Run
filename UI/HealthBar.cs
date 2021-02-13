using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _hpText;
    //[SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;

    private void Start()
    {
        //_fill.color = _gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        _slider.value = health;
        _hpText.text = health.ToString();
        //_fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}
