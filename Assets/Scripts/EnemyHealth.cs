using Managers;
using UI;
using UnityEngine;

public class EnemyHealth : EntityHealth
{
    private PopUpManager _popUpManager;
    private HealthBar _healthBarBase;
    public ExpOrb experienceOrb;

    private void Awake()
    {
        _popUpManager = FindObjectOfType<PopUpManager>();
        _healthBarBase = GetComponentInChildren<HealthBarBase>();
        _healthBarBase.SetMaxHealth(maxHealth);
    }

    public override void TakeDamage(int damageTaken)
    {
        _popUpManager.ShowDamagePopUp(damageTaken.ToString(), transform.position);
        base.TakeDamage(damageTaken);
        _healthBarBase.SetHealth(currentHealth);
    }

    public override void Die()
    {
        ExpOrb instantiatedObject = Instantiate(experienceOrb, transform.position, Quaternion.identity);
        instantiatedObject.SetWorth(maxHealth);
        Destroy(gameObject);
    }
}