using System;
using System.Security;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BJAT.Common.Enums;
using BJAT.Data;
using BJAT.Data.Entities;
using BJAT.Services.Contracts;

namespace BJAT.Services
{
    public class AnalysisService : IAnalysisService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string[] _sections = { "BETTING", "STARTING HANDS", "PLAYING", "SUMMARY" };


        public AnalysisService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool ImportDataFromFile(string stream, string user)
        {
            var player = "Ruzginis";
            var deals = stream
                .Replace("Hand# ", "#")
                .Replace("Hand #", "#")
                .Split('#')
                .Where(x => x.Length > 0);
            foreach (var dealInfo in deals)
            {
                var type = dealInfo.Substring(0, dealInfo.IndexOf('\n'));
                if (type.Contains("Blackjack Table"))
                {
                    var sections = DivideIntoSections(dealInfo);
                    var deal = new Deal
                    {
                        DealId = Guid.NewGuid(),
                        UserId = _unitOfWork.Users.GetUserByLoginNameOrEmail(user).UserId,
                        InitialBet = GetDoubleValue(
                            sections.SingleOrDefault(x=>x.Key.Equals(_sections[0])).Value,
                            player + " bets ",
                            player),
                        TotalBet = GetDoubleValue(
                            sections.SingleOrDefault(x => x.Key.Equals(_sections[3])).Value,
                            "Total Bet: ",
                            player),
                        TotalPayout = GetDoubleValue(
                            sections.SingleOrDefault(x => x.Key.Equals(_sections[3])).Value,
                            "Total Paid: ",
                            player),
                        Mistakes = 0, //prideti klaidu skaiciavimo logika

                        DealerCards = GetDealerCardsFromSection(sections
                            .SingleOrDefault(x => x.Key.Equals(_sections[3])).Value)

                    };
                    deal.Profit = deal.TotalPayout - deal.TotalBet;

                } else if (type.Contains("Live Blackjack"))
                {
                    
                }
            }

            return true;
        }
        

        private static double GetDoubleValue(string src, string find, string playerName)
        {
            double retVal;
            var startPosition = src.IndexOf(playerName, StringComparison.Ordinal);
            var beginIndex = src.IndexOf(find, startPosition, StringComparison.Ordinal) + find.Length;
            var endIndex = src.IndexOf('\n', beginIndex);
            if (endIndex > 0)
            {
                double.TryParse(src
                        .Substring(beginIndex + 1, endIndex - beginIndex)
                        .Trim()
                        .Replace('.', ','),
                    out retVal);
            }
            else
            {
                double.TryParse(src
                        .Substring(beginIndex + 1)
                        .Trim()
                        .Replace('.', ','),
                    out retVal);
            }

            return retVal;
        }

        private List<KeyValuePair<string, string>> DivideIntoSections(string dealInfo)
        {
            var sections = new List<KeyValuePair<string, string>>();

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var sectionKey in _sections)
            {
                var sectionName = "*** " + sectionKey + " ***";
                var beginIndex = dealInfo.IndexOf(sectionName, StringComparison.Ordinal);
                var endIndex = dealInfo.IndexOf("***", beginIndex + sectionName.Length, StringComparison.Ordinal);
                var section = endIndex > 0 
                    ? dealInfo.Substring(beginIndex, endIndex - beginIndex).Trim() 
                    : dealInfo.Substring(beginIndex).Trim();
                sections.Add(new KeyValuePair<string, string>(sectionKey, section));
            }
            
            return sections;
        }

        private List<Card> GetDealerCardsFromSection(string src)
        {
            var dealerCards = new List<Card>();

            var cards = new List<string>();
            var beginIndex = src.IndexOf('[');
            var endIndex = src.IndexOf(']', beginIndex);
            cards.AddRange(src.Substring(beginIndex + 1,endIndex-beginIndex).Split(','));

            beginIndex = src.IndexOf('\n', beginIndex) + 1;
            endIndex = src.IndexOf('\n', beginIndex);
            var actions = src.Substring(beginIndex, endIndex - beginIndex).Split(',');
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var action in actions)
            {
                if (action.Length > 0 && !action.Contains("Stand on") && !action.Contains("Break with"))
                {
                    cards.Add(action.Split('[')[1].Split(']')[0]);
                }
            }

            foreach (var card in cards)
            {
                CardSuitEnum suit;
                CardValueEnum val;

                switch (card.Last())
                {
                    case 's':
                        suit = CardSuitEnum.Spades;
                        break;
                    case 'd':
                        suit = CardSuitEnum.Diamonds;
                        break;
                    case 'c':
                        suit = CardSuitEnum.Clubs;
                        break;
                    case 'h':
                        suit = CardSuitEnum.Hearts;
                        break;
                    default:
                        Enum.TryParse(card.Last().ToString(), true, out suit);
                        break;
                }

                switch (card.Substring(0,card.Length - 2))
                {
                    case "T":
                        val = CardValueEnum.Ten;
                        break;
                    case "J":
                        val = CardValueEnum.Jack;
                        break;
                    case "Q":
                        val = CardValueEnum.Queen;
                        break;
                    case "K":
                        val = CardValueEnum.King;
                        break;
                    case "A":
                        val = CardValueEnum.Ace;
                        break;
                    default:
                        Enum.TryParse(card.Substring(0, card.Length - 2), true, out val);
                        break;
                }

                var dealerCard = _unitOfWork.Cards.GetCard(val, suit);
                if (dealerCard != null)
                {
                    dealerCards.Add(_unitOfWork.Cards.GetCard(val, suit));
                }
                else
                {
                    _unitOfWork.Cards.Add(new Card()
                    {
                        Suit = suit,
                        Value = val,
                        Image = string.Empty,
                        Image4Colors = string.Empty
                    });
                    _unitOfWork.Complete();
                    dealerCards.Add(_unitOfWork.Cards.GetCard(val, suit));
                }
            }

            return dealerCards;
        } 
    }
}