using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject popupPanel;

    private void Start()
    {
        popupPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            popupPanel.SetActive(true);
        }
    }

    public void ClosePopup()
    {
        popupPanel.SetActive(false);
        // Add code here to check if the math puzzle is correct
        // If the puzzle is correct, open the door
    }
}
