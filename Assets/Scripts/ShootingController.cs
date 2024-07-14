using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private WeaponBase pistol_data, shotgun_data;
    [SerializeField] private UnityEvent onShoot;
    [SerializeField] private Bullet bullet_prefab;
    [SerializeField] private Transform origin_shoots;
    [SerializeField] private Bullets_Positions[] bullets_Positions;



    private WeaponBase current_weapon;
    private bool can_shoot = true;

    private float nextFire = 0.0f;




    private void Awake()
    {
        current_weapon = pistol_data;
    }

    public void ActionListenner(InputAction action_player)
    {

        switch (action_player)
        {
            case InputAction.Pistol:
                current_weapon = pistol_data;
                break;
            case InputAction.Shotgun:
                current_weapon = shotgun_data;
                break;
            case InputAction.Shoot:
                PerformShoot();
                break;
        }
    }


    private async void PerformShoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + current_weapon.FireRate;
            onShoot?.Invoke();

            foreach (var item in GetBulletsPositionsWithTwoBullets(current_weapon.BulletsPerShoot).Bullets_Position)
            {
                //Bullet bullet = Instantiate(bullet_prefab, item.position, Quaternion.identity);
                Bullet bullet = PoolManager.Instance.GetBullet();
                if (bullet != null)
                {
                    bullet.transform.position = item.position;
                    bullet.transform.rotation = this.transform.rotation;
                    bullet.Damage = current_weapon.Damage;
                    bullet.GetComponent<Rigidbody2D>().velocity = item.right * current_weapon.BulletSpeed;

                }
            }


        }


    }

    private Bullets_Positions GetBulletsPositionsWithTwoBullets(int amount_bullets)
    {
        return bullets_Positions.FirstOrDefault(bp => bp.Amount_Bullets == amount_bullets);
    }

}

[Serializable]
public class Bullets_Positions
{
    public int Amount_Bullets;
    public Transform[] Bullets_Position;
}
