using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoldingOnPointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI _tmpText;
    [SerializeField] private GameObject _icon;
    [SerializeField] private GameObject _icon1;


    void Start()
    {
        _tmpText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer entered");
        _tmpText.fontStyle = FontStyles.Bold;
        _icon.SetActive(true);
        _icon1.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer exited");

        _tmpText.fontStyle = FontStyles.Normal;
        _icon.SetActive(false);
        _icon1.SetActive(false);

    }


}
