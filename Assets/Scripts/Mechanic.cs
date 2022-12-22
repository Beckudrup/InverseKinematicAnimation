using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnitySceneManagement;


public class Mechanic : MonoBehaviour
{
public float score=0;


private void Update(){
    score+=Time.deltaTime;
    Debug.Log("Your score is:"+(int)score);

 
}



private void OnTriggerEnter2D(Collider2D collision){

score=0;
Debug.Log("Hit");
//collision.gameObject.SetActive(false);
this.gameObject.SetActive(false);

}

}





