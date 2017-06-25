using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private float health;
    public Text healthText;

	// Use this for initialization
	void Start () {
        health = 100f;
        healthText = GameObject.Find("PlayerHealthText").GetComponent<Text>();


        //Initialize the text
        SetText(healthText, health, "Health: ");
    }
    
    
    private void SetText(Text textBox, float value, string preText)
    {
        int i = (int)value;
        textBox.text = preText + i.ToString();
    }

	public float GetHealth()
    {
        return health;
    }

    public void PlayerDamage(float damage)
    {
        health -= damage;
        SetText(healthText, health, "Health: ");
    }
}
