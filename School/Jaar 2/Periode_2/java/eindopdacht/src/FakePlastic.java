public class FakePlastic extends ChristmasTree
{
    private double price;

    public FakePlastic(String typeOfChristmasTree, String productInfo) {
        super(typeOfChristmasTree, productInfo);
        price = 10;
    }

    public double getPrice()
    {
        return this.price;
    }
}
