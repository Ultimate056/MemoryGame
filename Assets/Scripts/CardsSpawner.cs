using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardsSpawner : MonoBehaviour
{
    private float _positionX;
    private float _positionY = 3.2f;
    [SerializeField] private PresetCards _presetCards = null;
    [SerializeField] private Card _cardPrefub = null;
    [SerializeField] private UnityEvent _startCollect = new UnityEvent();
    public static int AllPlayingCards;
    private bool BigCards;
    private void Start()
    {
        Spawn();
    }
    private void SetScaleCardToSmall(Card card)
    {
        card.transform.localScale = new Vector3(0.5f, 0.5f);
    }

    public void Spawn()
    {
        Transform localTransform = GetComponent<Transform>();
        Card card;
        Sprite backSprite = _presetCards.GetBackSprite();
        List<Sprite> playCardsSprites = _presetCards.GetPlayCardsSprites();
        AllPlayingCards = playCardsSprites.Count;
        BigCards = playCardsSprites.Count <= 9;
        _positionX = BigCards ? -6.5f : -5.7f;
        float positionX = _positionX;
        float OffsetX = BigCards ? 2.5f : 1.2f;
        float OffsetY = BigCards ? 3.5f : 1.5f;
        float RightPositionX = BigCards ? 6.0f : 5.7f;
        for (int i = 0; i < 2; i++) // 2 пары
        {
            int[] playCardsIndex = _presetCards.GetCardIndex();
            for(int j = 0; j < playCardsIndex.Length; j++)
            {
                if (positionX > RightPositionX)
                {
                    _positionY -= OffsetY;
                    positionX = _positionX;
                }
                card = Instantiate(_cardPrefub) as Card;
                if (!BigCards)
                    SetScaleCardToSmall(card);
                card.transform.position = new Vector3(positionX, _positionY);
                card.CardsSetting(backSprite, playCardsSprites[playCardsIndex[j]], playCardsIndex[j]);
                positionX += OffsetX;
            }
        }
        _startCollect.Invoke();
    }
}
