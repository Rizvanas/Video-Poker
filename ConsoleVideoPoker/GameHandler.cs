
using Core.Domain.Models;
using Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleUI.Drawers;

namespace ConsoleVideoPoker
{
    public class GameHandler
    {

        private readonly IDeckBuilder _deckBuilder;
        private readonly IHandEvaluator _handEvaluator;
        private readonly VideoPokerPainter _painter;
        private bool _shouldDeal;
        private bool _run;
        private List<Card> _deck;
        private List<Card> _currentSelection;

        public GameHandler(IDeckBuilder deckBuilder, IHandEvaluator handEvaluator, VideoPokerPainter painter)
        {
            _deckBuilder = deckBuilder;
            _handEvaluator = handEvaluator;
            _painter = painter;
            _run = true;

            _deck = _deckBuilder.BuildDeck();
            _currentSelection = _deck.Take(5).ToList();
            _deck.RemoveRange(0, 5);
            _shouldDeal = false;
        }

        public bool Run()
        {
            return _run;
        }

        public void OnKeyPressed(object source, ConsoleKeyEventArgs args)
        {
            switch (args.Key)
            {
                case ConsoleKey.E:
                    if (_shouldDeal)
                        Deal();
                    else
                        Draw();
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
                case ConsoleKey.Escape:
                    _run = false;
                    break;
                default:
                    break;
            }
        }
        
        public void Deal()
        {
            _deck = _deckBuilder.BuildDeck();
            _currentSelection = _deck.Take(5).ToList();
            _deck.RemoveRange(0, 5);
            _shouldDeal = !_shouldDeal; 
        }

        public void Draw()
        {
            var seleted = _currentSelection.Where(c => c.IsSelected).ToList();
            for(var i = 0; i < seleted.Count; i++)
            {
                seleted[i] = _deck[0];
                _deck.RemoveAt(0);
            }

            _shouldDeal = !_shouldDeal;             
        }
    }
}
