using UnityEngine;
using UnityEngine.SceneManagement;

public class BitisCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyunu durdurur ve direkt olarak kapatır
            SceneManager.LoadScene(2);
            
            Debug.Log("Oyun bitti!");
        }
    }
}
