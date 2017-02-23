namespace _04_Winning_Ticket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Winning_Ticket
    {
        public static void Main(string[] args)
        {
            List<string> tickets = Console.ReadLine().Split(',').ToList();

            for (int i = 0; i < tickets.Count; i++)
            {
                tickets[i] = tickets[i].Trim();
            }

            foreach (var ticket in tickets)
            {
                if (!IsInvalidTicket(ticket))
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    Console.WriteLine(IsMatch(ticket));
                }
            }
        }

        private static string IsMatch(string ticket)
        {
            int length = 1;
            string symbol = "";
            int maxLengthLeft = 1;
            string maxSymbolLeft = "";
            int maxLengthRight = 1;
            string maxSymbolRight = "";

            bool existSequence = false;

            for (int i = 0; i < ticket.Length - 1; i++)
            {
                if (ticket[i] == ticket[i + 1] && IsWinningSymbol(ticket[i + 1].ToString()))
                {
                    length++;
                    symbol = ticket[i + 1].ToString();

                    if (length == 20 && IsWinningSymbol(symbol))
                    {
                        return $"ticket \"{ticket}\" - 10{symbol} Jackpot!";
                    }
                }
                else
                {
                    if (length >= 6 && length <= 9 && IsWinningSymbol(symbol))
                    {
                        if (existSequence)
                        {
                            maxLengthRight = length;
                            maxSymbolRight = symbol;
                            break;
                        }
                        else
                        {
                            maxLengthLeft = length;
                            maxSymbolLeft = symbol;
                            existSequence = true;
                        }
                    }

                    length = 1;
                    symbol = "";
                }
            }

            if (length == 1)
            {
                return $"ticket \"{ticket}\" - no match";
            }

            if (maxSymbolLeft == maxSymbolRight)
            {
                return $"ticket \"{ticket}\" - {Math.Min(maxLengthLeft, maxLengthRight)}{maxSymbolLeft}";
            }
            else
            {
                return $"ticket \"{ticket}\" - no match";
            }
        }

        private static bool IsWinningSymbol(string symbol)
        {
            string[] winningSymbol = new string[] { "@", "#", "$", "^" };

            bool checkWinSymbol = false;

            for (int i = 0; i < winningSymbol.Length; i++)
            {
                if (winningSymbol[i] == symbol)
                {
                    checkWinSymbol = true;
                }
            }

            return checkWinSymbol;
        }

        private static bool IsInvalidTicket(string ticket)
        {
            bool check = false;

            if (ticket.Length == 20)
            {
                check = true;
            }

            return check;
        }
    }
}