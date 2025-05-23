# DbeanBalancedBrackets

This is a simple balanced bucket code challange I did for a job interview. 

My program worked with the test case I used to develop it. The unit tests I added with different test cases exposed a bug (I had forgotten to increment a count variable). It is to me yet another demonstration of the value of unit tests to expose bugs before code is deployed to production.


Description: <br>
A bracket is considered to be any one of the following set of characters: (), {}, [].

Two brackets are considered to be a matched pair if the an opening bracket - (, [, or { - occurs to the left of a closing bracket - ), ], or } - of the exact same type. There are three types of matched pairs of brackets: [], {}, and ().

A matching pair of brackets is not balanced if the set of brackets it encloses are not matched. For example, {[(])} is not balanced because the contents in between { and } are not balanced. The pair of square brackets encloses a single, unbalanced opening bracket, (, and the pair of parentheses encloses a single, unbalanced closing square bracket, ].

By this logic, we say a sequence of brackets is balanced if the following conditions are met:

It contains no unmatched brackets. The subset of brackets enclosed within the confines of a matched pair of brackets is also a matched pair of brackets. Given strings of brackets, determine whether each sequence of brackets is balanced. If a string is balanced, return YES. Otherwise, return NO.
