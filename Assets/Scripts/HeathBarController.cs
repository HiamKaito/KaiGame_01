using UnityEngine;
using UnityEngine.UI;

public class HeathBarController : MonoBehaviour
{
    [Header("Make health bar for entity")]
    [SerializeField] private Slider _slider;
    [SerializeField] private Color _low;
    [SerializeField] private Color _high;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private CanvasGroup canvasG;

    /// <summary>Set heal bar for display entity's Heath.</summary>
    /// <param name="health"> description </param>
    public void SetHealthBar(float hitPoint, float maxHitPoint)
    {
        // only true or false
        _slider.gameObject.SetActive(hitPoint < maxHitPoint);
        _slider.value = hitPoint;
        _slider.maxValue = maxHitPoint;
        _slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(_low, _high, _slider.normalizedValue);
    }
    private void Update()
    {
        // make HeathBar/Slider move with parant position
        _slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + _offset);
    }
    public void setCanvasGroupAlpha(float value)
    {
        canvasG.alpha = value;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}