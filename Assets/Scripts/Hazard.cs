using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    //private void Start()
    //{
    //    var playerController = GetComponent<PlayerController>();
    //}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        playerController.TakeDamage(20);
    }
}
