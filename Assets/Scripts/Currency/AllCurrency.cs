using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCurrency : MonoBehaviour
{
    [SerializeField]
    private List<AountOfCurency> _allCurrency;

    public List<AountOfCurency> GetAllCurrency => _allCurrency;

}
