using UnityEngine;
using Unity.XR.CoreUtils;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(XROrigin))]
public class MantenerColisiones : MonoBehaviour
{
    private CharacterController controller;
    private Transform cameraTransform;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        XROrigin xrOrigin = GetComponent<XROrigin>();
        if (xrOrigin != null && xrOrigin.Camera != null)
        {
            cameraTransform = xrOrigin.Camera.transform;
        }
    }

    void Update()
    {
        if (controller != null && cameraTransform != null)
        {
            // Ajusta el centro de la cápsula a la posición de la cabeza en X y Z
            controller.center = new Vector3(cameraTransform.localPosition.x, controller.center.y, cameraTransform.localPosition.z);
            // Fuerza la actualización de la física para detectar colisiones
            controller.SimpleMove(Vector3.zero);
        }
    }
}