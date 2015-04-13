using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public abstract class Investment
    {
        //Define Variables
        public string investmentID;
        public string investmentName;
        public string investmentSymbol;
        public int investmentShares;

        public int tempShareStorage;
        

        //Define non-parameterized Constructor
        public Investment()
        {

        }
        
        //Define Set Accessors
        public void SetInvestmentID(string anID)
        {
            investmentID = anID;
        }

        public void SetInvestmentName(string anInvestmentName)
        {
            investmentName = anInvestmentName;
        }

        public void SetInvestmentSymbol(string aSymbol)
        {
            investmentSymbol = aSymbol;
        }

        public void SetInvestmentShares(int aShare)
        {
            investmentShares = aShare;
        }
   
        //Define Get Accessors
        public string GetInvestmentID()
        {
            return investmentID;
        }

        public string GetInvestmentName()
        {
            return investmentName;
        }

        public string GetInvestmentSymbol()
        {
            return investmentSymbol;
        }

        public int GetInvestmentShares()
        {
            return investmentShares;
        }

        //Define Custom Methods
        //Define Buy Shares method

        public void BuyShares(int aBuyAmount)
        {
            tempShareStorage = tempShareStorage + aBuyAmount;
        }

        //Define Sell Shares Method

        public void SellShares(int aSellAmount)
        {
            tempShareStorage = tempShareStorage - aSellAmount;
        }

        public void SetTempShareStorage(int aValue)
        {
            tempShareStorage = aValue;
        }

        public double GetTempStorageValue()
        {
            return tempShareStorage;
        }


    }

