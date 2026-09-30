using UnityEngine;
using UnityEngine.UI;

public class HealthControler : MonoBehaviour
{
    public MovementController target;
    public Image[] hearts;
    
    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < target.health)
            {
                hearts[i].color = new Color(255,255,255,1);
            }
            else
            {
                hearts[i].color = new Color(0, 0, 0, 0.5f);
            }
        }
    }
}
