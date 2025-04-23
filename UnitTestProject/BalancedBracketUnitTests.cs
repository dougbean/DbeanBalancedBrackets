namespace UnitTestProject;
using DbeanBalancedBrackets;

/// <summary>
/// Douglas Bean Balanced Bucket code challange
/// </summary>
[TestClass]
public class BalancedBracketUnitTests
{
    private BalancedBracketService balancedBracketService = new BalancedBracketService();

    [TestMethod]
    public void ShouldReturnFalseIfFirstBracketIsClosing()
    {
        //setup 
        string unbalancedSimple = "}(){}[](";

        //act
        bool result = balancedBracketService.IsBracketBalanced(unbalancedSimple);

        //assert
        Assert.IsFalse(result);
    }

    [DataTestMethod]
    [DataRow("(){")]
    [DataRow("(){}[")]
    [DataRow("(){}[](")]
    [DataRow("[()[]{}]]")]
    public void ShouldReturnFalseForOddNumberStringLength(string brackets)
    {
        //act
        bool result = balancedBracketService.IsBracketBalanced(brackets);

        //assert
        Assert.IsFalse(result);
    }

    [DataTestMethod]
    [DataRow("(]")]
    [DataRow("{}{)")]
    [DataRow("(]]((}")]
    [DataRow("[{(][)}]")]  
    public void ShouldReturnFalseForUnbalancedBracketStrings(string brackets)
    {
        //act
        bool result = balancedBracketService.IsBracketBalanced(brackets);

        //assert
        Assert.IsFalse(result);
    }

    [DataTestMethod]
    [DataRow("()")]
    [DataRow("()[]{}")]
    [DataRow("()[]{}[]()")]
    public void ShouldReturnTrueForBalancedBracketStrings(string brackets)
    {
        //act
        bool result = balancedBracketService.IsBracketBalanced(brackets);

        //assert
        Assert.IsTrue(result);
    }

    [DataTestMethod]
    [DataRow("({})")]
    [DataRow("[()[]{}]")]
    [DataRow("[([])[]{((()))}]")]
    public void ShouldReturnTrueForNestedBalancedBracketStrings(string brackets)
    {
        //act
        bool result = balancedBracketService.IsBracketBalanced(brackets);

        //assert
        Assert.IsTrue(result);
    }
}
