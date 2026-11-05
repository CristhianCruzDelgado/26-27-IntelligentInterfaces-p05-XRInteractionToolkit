using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class UIUpdateOnGrab : MonoBehaviour
{
    private XRGrabInteractable interactable;
    private Text statusText;
    private string grabMessage = "Asset Store Object: Grabbed!";
    private string releaseMessage = "Asset Store Object: Released";

    void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
    }

    void Start()
    {
        GameObject textObject = GameObject.FindGameObjectWithTag("Text");
        if (textObject != null)
        {
            statusText = textObject.GetComponent<Text>();
        }        
    }

    void OnEnable()
    {
        interactable.selectEntered.AddListener(OnGrab);
        interactable.selectExited.AddListener(OnRelease);
    }

    void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnGrab);
        interactable.selectExited.RemoveListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        if (statusText != null)
        {
            statusText.text = grabMessage;
        }
    }

    void OnRelease(SelectExitEventArgs args)
    {
        if (statusText != null)
        {
            statusText.text = releaseMessage;
        }
    }
}
