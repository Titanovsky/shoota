public sealed class TriggerPlayerFail : Component, Component.ITriggerListener
{
	#region ITriggerListener
	public void OnTriggerEnter(Collider other)
	{
		if (other.GameObject.Tags.Has("enemy"))
			Player.Instance.Fail();
	}
	#endregion
}