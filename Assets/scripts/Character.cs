using UnityEngine;
using System.Collections;

public enum characterType{none, player, enemy, npc};

[System.Serializable]
public class Defence{
	
	public float weaponDefence = 1f;
	public float magicDefence = 0f;
}
[System.Serializable]
public class Maxs {
	public float maxHealth = 100f;
	public float maxMana = 100f;

}
public class Character : MonoBehaviour {

	public float health = 100f;
	public float mana = 100f;
	public float damage = 0f;
	
	public Defence defence;

	public characterType type;
	public GameObject character;

	public Maxs maxs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
