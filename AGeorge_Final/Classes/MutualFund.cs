using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class MutualFund:Investment
    {
        //Define Variables
        public double netAssetValue;

        //Define non-parameterized Constructor
        public MutualFund()
        {
 
        }

        //Define Set Accessor
        public void SetNAV(double aNav)
        {
            netAssetValue = aNav;
        }

        //Define Get Accessor
        public double GetMutualFundPrice()
        {
            return netAssetValue;

        }

        public double GetMutualFundsValue()
        {
            return investmentShares * netAssetValue;
        }

        //Define Custom Method for Displaying Mutual Fund Investment Information

        public string DisplayMutualFundInfo()
        {
            return string.Format(" \n\nID: {0} \nName: {1} \nSymbol: {2}" +
                "\nShares: {3} \nPrice: {4} \nMutual Fund Cash Value: {5}", GetInvestmentID(), GetInvestmentName(), GetInvestmentSymbol(),
                GetInvestmentShares(), GetMutualFundPrice().ToString("c"), GetMutualFundsValue().ToString("c"));
        }
    }

