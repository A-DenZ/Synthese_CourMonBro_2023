using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IntroSceneController : MonoBehaviour
{
    // Référence vers le contrôleur spécifique de mouvement (par exemple, XRController pour SteamVR)
    private XRController xrController;

    private void Start()
    {
        // Assurez-vous que vous avez correctement assigné le script XRController dans l'éditeur Unity
        xrController = GetComponent<XRController>();

        // Désactiver le déplacement au démarrage
        DisableMovement();
    }

    private void DisableMovement()
    {
        if (xrController)
        {
            // Désactiver le composant de mouvement spécifique (par exemple, le script de déplacement)
            xrController.enabled = false;
        }
    }

    // Appelez cette méthode lorsque la scène d'introduction est terminée
    public void EnableMovement()
    {
        if (xrController)
        {
            // Réactiver le composant de mouvement spécifique lorsque la scène d'introduction est terminée
            xrController.enabled = true;
        }
    }
}
