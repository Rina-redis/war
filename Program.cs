using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    public static int rounds = 0;
    static void Main(string[] args)
    {             
        int winner = 0;
        List<int> deck1 = new List<int>();
        List<int> deck2 = new List<int>();     
        

        FillList(deck1);
        FillList(deck2);

        while (deck1.Count > 0 && deck2.Count > 0)
        {
           
            if (deck1.First() == deck2.First())
            {
                (deck1,deck2)= TryToWar(deck1,deck2);
            }
            else
            {
                
                int cardA = deck1.First();
                int cardB = deck2.First();
                if (cardA > cardB)
                {
                    IncreaseRoundsCount();
                    deck1.Add(cardB);
                    deck2.Remove(cardB);
                }
                else
                {
                    IncreaseRoundsCount();
                    deck2.Add(cardA);
                    deck1.Remove(cardA);
                }
            }
        }
    
        if (deck1.Count > deck2.Count)//also need PAT
        {
            winner = 1;
        }
        else
        {
            winner = 2;
        }
        Console.WriteLine(winner +" "+ rounds);     
    }


    public static void IncreaseRoundsCount() => rounds++;
    public static (List<int>, List<int>) TryToWar(List<int> firstDeck, List<int> secondDeck)
    {
        if (firstDeck.Count > 4 && secondDeck.Count > 4)
        {
            IncreaseRoundsCount();
            int warCardA = firstDeck[4];
            int warCardB = secondDeck[4];
            if (warCardA > warCardB)
            {
                for (int i = 0; i < 5; i++)
                {
                    firstDeck.Add(secondDeck[0]);
                    secondDeck.Remove(secondDeck[0]);
                }
            }
            if (warCardB > warCardA)
            {
                for (int i = 0; i < 5; i++)
                {
                    secondDeck.Add(firstDeck[0]);
                    firstDeck.Remove(firstDeck[0]);
                }
            }
            else
            {
                TryToWar(firstDeck, secondDeck);//need to sth with cards from first war
            }
        }
        return (firstDeck, secondDeck);
    }
    public static void FillList(List<int> deck)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string card = Console.ReadLine(); // the n cards of player 1  
            string cardToAdd = DeleteSuit(card);
            deck.Add(GetCardHash(cardToAdd));
        }

    }
    public static string DeleteSuit(string card)
    {
        return card.Remove(card.Length - 1);
    }
    public static int GetCardHash(string card)
    {
        string[] ranks = { "J", "Q", "K", "A" };
        if (ranks.Contains(card))
        {
            return 11 + Array.IndexOf(ranks, card);
        }
        else
        {
            return int.Parse(card);
        }
    }
}
