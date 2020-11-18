using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Strongbox
    {
        public int DECK_size { get; set; }
        public List<List<string>> DECK_decks { get 
            { 
                return new List<List<string>> { new List<string> { "8", "9", "10", "Jack", "Queen", "King"},
                                                new List<string> { "6", "7", "8", "9", "10", "Jack", "Queen", "King"},
                                                new List<string> { "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"},
                                                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"}};
            }
        }
        public List<string> DECK_deck { get; set; }
        public int DECK_chosen { get; set; }
        public List<string> DECK_suit { get
            {
                return new List<string> { "diamond", "club", "heart", "spade"};
            }
        }
        public List<string> CARD_color { get
            {
                return new List<string> { "Red", "Black" };
            }
        }
        public List<int> PLAYER_score { get; set; }
    }
}
