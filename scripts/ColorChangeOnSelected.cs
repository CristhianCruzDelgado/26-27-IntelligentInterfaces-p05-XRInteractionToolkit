using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ColorChangeOnSelect : MonoBehaviour
{    
    private XRGrabInteractable interactable;
    private Renderer objectRenderer;
    private Color originalColor;
    public Color selectedColor = Color.green;

    void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }
    }

    void OnEnable()
    {
        interactable.selectEntered.AddListener(OnSelectEntered);
        interactable.selectExited.AddListener(OnSelectExited);
    }

    void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnSelectEntered);
        interactable.selectExited.RemoveListener(OnSelectExited);
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = selectedColor;
        }
    }

    void OnSelectExited(SelectExitEventArgs args)
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor;
        }
    }
}
