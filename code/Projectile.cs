public sealed class Projectile : Component, Component.ITriggerListener
{
	#region Vars/Props
	[Property] public float DelayForDie { get; set; } = 1f; // через это Свойство назначем время для таймера
	private TimeUntil _TimerDelayForDie { get; set; } // TimeUntil сахар для отсчёта/задержек

	[Property] public float MoveSpeed { get; set; } = 1.2f;
	#endregion

	#region Logic
	private void Move()
	{
		Transform.Position += Transform.World.Forward * MoveSpeed;
	}

	private void CheckToDie()
	{
		if (_TimerDelayForDie)
			GameObject.Destroy();
	}

	private void Init()
	{
		_TimerDelayForDie = DelayForDie;
	}
	#endregion

	#region Component
	protected override void OnStart()
	{
		Init();
	}

	protected override void OnFixedUpdate()
	{
		Move();
		CheckToDie();
	}
	#endregion

	#region ITriggerListener
	public void OnTriggerEnter(Collider other)
	{
		if (other.GameObject.Tags.Has("enemy"))
		{
			var obj = other.GameObject;
			obj.Components.Get<Enemy>().SpawnParticle();

			obj.Destroy();
			GameObject.Destroy();

			Player.Instance.AddFrags(1);
		}
	}
	#endregion
}