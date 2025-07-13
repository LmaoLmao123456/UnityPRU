using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdl
    public string Tenmanchoi;
    public void LoandmanchoiMoi()
    {
        SceneManager.LoadScene(Tenmanchoi);

    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManger.hasKey)
        {
            LoandmanchoiMoi();
        }
    }

}
