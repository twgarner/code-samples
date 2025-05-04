using UnityEngine;
using UnityEngine.UIElements;

public class MobileShockwaveUIController : MonoBehaviour
{
    private Button shockwaveBtn;
    private CharacterShockwave _shockwave;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        shockwaveBtn = root.Q<Button>("shockwaveBtn");
        shockwaveBtn.clicked += OnShockwaveClicked;

        // Find the player with the ability
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _shockwave = player.GetComponent<CharacterShockwave>();
        }
    }

    private void OnShockwaveClicked()
    {
        if (_shockwave != null)
        {
            _shockwave.MobileTrigger(); // Triggers shockwave with cooldown
        }
    }
}
