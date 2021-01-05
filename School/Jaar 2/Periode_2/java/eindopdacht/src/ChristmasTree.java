import java.util.ArrayList;

public class ChristmasTree
{
    private String typeOfChristmasTree;
    private ChristmasLight lights;
    private ArrayList<ChristmasBall> christmasBalls;
    private String productInfo;

    public ChristmasTree(String typeOfChristmasTree, String productInfo) {
        this.typeOfChristmasTree = typeOfChristmasTree;
        this.productInfo = productInfo;
    }

    public String getTypeOfChristmasTree() {
        return typeOfChristmasTree;
    }

    public void setTypeOfChristmasTree(String typeOfChristmasTree) {
        this.typeOfChristmasTree = typeOfChristmasTree;
    }

    public String getProductInfo() {
        return productInfo;
    }

    public void setProductInfo(String productInfo) {
        this.productInfo = productInfo;
    }

    public ChristmasLight getLights() {
        return lights;
    }

    public ArrayList<ChristmasBall> getChristmasBalls() {
        return christmasBalls;
    }

    public void turnOnLights()
    {
        this.lights.turnOnLights();
    }

    private void checkLights()
    {

    }
    public double getPrice()
    {
        return 0;
    }
}
