using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;
    public GameObject camerFollow, spectatorCamera;

    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            IsDead();
            spectatorCamera.SetActive(true);
            camerFollow.SetActive(false);
        }
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

    void OnCollisionEnter(Collision other) 
    {
        TakeDamage(50);

        if(gameObject.CompareTag("Friend"))
        {
            TakeDamage(20);
        }
    }

    public bool IsDead()
    {
        CarDestroying();
        return true;
    }

    public void CarDestroying()
    {
        Destroy(gameObject);
    }
}