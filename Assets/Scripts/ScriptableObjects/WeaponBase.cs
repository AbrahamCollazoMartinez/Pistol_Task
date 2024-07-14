using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/MyWeapon")]
public class WeaponBase : ScriptableObject, IWeapon
{
    [SerializeField] private string name;
    [SerializeField] private float damage;
    [SerializeField] private float fireRate;
    [SerializeField] private float bulletSpeed;
    [Range(0, 5)]
    [SerializeField] private int bulletsPerShoot;




    public string Name { get => name; }
    public float Damage { get => damage; }
    public float FireRate { get => fireRate; }
    public float BulletSpeed { get => bulletSpeed; }
    public int BulletsPerShoot { get => bulletsPerShoot; }
}


