public interface IWeapon
{
    public string Name { get; }
    public float Damage { get; }
    public float FireRate { get; }
    public float BulletSpeed { get; }
    public int BulletsPerShoot { get; }
}
