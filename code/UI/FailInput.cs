public sealed class FailInput : Component
{
	#region Vars/Props
	[Property] public SceneFile level; //
	#endregion

	#region Logic
	public void Restart()
	{
		Scene.Load(level);
	}

	private void CheckForRestart()
	{
		if (Input.Pressed("jump"))
			Restart();
	}
	#endregion

	#region Component
	protected override void OnUpdate()
	{
		CheckForRestart();
	}
	#endregion
}