public sealed class Player : Component
{
	#region Vars/Props
	public static Player Instance { get; private set; }

	public int Frags { get; private set; } = 0;
	[Property] public int MaxFrags { get; private set; } = 100;

	[Property] private SceneFile SceneWin { get; set; }
	[Property] private SceneFile SceneFail { get; set; }
	#endregion

	#region Logic
	public void AddFrags(int count)
	{
		if (count <= 0) { Log.Error("count should be more than 0"); return; }

		Frags += count;
		Log.Info($"Frags: {Frags}");

		if (Frags >= MaxFrags)
			Win();
	}

	public void Win()
	{
		Log.Info("Win");

		Scene.Load(SceneWin);
	}

	public void Fail()
	{
		Log.Info("Fail");

		Scene.Load(SceneFail);
	}
	#endregion

	#region Component
	protected override void OnAwake()
	{
		Instance = this;
	}
	#endregion
}