using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _FPSText;
    [SerializeField]
    private TextMeshProUGUI _MEMText;

    private float _RefreshRate = 1.0f;
    private float _Timer = 1.0f;

    void Update()
    {
        if (Time.unscaledTime > _Timer)
        {
            _FPSText.text = ((int) (1 / Time.unscaledDeltaTime)).ToString();
            _Timer = Time.unscaledTime + _RefreshRate;
        }

    }
}
