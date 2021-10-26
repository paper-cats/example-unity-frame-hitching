using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedExampleController : MonoBehaviour
{
    [SerializeField]
    private double _holdSeconds;

    [SerializeField]
    private RectTransform _graphic;

    [SerializeField]
    private TextMeshProUGUI _millisecondsLabel;

    private float? _holdStartTime;

    // Start is called before the first frame update
    void Start()
    {
        _millisecondsLabel.text = $"{(int)Math.Floor(_holdSeconds * 1000d)}ms";
    }

    // Update is called once per frame
    void Update()
    {
        if (_holdStartTime.HasValue)
        {
            if (Time.time - _holdStartTime < _holdSeconds)
                return;

            _holdStartTime = null;
        }

        var pivot = _graphic.pivot;
        var reverse = Mathf.FloorToInt(Time.time) % 2 == 0;
        if (reverse)
            pivot.x = Mathf.Lerp(0, 1, Time.time % 1);
        else
            pivot.x = Mathf.Lerp(1, 0, Time.time % 1);

        if (_graphic.pivot.x < 0.5 && pivot.x >= 0.5)
            _holdStartTime = Time.time;

        _graphic.pivot = pivot;
    }
}
