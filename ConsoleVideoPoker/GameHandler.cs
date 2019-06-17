using Core.Domain.Models;
using Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleUI.Drawers;

namespace ConsoleVideoPoker
{
    public class GameHandler
    {

        private readonly IDeckBuilder _deckBuilder;
        private readonly IHandEvaluator _handEvaluator;
        private readonly VideoPokerPainter _painter;
        private bool _shouldDeal;
        private bool _show; 
        private bool _run;
        private List<Card> _deck;
        private List<Card> _currentSelection;
        private Hand _currentHand;
        private int _coins;

        public GameHandler(IDeckBuilder deckBuilder, IHandEvaluator handEvaluator, VideoPokerPainter painter)
        {
            _deckBuilder = deckBuilder;
            _handEvaluator = handEvaluator;
            _painter = painter;
            _run = true;
            _shouldDeal = true;
            _show = false;
            _coins = 1;

            _deck = _deckBuilder.BuildDeck();
            _currentSelection = _deck.Take(5).ToList();
            _deck.RemoveRange(0, 5);
            _currentHand = UpdateCurrentHand();
        }

        public bool Run()
        {
            _painter.Paint(_currentHand, _shouldDeal, _show, _coins);
            return _run;
        }

        public void OnKeyPressed(object source, ConsoleKeyEventArgs args)
        {
            if (args.Key == ConsoleKey.Escape)
                _run = false;

            if (_coins == 0 && args.Key == ConsoleKey.Spacebar)
            {
                _shouldDeal = true;
                _show = false;
                _coins = 100;
                args.Key = ConsoleKey.NoName;
            }

            if (_shouldDeal)
            {
                if (args.Key == ConsoleKey.Spacebar)
                    DealCards();
            } else
            {
                switch (args.Key)
                {
                    case ConsoleKey.Spacebar:
                        DrawCards();
                        break;
                    case ConsoleKey.D1:
                        _currentSelection[0].IsSelected = !_currentSelection[0].IsSelected;
                        break;
                    case ConsoleKey.D2:
                        _currentSelection[1].IsSelected = !_currentSelection[1].IsSelected;
                        break;
                    case ConsoleKey.D3:
                        _currentSelection[2].IsSelected = !_currentSelection[2].IsSelected;
                        break;
                    case ConsoleKey.D4:
                        _currentSelection[3].IsSelected = !_currentSelection[3].IsSelected;
                        break;
                    case ConsoleKey.D5:
                        _currentSelection[4].IsSelected = !_currentSelection[4].IsSelected;
                        break;
                    default:
                        break;
                }
            }
        }
        
        private void DealCards()
        {
            _deck = _deckBuilder.BuildDeck();
            _currentSelection = _deck.Take(5).ToList();
            _deck.RemoveRange(0, 5);
            _currentHand = UpdateCurrentHand();
            _shouldDeal = !_shouldDeal;
            _show = true;
        }

        private void DrawCards()
        {
            for(var i = 0; i < _currentSelection.Count; i++)
            {
                if(_currentSelection[i].IsSelected)
                {
                    _currentSelection[i] = _deck[0];
                    _deck.RemoveAt(0);
                }
            }
            _currentHand = UpdateCurrentHand();
            CalculateCoins();
            _shouldDeal = !_shouldDeal;
        }

        private Hand UpdateCurrentHand()
        {
            return new Hand
            {
                Cards = _currentSelection,
                Value = _handEvaluator.EvaluateHand(_currentSelection),
                Size = _currentSelection.Count
            };
        }

        private void CalculateCoins()
        {
            if (_currentHand.Value != 0)
                _coins += (int)_currentHand.Value;
            else
                _coins--;
        }
    }
}
