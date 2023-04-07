
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    private BaseCharacter _caster;
    [SerializeField] private List<BaseSpell> spells;
    [SerializeField] private int spellIndex;

    private void Awake()
    {
        _caster = GetComponent<BaseCharacter>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            spells[spellIndex].Cast(_caster);
        }
    }
}
