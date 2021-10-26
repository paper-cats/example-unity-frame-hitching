using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    [SerializeField]
    private int _targetFrameRate = 100;

    [SerializeField]
    private TextMeshProUGUI _fpsLabel;

    private void Awake()
    {
        Application.targetFrameRate = _targetFrameRate;
    }

    // Update is called once per frame
    void Update()
    {
        _fpsLabel.text = $"FPS: {1.0f / Time.deltaTime}";
    }
}
