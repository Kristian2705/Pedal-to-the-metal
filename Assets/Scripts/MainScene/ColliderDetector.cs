using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    public IntEvent OnObstacleHit;
    public IntEvent OnBarrelHit;
    
    void OnCollisionEnter(Collision collision)
    {
        if (Player.IsAlive && collision.gameObject.tag == "Obstacle")
        {
            OnObstacleHit.Invoke(collision.gameObject.GetComponent<Obstacle>().Damage);
        }
        if(Player.IsAlive && collision.gameObject.name.Contains("Barrel"))
        {
            OnBarrelHit.Invoke(collision.gameObject.GetComponent<Obstacle>().Damage);
        }
        //if(Player.IsAlive && collision.gameObject.name.Contains("Barrier") && 
        //    collision.gameObject.name.Contains("Cone") &&
        //    collision.gameObject.name.Contains("Crate") &&
        //    collision.gameObject.name.Contains("Rock") &&
        //    collision.gameObject.name.Contains("Spool"))
        //{
        //    OnOtherObstaclesHit.Invoke(collision.gameObject.GetComponent<Obstacle>().Damage);
        //}
    }
}
