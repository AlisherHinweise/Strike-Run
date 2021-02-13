using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Tutorial _tutorial;

    private void Start()
    {
        _tutorial = FindObjectOfType<Tutorial>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _tutorial.gameObject.SetActive(false);
        }
    }
}
