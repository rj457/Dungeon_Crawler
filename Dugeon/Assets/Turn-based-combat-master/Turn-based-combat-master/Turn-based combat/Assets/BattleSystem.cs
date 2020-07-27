using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, ESCAPE}

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;
	public GameObject ShieldPrefab; 

	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	Unit playerUnit;
	Unit enemyUnit;

	public Text dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public Animator transition; 

	public BattleState state;

	public bool IsLost = false;
	//Access player health record; 
	public recordplayer recordplayer;
	bool isDead;
	public BattleResult BattleResult;
	public VectorValue VectorValue;

    // Start is called before the first frame update
    void Start()
    {
		state = BattleState.START;
		StartCoroutine(SetupBattle());
    }

	IEnumerator SetupBattle()
	{
		VectorValue.Isbattle = true; 
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		Instantiate(ShieldPrefab, new Vector3(-5.2F, -1, 0), Quaternion.identity);
		playerUnit = playerGO.GetComponent<Unit>();

		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();

		dialogueText.text = "A strong " + enemyUnit.unitName + " approaches...";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	{
		if (recordplayer.IsFollow == true)
			isDead = enemyUnit.TakeDamage(playerUnit.damage * 2);
		else
			isDead = enemyUnit.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);

		if(isDead)
		{
			state = BattleState.WON;
			EndBattle();
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{
		dialogueText.text = enemyUnit.unitName + " attacks!";

		yield return new WaitForSeconds(1f);

		if (recordplayer.IsShield == true)
		{
			isDead = playerUnit.TakeDamage(enemyUnit.damage/2);
		}
        else
        {
			isDead = playerUnit.TakeDamage(enemyUnit.damage);
		}
		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);

		if(isDead)
		{
			state = BattleState.LOST;
			EndBattle();
		} else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	void EndBattle()
	{
		if(state == BattleState.WON)
		{
			recordplayer.Iswin = true;
			BattleResult.IsPlayerWin = true; 
			dialogueText.text = "You won the battle!";
			if ((recordplayer.playerhealth += 10) >= 100)
            {
				recordplayer.playerhealth = 100; 
            }
            else
            {
				recordplayer.playerhealth += 10; 
            }
			StartCoroutine(PlayerEscape()); 
		} else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
			BattleResult.IsPlayerWin = false; 
			IsLost = true;
			recordplayer.playerhealth -= 20;
			recordplayer.IsLost = true; 
			StartCoroutine(PlayerEscape());
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";
	}

	IEnumerator PlayerHeal()
	{
		playerUnit.Heal(5);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "You feel renewed strength!";

		yield return new WaitForSeconds(2f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}

	public void OnEscapeButton()
	{

		if (state != BattleState.PLAYERTURN)
			return;
		BattleResult.IsPlayerWin = false; 
		StartCoroutine(PlayerEscape());
		recordplayer.playerhealth -= 10;
		recordplayer.Isescape = true;
	}

	IEnumerator PlayerEscape()
    {
		state = BattleState.ESCAPE;
		transition.SetTrigger("Start");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(1);
	}

}
