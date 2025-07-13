using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] private GameManger gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            Player player = GetComponent<Player>();
            player.TakeDamage(10f);
        }
        else if (collision.CompareTag("Energy"))
        {
            gameManager.AddEnergy();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Key"))
        {
           
            Destroy(collision.gameObject);
            GameManger.hasKey = true;
            gameManager.continueLevel();
        }

    }


}
