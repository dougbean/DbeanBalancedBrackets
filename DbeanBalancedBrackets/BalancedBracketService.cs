namespace DbeanBalancedBrackets
{
    public class BalancedBracketService 
    {
        /// <summary>
        /// Douglas Bean Balanced Bucket code challange.
        /// 
        /// If the first character is a closing bracket, the string is not balanced.
        /// If the string length is an odd number, it is not balanced.
        /// If the next one (after an opening bracket) is not a buddy but is also a closing bracket then the string is not balanced.
        /// </summary>       
        public bool IsBracketBalanced(string bracketString)
        {
            int divisor = 2;
            var closingBrackets = new List<string>() { "]", "}", ")" };

            var buddies = new Dictionary<string, string>()
            {
                { "{", "}" },
                { "(", ")" },
                { "[", "]" }
            };

            char[] brackets = bracketString.ToCharArray();

            char first = brackets[0];
            bool isFirstAClosingBracket = closingBrackets.Contains(first.ToString());

            if (isFirstAClosingBracket)
            {
                return false;//if the first character is a closing bracket, the string is not balanced.
            }

            int remainder = brackets.Length % divisor;

            if (remainder != 0)
            {
                return false;//if the string length is an odd number, it is not balanced.
            }

            int count = 0;
            var openerStack = new Stack<char>();
            foreach (char currentBracket in brackets)
            {
                string? closingBuddy = GetClosingBuddy(buddies, currentBracket);

                //if a closing buddy is found then current bracket is an opening bracket
                if (closingBuddy != null)
                {
                    char next = brackets[count + 1];
                    bool isNextABudddy = closingBuddy == next.ToString();
                    bool isNextAClosingBracket = closingBrackets.Contains(next.ToString());

                    //if the next character is not a buddy and not an opening bracket then the string is not balanced.
                    if (!isNextABudddy && isNextAClosingBracket)
                    {
                        return false;
                    }

                    //put current opening bracket in stack for further evaluation.
                    openerStack.Push(currentBracket);
                }
                else
                {
                    //buddy was not found, so current bracket is a closing bracket.
                    char lastOpenBracket = openerStack.Pop();
                    string? closerBuddy = GetClosingBuddy(buddies, lastOpenBracket);

                    if (closerBuddy != null)
                    {
                        bool isCurrentBracketABudddy = closerBuddy == currentBracket.ToString();

                        if (!isCurrentBracketABudddy)
                        {
                            return false;
                        }
                    }
                }
                count++;
            }
            return true;
        }

        private static string? GetClosingBuddy(Dictionary<string, string> buddies, char bracket)
        {
            return (from kvp in buddies
                    where kvp.Key == bracket.ToString()
                    select kvp.Value).FirstOrDefault();
        }
    }
}
