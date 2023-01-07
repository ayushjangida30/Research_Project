using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageController : MonoBehaviour, IDragHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image image;

    private void Awake()    {
        rectTransform = GetComponent<RectTransform>();
        image.rectTransform.localScale = new Vector3(0.3f, 0.3f, 1);
    }

    public void Start() {
        Vector3 position = GetWorldPoint(rectTransform);
        GlobalProperties.Instance.Experiment.SetPosition(position);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 position = GetWorldPoint(rectTransform);
        GlobalProperties.Instance.Experiment.SetPosition(position);
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("Test");
    }

    public Vector3 GetWorldPoint(RectTransform rectTransform)  {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        LayerMask layerMask = LayerMask.GetMask("Terrain");

        if(Physics.Raycast(ray, out hit))   {
            print(hit.point);
            return hit.point;
        }

        return Vector3.zero;
    }

}
