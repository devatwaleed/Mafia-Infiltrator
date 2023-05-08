using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cctvcolliderscript : MonoBehaviour
{
    private bool isPlayerDetected = false;
    void Update(){
        if(isPlayerDetected){
            Debug.Log("Teri mkc");
        }else{
            Debug.Log("Not detected");
        }
    }
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerDetected = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerDetected = false;
        }
    }
}
