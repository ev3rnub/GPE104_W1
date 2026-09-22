//Course: GPE104 
//Prof: Matthew Henry 
//Proj: Project 2 Milestone 2 - Move it, Trooper
//Student: Chad V

using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int minHealth = 0;
    public int currHealth;
    public Death death;


    // init: init currHealth to maxHealth and grab a reference to the Component Death. 
    void Start()
    {
        currHealth = maxHealth;
        death = GetComponent<Death>();
        if (death != null)
        {
            Debug.Log($"{death}");
        }
    }

    // Subtract health, if at or below 0, die.
    public void SubHealth(int someDmg)
    {
        int someCurrHealth = currHealth - someDmg;
        if (someCurrHealth >= 0)
        {
            currHealth = someCurrHealth;
        }
        else if (someCurrHealth <= 0 && death != null)
        {
            InstantDeath();
        }
    }

    // Add health, if above maxhealth, reduce to maxhealth. 
    public void AddHealth(int someHealth)
    {
        int someCurrHealth = currHealth + someHealth;
        if (someCurrHealth <= maxHealth)
        {
            currHealth = someCurrHealth;
        }
        else
        {
            currHealth = maxHealth;
        }
    }

    // Instant death
    public void InstantDeath()
    {
        currHealth = 0;
        death.Die();
    }


    // instant heal
    public void InstantHeal()
    {
        currHealth = maxHealth;
    }
}
