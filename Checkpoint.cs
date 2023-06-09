using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public DeathWall deathWall;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag =="Player"){
            deathWall.checkPos = other.transform.position;
        }
    }


}
