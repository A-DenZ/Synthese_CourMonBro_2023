using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IntroSceneController : MonoBehaviour
{
    // R�f�rence vers le contr�leur sp�cifique de mouvement (par exemple, XRController pour SteamVR)
    private XRController xrController;

    private void Start()
    {
        // Assurez-vous que vous avez correctement assign� le script XRController dans l'�diteur Unity
        xrController = GetComponent<XRController>();

        // D�sactiver le d�placement au d�marrage
        DisableMovement();
    }

    private void DisableMovement()
    {
        if (xrController)
        {
            // D�sactiver le composant de mouvement sp�cifique (par exemple, le script de d�placement)
            xrController.enabled = false;
        }
    }

    // Appelez cette m�thode lorsque la sc�ne d'introduction est termin�e
    public void EnableMovement()
    {
        if (xrController)
        {
            // R�activer le composant de mouvement sp�cifique lorsque la sc�ne d'introduction est termin�e
            xrController.enabled = true;
        }
    }
}
