using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ChangeColorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color originalColor;
    [SerializeField] private Color hoverColor;
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        originalColor = textMesh.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textMesh.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textMesh.color = originalColor;
    }
}

