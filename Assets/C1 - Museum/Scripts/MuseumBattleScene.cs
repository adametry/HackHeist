using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MuseumBattleScene : BattleSceneController
{

	public BattleController battle;

	public void Start()
	{
		battle = gameObject.GetComponentInParent<BattleController>();
	}

	public override void OnBattleStarted()
	{
		
	}
	
	public override void OnTurnChanged()
	{
		
	}
	
	public override void OnBattleFinished()
	{
		battle.PauseBattle();
		GotoEpilogue();
	}

	public override void Pause()
	{
		battle.PauseBattle();
	}
	
	public override void Unpause()
	{
		battle.ResumeBattle();
	}

	public void GotoEpilogue()
	{
		GotoScene("Epilogue");
	}

	public void GameOver()
	{
		GotoScene("GameOver");
	}

}
