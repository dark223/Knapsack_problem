using Xunit;
using myapp;
using System.Collections.Generic;

public class testclass
{
    [Fact]
    public void PassingPropertyGetName(){

        thingToSteal iron = new thingToSteal("iron",4,3);

        Assert.Equal("iron",iron.GetName);
    }

      [Fact]
    public void PassingPropertyGetWeight(){

        thingToSteal iron = new thingToSteal("iron",4,3);

        Assert.Equal(3,iron.GetWeight);
    }

      [Fact]
    public void PassingPropertyGetValue(){

        thingToSteal iron = new thingToSteal("iron",4,3);

        Assert.Equal(4,iron.GetValue);
    }

      [Fact]
    public void PassingPropertyGetRatio(){

        thingToSteal iron = new thingToSteal("iron",3,3);

        Assert.Equal(1,iron.GetRatio);
    }
    
    [Fact]
    public void PassingFracKnapSackSolver(){

        thingToSteal iron = new thingToSteal("iron",3,3);
        thingToSteal copper = new thingToSteal("copper",2,3);
        thingToSteal bronze = new thingToSteal("bronze",10,4);
        thingToSteal gold = new thingToSteal("gold",15,3);


        List<thingToSteal> ItemList = new List<thingToSteal>();
        ItemList.Add(iron);
        ItemList.Add(copper);
        ItemList.Add(bronze);
        ItemList.Add(gold);

        List<(float, thingToSteal)> actual = new List<(float, thingToSteal)>();
        actual.Add((3,gold));
        actual.Add((2,bronze));

        Assert.Equal(actual,program.FracKnapSackSolver(ItemList,5));
    }

    [Theory]
    [InlineData("iron",3,3,"copper",2,3,1)]
    [InlineData("iron",3,2,"copper",2,2,1)]
    [InlineData("iron",6,2,"copper",2,3,1)]
    public void PassingCompareByRatioXBiggerThanY(string x1, float x2, float x3, string y1, float y2, float y3, int exp){

        thingToSteal obj1 = new thingToSteal(x1,x2,x3);
        thingToSteal obj2 = new thingToSteal(y1,y2,y3);
            

        Assert.Equal(exp,thingToSteal.CompareByRatio(obj1,obj2));
    }

    [Theory]
    [InlineData("iron",2,3,"copper",3,3,-1)]
    [InlineData("iron",1,1,"copper",5,2,-1)]
    [InlineData("iron",4,1,"copper",9,2,-1)]
    public void PassingCompareByRatioXLessThanY(string x1, float x2, float x3, string y1, float y2, float y3, int exp){

        thingToSteal obj1 = new thingToSteal(x1,x2,x3);
        thingToSteal obj2 = new thingToSteal(y1,y2,y3);
            

        Assert.Equal(exp,thingToSteal.CompareByRatio(obj1,obj2));
    }

    [Theory]
    [InlineData("iron",2,2,"copper",3,3,0)]
    [InlineData("iron",1,1,"copper",5,5,0)]
    [InlineData("iron",1,4,"copper",2,8,0)]
    public void PassingCompareByRatioXEqualY(string x1, float x2, float x3, string y1, float y2, float y3, int exp){

        thingToSteal obj1 = new thingToSteal(x1,x2,x3);
        thingToSteal obj2 = new thingToSteal(y1,y2,y3);
            

        Assert.Equal(exp,thingToSteal.CompareByRatio(obj1,obj2));
    }

}