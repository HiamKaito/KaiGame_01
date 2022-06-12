using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_GameOver : MonoBehaviour
{
    [SerializeField] private Image _whiteImage, _blackImage;
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private float faceDilate = -1.0f;
    [SerializeField] private byte _A;

    [SerializeField] private Text _textContinues;

    private void Start()
    {
        _textMesh.text += GameManagement.instants.DeadCount;
        StartCoroutine(ImageWhiteFade());
    }

    IEnumerator ImageWhiteFade()
    {
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Start coroutine");

        while (_A <= 170)
        {
            _A += 3;
            _whiteImage.color = new Color32(102, 102, 102, _A);
            yield return new WaitForSeconds(0.01f);
        }

        _A = 0;
        StartCoroutine(ImageBlackFade());
    }

    IEnumerator ImageBlackFade()
    {
        while (_A <= 170)
        {
            _A += 2;
            _blackImage.color = new Color32(0, 0, 0, _A);
            yield return new WaitForSeconds(0.01f);
        }

        StartCoroutine(TextFade());
    }

    IEnumerator TextFade()
    {
        while (faceDilate <= 0)
        {
            faceDilate += 0.01f;
            _textMesh.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, faceDilate);
            yield return new WaitForSeconds(0.03f);
        }

        _A = 0;
        StartCoroutine(TextContinues_Inc());
        StartCoroutine(GameManagement.instants.Restart());
    }

    IEnumerator TextContinues_Inc()
    {
        while (_A <= 220)
        {
            _A += 2;
            _textContinues.color = new Color32(220, 220, 220, _A);
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(TextContinues_Des());
    }
    IEnumerator TextContinues_Des()
    {
        while (_A >= 120)
        {
            _A -= 3;
            _textContinues.color = new Color32(220, 220, 220, _A);
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(TextContinues_Inc());
    }
}
