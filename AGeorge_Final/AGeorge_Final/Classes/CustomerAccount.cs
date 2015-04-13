using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class CustomerAccount
    {
        public List<Stock> stocks = new List<Stock>();
        public List<MutualFund> MutualFunds = new List<MutualFund>();
       

        //Define Variables
        public string accountNumber;
        public string customerName;
        public string customerAddress;
        public string customerPhoneNo;

        double totalStockValue = 0;
        double totalMutualFundsValue = 0;

        //Define non-parameterized Constructor
        public CustomerAccount()
        {
 
        }

        //Define Set Accessors
        public void SetAccountNumber(string aNumber)
        {
            accountNumber = aNumber;
        }

        public void SetCustomerName(string aName)
        {
            customerName = aName;
        }

        public void SetCustomerAddress(string anAddress)
        {
            customerAddress = anAddress;
        }

        public void SetCustomerPhoneNo(string aPhNumber)
        {
            customerPhoneNo = aPhNumber;
        }

        //Define Get Accessors
        public string GetCustomerName()
        {
            return customerName;
        }

        public string GetAccountNumber()
        {
            return accountNumber;
        }

        public string GetCustomerAddress()
        {
            return customerAddress;
        }

        public string GetCustomerPhoneNo()
        {
            return customerPhoneNo;
        }


        //Define Custom methods
        //Define Add Stock method

        public void AddStock(Stock aStock)
        {
            stocks.Add(aStock);
        }

        public void AddMutualFund(MutualFund aMutualFund)
        {
            MutualFunds.Add(aMutualFund);
        }

        public List<Stock> GetStock()
        {
            return stocks;
        }

        public List<MutualFund> GetMutualFund()
        {
            return MutualFunds;
        }

        public double GetTotalStockValue()
        {

            foreach (Stock aStock in stocks)
            {
                totalStockValue = 0;
                totalStockValue += aStock.GetStockValue();
            }

            return totalStockValue;
        }

        public double GetTotalMutualFundsValue()
        {
            foreach (MutualFund aMutualFund in MutualFunds)
            {
                totalMutualFundsValue = 0;
                totalMutualFundsValue += aMutualFund.GetMutualFundsValue();
            }

            return totalMutualFundsValue;
        }

        public double GetTotalInvestmentValue()
        {
            return totalStockValue + totalMutualFundsValue;
        }

        public void DeleteStock(CustomerAccount aCustomer)
        {
            foreach (Stock aStock in aCustomer.GetStock().ToList())
            {
                stocks.Remove(aStock);
            }
        }

        public void DeleteMutualFund(CustomerAccount aCustomer)
        {
            foreach (MutualFund aMutualFund in aCustomer.GetMutualFund().ToList())
            {
                MutualFunds.Remove(aMutualFund);
            }
        }

        

    }

