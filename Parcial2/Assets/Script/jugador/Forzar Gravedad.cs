using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ForzarGravedad : MonoBehaviour
{
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Si no estamos en el suelo, forzamos una actualización de la física
        // con un movimiento nulo para que la gravedad actúe.
        if (characterController != null && !characterController.isGrounded)
        {
            characterController.SimpleMove(Vector3.zero);
        }
    }
}