using System;
using System.Diagnostics.Metrics;
using System.Linq;

namespace CodeWars
{
    public class CodeWarsLR
    {
        /* 
         * For a given string "input" find the character char? with the longest
         * consecutive repetition and return: where int is the length of the repetition.
         * If there are two or more characters with the same length return the first in order
         * of appearance. For empty string return "Tuple<char?, int> (null, 0).
         */
        public Tuple<char?, int> LongestRepetition(string input)
        {
            //if there will appear more then one repetitive symbol, should be two values for
            //saving and further comparison between each other
            char? first_repetitive_symbol = ' '; 
            char? symbol_2 = ' ';

            //accordingly more then one counter to compare amount of repetitive symbols 
            int count_1 = 0;
            int count_2 = 0;

            //value to identify if there is repetitive symbol or not
            int flag = 0;

            //values for cycle inside of string
            int counter_i = 0;
            int counter_j = 0;

            //to make a stop and compare "first_repetitive_symbol" and "symbol_2"
            bool canBeCompared = false; 

            //to determine the end of string
            int LengthOfInput = input.Length - 1;

            //counter_i is the first symbol,counter_j now is the second;
            counter_j++;

            //if input is empty
            if (input.Length == 0)
            {
                return new Tuple<char?, int>(null, 0);
            }

            for (; ; )
            {
                //if symbols are not equal
                if (input[counter_i] != input[counter_j])
                {
                    if (canBeCompared == false)
                    {
                        //if it's near the end
                        if (counter_j == LengthOfInput)
                        {
                            //there are no repetitive symbols, return the first one
                            if (count_1 == 0)
                            {
                                char? letter = input.First();
                                return new Tuple<char?, int>(letter, 1);
                            }
                            //return completed values
                            else if (count_1 > 0)
                            {
                                return new Tuple<char?, int>(first_repetitive_symbol, count_1);
                            }
                        }
                        
                        else
                        {
                            //identify the beginning / identify new subsequence after repetitive block
                            if (counter_i == 0 || flag % 2 == 0)
                            {
                                flag++;
                                counter_i++;
                                counter_j++;
                            }
                            //identify the repeating of unequal symbols
                            else if (flag % 2 != 0)
                            {
                                counter_i++;
                                counter_j++;
                            }
                        }
                    }

                    //If CanBeCompared is true
                    else 
                    {
                        //if it's near the end
                        if (counter_j == LengthOfInput)
                        {
                            //comparing two values with repetitive symbols
                            if (count_1 > count_2)
                            {
                                return new Tuple<char?, int>(first_repetitive_symbol, count_1);
                            }
                            else
                            {
                                return new Tuple<char?, int>(symbol_2, count_2);
                            }
                        }
                        else
                        {
                            //comparing two values with repetitive symbols and reset value "symbol_2"
                            if (count_1 >= count_2)
                            {
                                symbol_2 = ' ';
                                count_2 = 0;
                                canBeCompared = false;            
                            }
                            else if (count_1 < count_2)
                            {
                                count_1 = count_2;
                                first_repetitive_symbol = symbol_2;
                                symbol_2 = ' ';
                                count_2 = 0;
                                canBeCompared = false;  
                            }
                        }
                    }
                }

                //If symbols are equal
                else if (input[counter_i] == input[counter_j])
                {
                    //identify the beginning
                    if (counter_i == 0)
                    {
                        flag = 2;
                        first_repetitive_symbol = input[counter_i];
                        count_1 = 2; //increased by two, cause it's 2 same symbols
                        counter_i++;
                        counter_j++;
                    }
                    //identify the repeating 
                    else if (flag % 2 != 0)
                    {
                        //if it's the first repetitive case
                        if (count_1 == 0)
                        {
                            flag++;
                            first_repetitive_symbol = input[counter_i];
                            count_1 = 2;
                            counter_i++;
                            counter_j++;
                        }
                        //if it's near the end
                        else if (counter_j == LengthOfInput)
                        {
                            //if repetitive symbols are in the end and its the first subsequence in the string
                            //and it equals two
                            if (count_1 == 0)
                            {
                                count_1 = 2;
                                first_repetitive_symbol = input[counter_i];
                                return new Tuple<char?, int>(first_repetitive_symbol, count_1);
                            }
                            //two repetitive symbols at the end with further comparison
                            else if (count_1 > 0)
                            {
                                count_2 = 2;
                                symbol_2 = input[counter_i];
                                if (count_1 >= count_2)
                                {
                                    return new Tuple<char?, int>(first_repetitive_symbol, count_1);
                                }
                                else if(count_1 < count_2)
                                {
                                    return new Tuple<char?, int>(symbol_2, count_2);
                                }
                            }
                        }
                        //if it's the second repetitive case
                        else if (count_1 > 0)
                        {
                            flag++;
                            symbol_2 = input[counter_i];
                            count_2 = 2;
                            canBeCompared = true;
                            counter_i++;
                            counter_j++;
                        }                      
                    }

                    //after repetitive subsequence
                    else if (flag % 2 == 0)
                    {
                        //if it's near the end
                        if (counter_j == LengthOfInput)
                        {
                            //if repetitive symbols are in the end and its the first subsequence in the string
                            //and it's more then two
                            if (canBeCompared == false)
                            {
                                count_1++;
                                return new Tuple<char?, int>(first_repetitive_symbol, count_1);
                            }
                            //more then two repetitive symbols at the end with further comparison
                            else
                            {
                                count_2++;
                                if (count_1 >= count_2)
                                {
                                    return new Tuple<char?, int>(first_repetitive_symbol, count_1);
                                }
                                else if (count_1 < count_2)
                                {
                                    return new Tuple<char?, int>(symbol_2, count_2);
                                }
                            }
                        }
                        //if the first repetitive case/symbol is continuing 
                        else if (input[counter_i] == first_repetitive_symbol)
                        { 
                            count_1++;
                            counter_i++;
                            counter_j++;        
                        }
                        //if the second repetitive case/symbol is continuing
                        else if (symbol_2 > 0)
                        {
                            count_2++;
                            counter_i++;
                            counter_j++;
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
