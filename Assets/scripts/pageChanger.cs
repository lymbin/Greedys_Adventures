using UnityEngine;
using System.Collections;

public class pageChange1r : MonoBehaviour {

	public static void ChangePage1(GameObject currentPage, GameObject nextPage){
		currentPage.SetActive(false);
		nextPage.SetActive(true);
	}
}
