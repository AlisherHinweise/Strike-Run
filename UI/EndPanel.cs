using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private Text _rewardPanel;
    [SerializeField] private Text _mainPanel;

    private Count _counter;
    [SerializeField] private CoinCounter _coinCounter;

    private float _enlargeSpeed = 0.15f;
    private int _reward;
    private Vector3 _newScale = new Vector3(1, 1, 1);

    void Awake()
    {
        gameObject.SetActive(false);
        _counter = FindObjectOfType<Count>();
    }

    public void EnableFinishPanel() 
    {
        //_coinCounter.gameObject.SetActive(true);
        gameObject.SetActive(true);
        StartCoroutine(routine: SetPanelScale());
        _reward = _counter.coins;
        _rewardPanel.text = _reward.ToString();
        _mainPanel.text = "LEVEL CLEARED!";
    }

    public void EnableDeafeatPanel()
    {
        //_coinCounter.gameObject.SetActive(true);
        gameObject.SetActive(true);
        StartCoroutine(routine: SetPanelScale());
        _reward = _counter.coins;
        _rewardPanel.text = _reward.ToString();
        _mainPanel.text = "YOU LOSE!";
    }

    private IEnumerator SetPanelScale()
    {
        while (transform.localScale != _newScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _newScale, _enlargeSpeed);
            yield return null;
        }
    }
}
