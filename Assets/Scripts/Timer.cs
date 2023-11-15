using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _timerText;

    private float _updateFrequency = 1f;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        DisableTimer();
        
        _coroutine = StartCoroutine(DisplayTime());
    }

    private void OnDisable()
    {
        DisableTimer();
    }

    private void DisableTimer()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator DisplayTime()
    {
        while(gameObject.activeSelf == true)
        {
            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("dd.MM.yyyy\nHH:mm:ss");
        
            _timerText.text = formattedDateTime;
            yield return new WaitForSeconds(_updateFrequency);
        }
    }
}