public class ChristmasLight
{
    private TypesOfLights typeOfLights;
    private double price;
    private String productInfo;
    private Lengths length;


    public ChristmasLight(TypesOfLights typeOfLights, double price, String productInfo, Lengths length) {
        this.typeOfLights = typeOfLights;
        this.price = price;
        this.productInfo = productInfo;
        this.length = length;
    }

    public TypesOfLights getTypeOfLights() {
        return typeOfLights;
    }

    public void setTypeOfLights(TypesOfLights typeOfLights) {
        this.typeOfLights = typeOfLights;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public String getProductInfo() {
        return productInfo;
    }

    public void setProductInfo(String productInfo) {
        this.productInfo = productInfo;
    }

    public Lengths getLength() {
        return length;
    }

    public void setLength(Lengths length) {
        this.length = length;
    }

    public void turnOnLights()
    {
        if (this.typeOfLights.toString().equals("RGB"))
        {
            System.out.println("I’m giving a little bit more color to your life.");
        }
        else if (this.typeOfLights.toString().equals("RGBPhone"))
        {
            System.out.println("i’m completely future proof.");
        }
        else if (this.typeOfLights.toString().equals("RGBFlickering"))
        {
            System.out.println("I’m ready to have a little party.");
        }
        else
        {
            System.out.println("I’m just shining boring white.");
        }
    }
}
