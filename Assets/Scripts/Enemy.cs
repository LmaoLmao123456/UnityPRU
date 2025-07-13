using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float enemyMoveSpeed = 4f;
    protected Player player;

    [SerializeField] protected float detectionRange = 5f;
    protected bool isPlayerInRange = false;

    [SerializeField] protected float maxHp = 50f;
    protected float currentHp;
    [SerializeField] private Image hpBar;

    [SerializeField] protected float enterDamage = 10f; // touching damage
    [SerializeField] protected float stayDamage = 10f;  // countinued damage
    protected virtual void Start()
    {
        player = FindAnyObjectByType<Player>();
        currentHp = maxHp;
        UpdateHpBar();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        isPlayerInRange = distanceToPlayer <= detectionRange;

        if (ShouldChasePlayer())
        {
            MoveToPlayer();
        }
    }

    protected virtual bool ShouldChasePlayer()
    {
        return isPlayerInRange;
    }


    protected void MoveToPlayer()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMoveSpeed * enemyMoveSpeed);
            FlipEnemy();
        }
    }

    protected void FlipEnemy()
    {
        if (player != null)
        {
            transform.localScale = new Vector3(player.transform.position.x < transform.position.x? -1 : 1,1,1);
        }
    }

    public virtual void TakeDamage(float damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Max(currentHp, 0);
        UpdateHpBar();
        if (currentHp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected void UpdateHpBar ()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = currentHp / maxHp;
        }
    }
}
