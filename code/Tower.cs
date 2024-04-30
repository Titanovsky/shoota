public sealed class Tower : Component
{
	#region Vars/Props
	[Property] public PrefabScene Projectile { get; set; }
	[Property] public GameObject PlaceOutputProjectile { get; set; }
	[Property] public float DelayShoot { get; set; } = .45f;
	private TimeUntil _TimerDelayShoot { get; set; }

	[Property] public float MoveSpeedRotation { get; set; } = .2f;
	#endregion

	#region Logic
	public void Shoot()
	{
		Vector3 pos = PlaceOutputProjectile.Transform.Position;
		Rotation rot = Rotation.FromYaw(Transform.Rotation.Yaw());
		Projectile.Clone(pos, rot); // аналог Instantiate

		Log.Info("Shoot");

		_TimerDelayShoot = DelayShoot;
	}
	
	public void Init()
	{
		_TimerDelayShoot = DelayShoot;
	}

	private void Move()
	{
		Transform.Rotation *= Rotation.FromYaw(-Input.MouseDelta.x * MoveSpeedRotation);
	}

	private void CheckInputShoot()
	{
		if (Input.Down("attack1") && _TimerDelayShoot)
			Shoot();
	}
	#endregion

	#region Component
	protected override void OnStart()
	{
		Init();
	}

	protected override void OnUpdate()
	{
		CheckInputShoot();
		Move();
	}
	#endregion
}