
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 checkPos;
    public GameObject player;


    private void OnTriggerEnter(Collider other){

        if(other.gameObject.tag == "Player"){
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = checkPos;
            player.GetComponent<CharacterController>().enabled = true;
        }
    }



}
