using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CardCollector : MonoBehaviour
{
    private Card _firstCard;
    private Card _secondCard;

    public AudioSource aud;
    public AudioClip stukFx;

    public void Start()
    {
        FindCards();
    }

    public void FindCards()
    {
        Card[] cards = FindObjectsOfType<Card>();
        for(int i = 0; i < cards.Length; i++)
        {
            cards[i].SetCardCollector(this);
        }
    }

    public void OpenCard(Card card)
    {
        if(_firstCard == null)
        {
            _firstCard = card;
        }
        else
        {
            _secondCard = card;
        }
        if(_secondCard != null)
        {
            if (_firstCard.transform.position.x == _secondCard.transform.position.x &&
                _firstCard.transform.position.y == _secondCard.transform.position.y)
            {
                _secondCard = null;
                _firstCard = null;
                _firstCard.CardAnimation();
            }
        }
        if(_firstCard !=null && _secondCard !=null)
        {
            Invoke(nameof(CompareCards), 0.6f);
        }
    }

    private void CompareCards()
    {
        if (_firstCard.Index == _secondCard.Index)
        {
            Destroy(_firstCard.gameObject);
            Destroy(_secondCard.gameObject);
            aud.PlayOneShot(stukFx);
            CardsSpawner.AllPlayingCards--;
        }
        else
        {
            _firstCard.CardAnimation();
            _secondCard.CardAnimation();
        }
        _firstCard = null;
        _secondCard = null;
    }


    public bool TwoCardsClosed()
    {
        return _secondCard == null;
    }
}
