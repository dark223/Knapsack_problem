namespace myapp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit.Sdk;

    public class thingToSteal
    {
        public thingToSteal(string Name, float Value, float Weight)
        {
            name = Name;
            value = Value;
            
            // objects of negative or zero weight does not exist
            if (Weight > 0)
            {
                weight = Weight;
            }
            else
            {
                throw new NegativeOrZeroException("The weight of a thingToSteal object must not be negative or zero");
            }
            ratio= value/weight;
        }
        string name;
        float value;
        float weight;
        float ratio;

        public string GetName { get => name; }
        public float GetValue { get => value; }
        public float GetWeight { get => weight; }
        public float GetRatio { get => ratio; }

        public static int CompareByRatio(thingToSteal x, thingToSteal y)
        {
            if (x.ratio > y.ratio)
            {
                return 1;
            }
            else if (x.ratio == y.ratio)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }     
    }




    public static class program {


        public static List<(float, thingToSteal)> FracKnapSackSolver(List<thingToSteal> list, float SizeOfSack)
        {   
            if (list.Any(d => d==null))
            {
                throw new NullException("the list contains at least one null element");
            }
            List<(float, thingToSteal)> TempList = new List<(float, thingToSteal)>();
            float OccupiedSpace = 0;
            float AmountTaken;

            list.Sort(thingToSteal.CompareByRatio);
            list.Reverse();
            //makes sure that there is space in the sack
            //if there isn't space in the sack some of the object is removed
            for (int i = 0; i < list.Count; i++)
            {
                if (OccupiedSpace < SizeOfSack)
                {
                    if ((list[i].GetWeight + OccupiedSpace) <= SizeOfSack)
                    {
                        //takes the whole object
                        AmountTaken = list[i].GetWeight;
                        TempList.Add((AmountTaken, list[i]));
                        OccupiedSpace += AmountTaken;
                    }
                    else if ((list[i].GetWeight + OccupiedSpace) > SizeOfSack)
                    {
                        //takes as much of the object that can fit in the sack
                        AmountTaken = (SizeOfSack - OccupiedSpace);
                        TempList.Add((AmountTaken, list[i]));
                        OccupiedSpace += AmountTaken;
                    }
                }

            }
            return TempList;
        }

        public static void Main() {

            thingToSteal iron = new thingToSteal("iron",3,3);
            thingToSteal copper = new thingToSteal("copper",2,3);
            thingToSteal bronze = new thingToSteal("bronze",10,4);
            thingToSteal gold = new thingToSteal("gold",15,3);
            thingToSteal platinum = new thingToSteal("platinum",20,4);
            thingToSteal uranium = new thingToSteal("uranium",30,4);

            List<thingToSteal> ItemList = new List<thingToSteal>();
            ItemList.Add(iron);
            ItemList.Add(copper);
            ItemList.Add(bronze);
            ItemList.Add(gold);
            ItemList.Add(platinum);
            ItemList.Add(uranium);
            
            
            List<(float,thingToSteal)> result = new List<(float,thingToSteal)>();
            result=  FracKnapSackSolver(ItemList,9);
            foreach (var element in result)
            {
              Console.WriteLine($"The number of units taken from {element.Item2.GetName}: {element.Item1} to fill the sack \n");  
            }
           
        }

    }

    [System.Serializable]
    public class NegativeOrZeroException : System.Exception
    {
        public NegativeOrZeroException () { }
        public NegativeOrZeroException (string message) : base(message) { }
        public NegativeOrZeroException (string message, System.Exception inner) : base(message, inner) { }
        protected NegativeOrZeroException (
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}