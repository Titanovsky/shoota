using System;

public sealed class Enemy : Component
{
	#region Vars/Props
	[Property] public float MoveSpeed { get; set; } = 1f;
	[Property] public PrefabScene ParticleForDie { get; set; }

	private static readonly float _radiansToDegrees = 360 / (MathF.PI * 2); // MathF.Rad2Deg
	private Vector3 _Direction { get; set; }
	#endregion

	#region Logic
	private float RadiansToDegrees(float radians)
	{
		return radians * _radiansToDegrees;
	}

	private float LookAt()
	{
		float targetAngleRadians = MathF.Atan2(_Direction.y, _Direction.x);
		float angle = RadiansToDegrees(targetAngleRadians);

		return angle;
	}

	public void RotateToTarget()
	{
		float angle = LookAt();

		Transform.Rotation = Rotation.FromYaw(angle);
	}

	public void MoveToTarget()
	{
		Transform.Position += _Direction * MoveSpeed;
	}

	public void Init()
	{
		_Direction = (Player.Instance.Transform.Position - Transform.Position).WithZ(0).Normal; //! Высота не должна изменяться
	}

	public void SpawnParticle()
	{
		ParticleForDie.Clone(Transform.Position);
	}
	#endregion

	#region Component 
	protected override void OnStart()
	{
		Init();
	}

	protected override void OnFixedUpdate()
	{
		RotateToTarget();
		MoveToTarget();
	}
	#endregion
}