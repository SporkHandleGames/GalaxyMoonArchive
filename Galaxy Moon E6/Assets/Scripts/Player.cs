using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI healthText;

    private void Start()
    {
        UpdateText();
    }

    public void TakeDamage()
    {
        health -= 1;
        UpdateText();
    }

    public void UpdateText()
    {
        healthText.text = health.ToString();
    }
}
