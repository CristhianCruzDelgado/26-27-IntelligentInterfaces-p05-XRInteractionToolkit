using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class XRDebugLogger : MonoBehaviour
{
    private XRGrabInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(OnSelect);
        interactable.hoverEntered.AddListener(OnHover);
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnSelect);
        interactable.hoverEntered.RemoveListener(OnHover);
    }

    private void OnHover(HoverEnterEventArgs args)
    {
        Debug.Log("<color=yellow>[XRI Debug] El mando está APUNTANDO/TOCANDO este objeto.</color>");
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
        Debug.Log("<color=green>[XRI Debug] Objeto SELECCIONADO/AGARRADO correctamente.</color>");
    }
}