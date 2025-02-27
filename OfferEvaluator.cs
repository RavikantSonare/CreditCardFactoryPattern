
public interface ICreditCard
{
    string CardName { get; }
    void eligibleCardType();
}

public class SilverCreditCard : ICreditCard
{
    public string CardName => "Silver Card";
    public void eligibleCardType() => Console.WriteLine(CardName);
}

public class GoldCreditCard : ICreditCard
{
    public string CardName => "Gold Card";
    public void eligibleCardType() => Console.WriteLine(CardName);
}

public class DiamondCreditCard : ICreditCard
{
    public string CardName => "Diamond Card";
    public void eligibleCardType() => Console.WriteLine(CardName);
}

public abstract class CreditCardFactory
{
    public abstract ICreditCard CreateInstance(Type type);
}

public class ConcreteCreditCardFactory : CreditCardFactory
{
    public override ICreditCard CreateInstance(Type type)
    {
        return (ICreditCard)Activator.CreateInstance(type);
    }
}

public class OfferEvaluator
{
    public static void Main(string[] args)
    {
        int transactionAmount = 15000; // Example transaction amount

        ConcreteCreditCardFactory factory = new ConcreteCreditCardFactory();
        Type cardType = transactionAmount switch
        {
            >= 50000 => typeof(DiamondCreditCard),
            >= 20000 => typeof(GoldCreditCard),
            >= 10000 => typeof(SilverCreditCard),
            _ => null
        };

        if (cardType != null)
        {
            ICreditCard cardInstance = factory.CreateInstance(cardType);
            Console.WriteLine($"Hello customer, great news for you! You are eligible for the {cardInstance.CardName}:");
            cardInstance.eligibleCardType(); // Call the method to display the card type
        }
    }
}