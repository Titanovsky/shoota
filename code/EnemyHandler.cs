using System;

public sealed class EnemyHandler : Component
{
	#region Vars/Props
	[Property] public PrefabScene EnemyPrefab { get; set; }
	[Property, Range(0.25f, 5f)] public float MaxRandomDelaySpawn { get; set; } = 2f;
	[Property] public List<GameObject> SpawnPoints { get; set; } = new List<GameObject>();
    private TimeUntil _TimerDelaySpawn { get; set; } = 0.25f;

    private Random _random = new();
    #endregion

    #region Logic
    public void SpawnEnemy()
    {
        var randomIndex = _random.Int(SpawnPoints.Count - 1);
        var randomGameObjectPlace = SpawnPoints[randomIndex];

        var obj = EnemyPrefab.Clone(randomGameObjectPlace.Transform.Position);

        //? Может ещё что-то сделать с объектом?
	}

    public void AutoSpawnEnemy()
    {
        if (!_TimerDelaySpawn) return;

        float randomDelay = new RangedFloat(0.25f, MaxRandomDelaySpawn).GetValue();
        _TimerDelaySpawn = randomDelay;

        SpawnEnemy();
	}
	#endregion

	#region Component
	protected override void OnUpdate()
	{
        AutoSpawnEnemy();
	}
	#endregion
}