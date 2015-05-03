using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class BattleSceneController : SceneController
{

	private void Start()
	{
		GetComponent<BattleController>().StartBattle();
	}

	public override void OnEnable()
	{
		BattleController.OnBattleEvent += HandleBattleEvent;
	}

	public override void OnDisable()
	{
		BattleController.OnBattleEvent -= HandleBattleEvent;
	}

	public void HandleBattleEvent(BattleEvent type)
	{
		if (type == BattleEvent.Started) {
			OnBattleStarted();
		} else if (type == BattleEvent.TurnChange) {
			OnTurnChanged();
		} else if (type == BattleEvent.Finished) {
			OnBattleFinished();
		}
	}

	public virtual void OnBattleStarted()
	{
		
	}

	public virtual void OnTurnChanged()
	{
		
	}

	public virtual void OnBattleFinished()
	{
		
	}

	public abstract void Pause();

	public abstract void Unpause();

}
