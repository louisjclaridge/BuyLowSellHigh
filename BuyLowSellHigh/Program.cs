using System;
using System.Collections.Generic;
using System.IO;

namespace BuyLowSellHigh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<float> ImportedValues = (List<float>)ImportValues();
                Console.WriteLine(GetBestTrade(ImportedValues));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString() + "\n");
                Main(args);
            }
            Console.ReadKey();
        }


        static string GetBestTrade(List<float> ImportedValues)
        {
            Trade BestTrade = new Trade();

            for (int HighestValueDay = ImportedValues.Count - 1; HighestValueDay >= 0; HighestValueDay--)
            {
                for (int LowestValueDay = 0; LowestValueDay < HighestValueDay; LowestValueDay++)
                {
                    if (BestTrade.Profit != 0)
                    {
                        float PossibleProfit = ImportedValues[HighestValueDay] - ImportedValues[LowestValueDay];
                        if (PossibleProfit > 0 && BestTrade.Profit < PossibleProfit)
                        {
                            Trade currentTrade = new Trade(LowestValueDay + 1, ImportedValues[LowestValueDay], HighestValueDay + 1, ImportedValues[HighestValueDay], PossibleProfit);
                            BestTrade = currentTrade;
                        }
                    }
                    else
                    {
                        float PossibleProfit = ImportedValues[HighestValueDay] - ImportedValues[LowestValueDay];
                        Trade currentTrade = new Trade(LowestValueDay + 1, ImportedValues[LowestValueDay], HighestValueDay + 1, ImportedValues[HighestValueDay], PossibleProfit);
                        BestTrade = currentTrade;
                    }
                }
            }
            return String.Format("{0}({1}), {2}({3})", BestTrade.BuyDay, BestTrade.BuyAmount, BestTrade.SellDay, BestTrade.SellAmount);
        }

        static List<float> ImportValues()
        {
            string[] ListOfAllFiles = Directory.GetFiles(@"./", "*.txt");
            Console.WriteLine("Please Select file to Load");
            for (int i = 0; i < ListOfAllFiles.Length; i++)
            {
                Console.WriteLine(String.Format("[{0}] {1}", i + 1, ListOfAllFiles[i]));
            }

            int SelectedItem = Convert.ToInt32(Console.ReadLine()) - 1;

            if (SelectedItem < 0 || SelectedItem + 1 > ListOfAllFiles.Length)
            {
                throw new Exception("Input not valid, please select another value within the range provided");
            }
            else
            {
                string ImportFromTextfile = System.IO.File.ReadAllText(ListOfAllFiles[SelectedItem]);
                List<float> ImportedValues = new List<float>();

                foreach (string value in ImportFromTextfile.Split(','))
                {
                    ImportedValues.Add(float.Parse(value));
                }
                Console.Clear();
                return ImportedValues;
            }
        }
    }
}
