using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class Stock:Investment
    {
        //Define Variables
        public double stockPrice;
        public double stockCashValue;

        //Define non-parameterized Constructor
        public Stock()
        {
 
        }

        //Define Set Accessor
        public void SetStockPrice(double aPrice)
        {
            stockPrice = aPrice;
        }

        //Define Get Accessor
        public double GetStockPrice()
        {
            return stockPrice;

        }

        public double GetStockValue()
        {
            return investmentShares* stockPrice;
        }


        //Define Custom Method for Displaying Stock Investment Information

        public string DisplayStockInfo()
        {
            
            
            return string.Format("\n\nID: {0} \nName: {1} \nSymbol: {2}" +
                "\nShares: {3} \nPrice: {4} \nStock Cash Value: {5}", GetInvestmentID(), GetInvestmentName(), GetInvestmentSymbol(),
                GetInvestmentShares(), GetStockPrice().ToString("c"), GetStockValue().ToString("c"));
          }

       
        
    }

