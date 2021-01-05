import java.util.ArrayList;

public class Intratuin
{
    public ArrayList<ChristmasLight> christmasLights;
    public ArrayList<ChristmasBall> christmasBalls;
    public ArrayList<ChristmasTree> christmasTrees;

    public Intratuin()
    {
        this.christmasLights = new ArrayList<ChristmasLight>();
        this.christmasBalls = new ArrayList<ChristmasBall>();
        this.christmasTrees = new ArrayList<ChristmasTree>();
    }

    public ArrayList<ChristmasLight> getChristmasLights() {
        return christmasLights;
    }

    public void setChristmasLights(ArrayList<ChristmasLight> christmasLights) {
        this.christmasLights = christmasLights;
    }

    public ArrayList<ChristmasBall> getChristmasBalls() {
        return christmasBalls;
    }

    public void setChristmasBalls(ArrayList<ChristmasBall> christmasBalls) {
        this.christmasBalls = christmasBalls;
    }

    public ArrayList<ChristmasTree> getChristmasTrees() {
        return christmasTrees;
    }

    public void setChristmasTrees(ArrayList<ChristmasTree> christmasTrees) {
        this.christmasTrees = christmasTrees;
    }

    public String showAllProducts()
    {
        String allProducts = new String();
        for (int i = 0; i < this.christmasTrees.size(); i++)
        {
            System.out.println(this.christmasTrees.get(i).getProductInfo() + "; " + this.christmasTrees.get(i).getPrice());
            allProducts = allProducts + (this.christmasTrees.get(i).getProductInfo() + "; " + this.christmasTrees.get(i).getPrice());
        }
        for (int i = 0; i < this.christmasBalls.size(); i++)
        {
            System.out.println(this.christmasBalls.get(i).getProductInfo() + "; " + this.christmasBalls.get(i).getPrice());
            allProducts = allProducts + (this.christmasBalls.get(i).getProductInfo() + "; " + this.christmasBalls.get(i).getPrice());
        }
        for (int i = 0; i < this.christmasLights.size(); i++)
        {
            System.out.println(this.christmasLights.get(i).getProductInfo() + "; " + this.christmasLights.get(i).getPrice());
            allProducts = allProducts + (this.christmasLights.get(i).getProductInfo() + "; " + this.christmasLights.get(i).getPrice());
        }
        return allProducts;
    }
}
