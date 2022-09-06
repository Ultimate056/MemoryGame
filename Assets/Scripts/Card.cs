using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Card : MonoBehaviour
{
    public int Index { get; private set; }

    private SpriteRenderer _spriteRenderer;
    private Sprite _backSprite;
    private Sprite _frontSprite;
    private Animation _animation;
    private bool _isBackSide = true;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    private CardCollector _cardCollector;
    [SerializeField] private AudioSource aud = null;
    public AudioClip CoupCard;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animation = GetComponent<Animation>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        CheckTime();
    }

    public void CheckTime()
    {
        if (Timer.GameOn == false)
            _boxCollider2D.enabled = false;
        else
            _boxCollider2D.enabled = true;
    }

    private void OnMouseDown()
    {
        if(_cardCollector.TwoCardsClosed())
        {
            _boxCollider2D.enabled = false;
            CardAnimation();
            _cardCollector.OpenCard(this);
        }
    }

    public void EnableCollider()
    {
        _boxCollider2D.enabled = true;
    }

    public void OffCollider()
    {
        _boxCollider2D.enabled = false;
    }

    private void ChangeSpriteCard()
    {
        _spriteRenderer.sprite = _isBackSide == true ? _backSprite : _frontSprite;
    }

    public void CardAnimation()
    {
        _isBackSide = !_isBackSide;
        _animation.Play(_isBackSide == true ? "ToBack" : "ToFront");
        aud.PlayOneShot(CoupCard);
    }

    public void CardsSetting(Sprite back, Sprite front ,int index)
    {
        _spriteRenderer.sprite = _backSprite = back;
        _frontSprite = front;
        Index = index;
    }

    public void SetCardCollector(CardCollector cardCollector)
    {
        _cardCollector = cardCollector;
    }
}
