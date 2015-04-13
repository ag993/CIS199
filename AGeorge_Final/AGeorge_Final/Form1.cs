using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace AGeorge_Final
{
    public partial class Form1 : Form
    {
        //Define Lists
        List<CustomerAccount> Customers = new List<CustomerAccount>();
        


        public Form1()
        {
            InitializeComponent();
            txtTotalInvestmentValue.Enabled = false;
            label34.Text = "Please click on a Stock or Mutual Fund \nto view more information";
            label35.Text = "Please click on a Stock or Mutual Fund \nto view more information";
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            //Instantiate aCustomer of Customers List
            CustomerAccount aCustomer = new CustomerAccount();

            try
            {
                if (txtAccountNumber.Text == "")
                {
                    MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                    return;
                }
                else
                {
                    aCustomer.SetAccountNumber(txtAccountNumber.Text);
                }

                if (txtCustomerName.Text == "")
                {
                    MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                    return;
                }
                else
                {
                    aCustomer.SetCustomerName(txtCustomerName.Text);
                }

                if (txtCustomerAddress.Text == "")
                {
                    MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                    return;
                }
                else
                {
                    aCustomer.SetCustomerAddress(txtCustomerAddress.Text);
                }

                if (txtCustomerPhoneNo.Text == "")
                {
                    MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                    return;
                }
                else
                {
                    aCustomer.SetCustomerPhoneNo(txtCustomerPhoneNo.Text);
                }

                if (IsAccountNumberUnique(txtAccountNumber.Text) == false)
                {
                    MessageBox.Show("The account number you entered already exists. Please use a new number or to edit the existing account visit the View/Edit Tab", "Duplicate Account Number");
                    txtAccountNumber.Clear();
                    return;
                }
                               

                Customers.Add(aCustomer);

                MessageBox.Show("Customer account created successfully.", "Account Created");

                ClearAddCustomerTextboxes();
                PopulateComboBoxesCustomerName();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Please make sure you input data in expected format. If that doesn't recolve the issues please contact customer service.", "Error");
                return;
            }

        }

        private void btnAddInvestment_Click(object sender, EventArgs e)
        {
            try
            {
                //Make sure a customer is selected first.
                if (cboCustomerInvestment.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a customer first!", "Missing Information");
                    return;
                }
                
                // If statement to make sure either Stock or Mutual Funds are selected.
                if (rbtnMutual.Checked == false & rbtnStock.Checked == false)
                {
                    MessageBox.Show("Please select investment type!", "Error");
                    return;
                }


                //If statement for Stocks
                if (rbtnStock.Checked == true)
                {

                    Stock aStock = new Stock();


                    if (txtInvestmentID.Text == "")
                    {
                        MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                        return;
                    }
                    else
                    {
                        if (IsStockInvestmentIDUnique(txtInvestmentID.Text) == false)
                        {
                            MessageBox.Show("This investment ID already exists for another stock. Please select a unique vlaue", "Duplicate ID");
                            txtInvestmentID.Clear();
                            return;
                        }
                        
                        aStock.SetInvestmentID(txtInvestmentID.Text);
                    }

                    if (txtInvestmentName.Text == "")
                    {
                        MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                        return;
                    }
                    else
                    {
                        aStock.SetInvestmentName(txtInvestmentName.Text);
                    }

                    if (txtInvestmentSymbol.Text == "")
                    {
                        MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                        return;
                    }
                    else
                    {
                        aStock.SetInvestmentSymbol(txtInvestmentSymbol.Text);
                    }

                    if (txtInvestmentShares.Text == "")
                    {
                        MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                        return;
                    }
                    else
                    {
                        aStock.SetInvestmentShares(Convert.ToInt32(txtInvestmentShares.Text));
                    }

                    if (txtInvestmentPrice.Text == "")
                    {
                        MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                        return;
                    }
                    else
                    {
                        aStock.SetStockPrice(Convert.ToDouble(txtInvestmentPrice.Text));
                    }

                    //Add the aStock to the Customer List

                    Customers[cboCustomerInvestment.SelectedIndex].AddStock(aStock);

                    MessageBox.Show("The investment has been successfully purchased for " + Customers[cboCustomerInvestment.SelectedIndex].GetCustomerName(), "Investment Purchased");

                    //Clear the textboxes in the Investment Tab and reload investments
                    ClearAddInvestmentTextBoxes();
                    loadCustomerInvestments();
                    
                    

                }
                    //Else Statement 
                else 
                {
                    MutualFund aMutualFund = new MutualFund();


                    if (txtInvestmentID.Text == "")
                    {
                        MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                        return;
                    }
                    else
                    {
                        if (IsMutualFundInvestmentIDUnique(txtInvestmentID.Text) == false)
                        {
                            MessageBox.Show("This investment ID already exists for another mutual fund. Please select a unique vlaue", "Duplicate ID");
                            txtInvestmentID.Clear();
                            return;
                        }

                        aMutualFund.SetInvestmentID(txtInvestmentID.Text);
                    }

                    if (txtInvestmentName.Text == "")
                    {
                        MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                        return;
                    }
                    else
                    {
                        aMutualFund.SetInvestmentName(txtInvestmentName.Text);
                    }

                    if (txtInvestmentSymbol.Text == "")
                    {
                        MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                        return;
                    }
                    else
                    {
                        aMutualFund.SetInvestmentSymbol(txtInvestmentSymbol.Text);
                    }

                    if (txtInvestmentShares.Text == "")
                    {
                        MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                        return;
                    }
                    else
                    {
                        aMutualFund.SetInvestmentShares(Convert.ToInt32(txtInvestmentShares.Text));
                    }

                    if (txtInvestmentPrice.Text == "")
                    {
                        MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                        return;
                    }
                    else
                    {
                        aMutualFund.SetNAV(Convert.ToDouble(txtInvestmentPrice.Text));
                    }

                    //Add the aMutualFund to the List MutualFunds
                    Customers[cboCustomerInvestment.SelectedIndex].AddMutualFund(aMutualFund);

                    MessageBox.Show("The investment has been successfully purchased for " + Customers[cboCustomerInvestment.SelectedIndex].GetCustomerName(), "Investment Purchased");

                    //Load customer investments and clear the textboxes in the Investment Tab
                    loadCustomerInvestments();
                    ClearAddInvestmentTextBoxes();
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Please make sure you input data in expected format. If that doesn't recolve the issues please contact customer service.", "Error");
                return;
            }

        }


        //Populate the two comboboxes after a customer has been addes with Customer Name.
        private void PopulateComboBoxesCustomerName()
        {
            cboCustomerInfo.Items.Clear();
            cboCustomerInvestment.Items.Clear();
            foreach (CustomerAccount aCustomer in Customers)
            {
                cboCustomerInfo.Items.Add(aCustomer.GetCustomerName());
                cboCustomerInvestment.Items.Add(aCustomer.GetCustomerName());
            }
        }

        private void ClearAddCustomerTextboxes()
        {
            txtAccountNumber.Clear();
            txtCustomerAddress.Clear();
            txtCustomerName.Clear();
            txtCustomerPhoneNo.Clear();
            txtAccountNumber.Focus();
        }

        private void ClearAddInvestmentTextBoxes()
        {
            txtInvestmentID.Clear();
            txtInvestmentName.Clear();
            txtInvestmentPrice.Clear();
            txtInvestmentShares.Clear();
            txtInvestmentSymbol.Clear();
            rbtnMutual.Checked = false;
            rbtnStock.Checked = false;
            

        }
        private void ClearUpdatedCustomerInformationTextboxes()
        {
            cboCustomerInfo.SelectedIndex = -1;
            lboViewStockInvestments.Items.Clear();
            lboViewMutualFundInvestments.Items.Clear();
            txtViewAccountNumber.Clear();
            txtViewCustomerAddress.Clear();
            txtViewCustomerName.Clear();
            txtViewCustomerPhoneNo.Clear();
            txtTotalInvestmentValue.Clear();
            lblMutualFundsTotalValue.Text = String.Empty;
            lblStockTotalCashValue.Text = string.Empty;

            
        }


        //Populate the listbox for stocks depending on which customer is selected.
        // Populate the listbox for mutual funds depending on whih customer is selected.
        private void cboCustomerInvestment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomerInvestment.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                //Use defined method to load customer investments when customer is selected.
                loadCustomerInvestments();
            }
        }

        //Load investments into Stock and Mutual Fund Listboxes on the investment tab
        private void loadCustomerInvestments()
        {
            //Populate Stocks Listbox
            lboCustomerStockInvestment.Items.Clear();
            foreach (Stock aStock in Customers[cboCustomerInvestment.SelectedIndex].GetStock())
            {
                lboCustomerStockInvestment.Items.Add(aStock.GetInvestmentName());
            }


            //Populating Mutual Funds

            lboCustomerMutualFundInvestment.Items.Clear();
            foreach (MutualFund aMutualFund in Customers[cboCustomerInvestment.SelectedIndex].GetMutualFund())
            {
                lboCustomerMutualFundInvestment.Items.Add(aMutualFund.GetInvestmentName());
            }

        }

        //Load investments into Stock and Mutual Fund Listboxes on the View tab
        private void loadViewCustomerInvestments()
        {
            //Reload the ListBoxes with Stock Informations
            lboViewStockInvestments.Items.Clear();
            cboStockShares.Items.Clear();
            foreach (Stock aStock in Customers[cboCustomerInfo.SelectedIndex].GetStock())
            {
                lboViewStockInvestments.Items.Add(aStock.GetInvestmentName());
                cboStockShares.Items.Add(aStock.GetInvestmentName());
            }

            //Populating Mutual Funds

            lboViewMutualFundInvestments.Items.Clear();
            cboMutualFundShares.Items.Clear();
            foreach (MutualFund aMutualFund in Customers[cboCustomerInfo.SelectedIndex].GetMutualFund())
            {
               
                lboViewMutualFundInvestments.Items.Add(aMutualFund.GetInvestmentName());
                cboMutualFundShares.Items.Add(aMutualFund.GetInvestmentName());
              
            }

        }

        private void lboCustomerStockInvestment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomerInvestment.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                MessageBox.Show("Stock Investment Information: " + Customers[cboCustomerInvestment.SelectedIndex].stocks[lboCustomerStockInvestment.SelectedIndex].DisplayStockInfo());
            }
        }
        private void lboCusomerMutualFundInvestment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomerInvestment.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                MessageBox.Show("Mutual Funds Investment Information: " + Customers[cboCustomerInvestment.SelectedIndex].MutualFunds[lboCustomerMutualFundInvestment.SelectedIndex].DisplayMutualFundInfo());
            }
        }

        private void lboViewStockInvestments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomerInfo.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                MessageBox.Show("Stock Investment Information: " + Customers[cboCustomerInfo.SelectedIndex].stocks[lboViewStockInvestments.SelectedIndex].DisplayStockInfo());
            }
        }

        private void lboViewMutualFundInvestments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomerInfo.SelectedIndex == -1 || lboViewMutualFundInvestments.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                MessageBox.Show("Mutual Fund Information: " + Customers[cboCustomerInfo.SelectedIndex].MutualFunds[lboViewMutualFundInvestments.SelectedIndex].DisplayMutualFundInfo());
            }
        }

        private void cboCustomerInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomerInfo.SelectedIndex == -1)
            {

            }
            else
            {
                //Retreive information from the List and display them in the TextBoxes on the View Tab
                txtViewAccountNumber.Text = Customers[cboCustomerInfo.SelectedIndex].GetAccountNumber();
                txtViewCustomerAddress.Text = Customers[cboCustomerInfo.SelectedIndex].GetCustomerAddress();
                txtViewCustomerName.Text = Customers[cboCustomerInfo.SelectedIndex].GetCustomerName();
                txtViewCustomerPhoneNo.Text = Customers[cboCustomerInfo.SelectedIndex].GetCustomerPhoneNo();

                //Load investments into Stock and Mutual Fund Listboxes on the View tab
                loadViewCustomerInvestments();

                //Add the Total Stock Value to the Label
                lblStockTotalCashValue.Text = "Value:" + Customers[cboCustomerInfo.SelectedIndex].GetTotalStockValue().ToString("c");

                //Add the Total Mutual FUnds value to the label
                lblMutualFundsTotalValue.Text = "Value:" + Customers[cboCustomerInfo.SelectedIndex].GetTotalMutualFundsValue().ToString("c");

                //Display total investment value by adding total stock value + total mf value
                txtTotalInvestmentValue.Text = Customers[cboCustomerInfo.SelectedIndex].GetTotalInvestmentValue().ToString("c");

                //Disable controls if not customer is selected
                DisableEnableControlsViewTab();
                ClearBuySellSharesControls();

                checkBoxCloseAccount.Enabled = true;
                btnCloseAccount.Enabled = true;
                btnUpdateCustomer.Enabled = true;
            }
            


        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                //Make sure a customer is selected first.
                if (cboCustomerInfo.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a customer first!", "Missing Information");
                    return;
                }

                //Update Customer information after verifying that data is enetered in appropriate format and not left empty.

                if (txtViewAccountNumber.Text == "")
                {
                    MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                    return;
                }
                else
                {
                    if (txtViewAccountNumber.Text == Customers[cboCustomerInfo.SelectedIndex].GetAccountNumber())
                    {

                    }
                    else
                    {
                        if (IsAccountNumberUnique(txtViewAccountNumber.Text) == false)
                        {
                            MessageBox.Show("The account number you entered already exists. Please use a new number or to edit the existing account visit the View/Edit Tab", "Duplicate Account Number");
                            txtViewAccountNumber.Clear();
                            return;
                        }
                        else
                        {

                            Customers[cboCustomerInfo.SelectedIndex].SetAccountNumber(txtViewAccountNumber.Text);
                        }
                    }
                }
                if (txtViewCustomerName.Text == "")
                {
                    MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                    return;
                }
                else
                {
                    Customers[cboCustomerInfo.SelectedIndex].SetCustomerName(txtViewCustomerName.Text);
                }

                if (txtViewCustomerAddress.Text == "")
                {
                    MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                    return;
                }
                else
                {
                    Customers[cboCustomerInfo.SelectedIndex].SetCustomerAddress(txtViewCustomerAddress.Text);
                }

                if (txtViewCustomerPhoneNo.Text == "")
                {
                    MessageBox.Show("Please enter all necessary fields marked with *", "Missing Information");
                    return;
                }
                else
                {
                    Customers[cboCustomerInfo.SelectedIndex].SetCustomerPhoneNo(txtViewCustomerPhoneNo.Text);
                }

                MessageBox.Show("The customer account has been updated successfully.", "Success");

                //Reload listboxes on the view tab
                //loadViewCustomerInvestments();
                DisableEnableControlsViewTab();
                ClearUpdatedCustomerInformationTextboxes();
                PopulateComboBoxesCustomerName();
                

                //Disable Close Account and Update customer Buttons
                btnUpdateCustomer.Enabled = false;
                btnCloseAccount.Enabled = false;
                checkBoxCloseAccount.Enabled = false;
                
                             
            }
            catch (Exception)
            {
                MessageBox.Show("Please make sure you input data in expected format. If that doesn't resolve the issues please contact customer service.", "Error");
                return;
            }
        }

        private void btnStockShares_Click(object sender, EventArgs e)
        {

            try
            {
                if (rbnBuyStock.Checked == false & rbnSellStock.Checked == false)
                {
                    MessageBox.Show("Please select if you want to buy shares or sell shares.", "Buy or Sell Stock Shares");
                    return;
                }

                if (rbnBuyStock.Checked == true)
                {
                    //Set TempStorage value to the selected customer's selected stock's investment shares.
                    Customers[cboCustomerInfo.SelectedIndex].stocks[cboStockShares.SelectedIndex].SetTempShareStorage(Customers[cboCustomerInfo.SelectedIndex].stocks[cboStockShares.SelectedIndex].GetInvestmentShares());
                    //Invoke the Buy Shares Method in Investment Class to do the addition.
                    Customers[cboCustomerInfo.SelectedIndex].stocks[cboStockShares.SelectedIndex].BuyShares((Convert.ToInt32(txtStockChangeAmount.Text)));
                    //Set the NEW tempstorage value to Investment Share for the selected customer's selected stock.
                    Customers[cboCustomerInfo.SelectedIndex].stocks[cboStockShares.SelectedIndex].SetInvestmentShares(Convert.ToInt32(Customers[cboCustomerInfo.SelectedIndex].stocks[cboStockShares.SelectedIndex].GetTempStorageValue()));

                    MessageBox.Show("Congratulations. Your stocks shares have been purchased successfully", "Success");
                    txtStockChangeAmount.Clear();
                    rbnBuyStock.Checked = false;
                    cboStockShares.SelectedIndex = -1;
                    ClearUpdatedCustomerInformationTextboxes();
                    if (cboCustomerInfo.SelectedIndex == -1)
                    {
                        cboStockShares.Enabled = false;
                        txtStockChangeAmount.Enabled = false;
                        rbnBuyStock.Enabled = false;
                        rbnSellStock.Enabled = false;
                        btnStockShares.Enabled = false;

                        cboMutualFundShares.Enabled = false;
                        txtMutualFundChangeAmount.Enabled = false;
                        rbnBuyMutualFund.Enabled = false;
                        rbnSellMutualFund.Enabled = false;
                        btnMutualFundShares.Enabled = false;

                        checkBoxCloseAccount.Enabled = false;
                        btnCloseAccount.Enabled = false;
                        btnUpdateCustomer.Enabled = false;
                    }

                }
                else
                {

                    //Set TempStorage value to the selected customer's selected stock's investment shares.
                    Customers[cboCustomerInfo.SelectedIndex].stocks[cboStockShares.SelectedIndex].SetTempShareStorage(Customers[cboCustomerInfo.SelectedIndex].stocks[cboStockShares.SelectedIndex].GetInvestmentShares());
                    //If statement to make sure that the amount of shares being sold < amount of shares currently owned.
                    if (Customers[cboCustomerInfo.SelectedIndex].stocks[cboStockShares.SelectedIndex].GetInvestmentShares() < Convert.ToInt32(txtStockChangeAmount.Text))
                    {
                        MessageBox.Show("You cannot sell more stocks shares than what you currently own", "Insuffecient Stocks");
                    }
                    else
                    {
                        //Invoke the Buy Shares Method in Investment Class to do the addition.
                        Customers[cboCustomerInfo.SelectedIndex].stocks[cboStockShares.SelectedIndex].SellShares((Convert.ToInt32(txtStockChangeAmount.Text)));
                        //Set the NEW tempstorage value to Investment Share for the selected customer's selected stock.
                        Customers[cboCustomerInfo.SelectedIndex].stocks[cboStockShares.SelectedIndex].SetInvestmentShares(Convert.ToInt32(Customers[cboCustomerInfo.SelectedIndex].stocks[cboStockShares.SelectedIndex].GetTempStorageValue()));

                        MessageBox.Show("Congratulations. Your stock shares have been sold successfully", "Success");
                        txtStockChangeAmount.Clear();
                        rbnSellMutualFund.Checked = false;
                        cboMutualFundShares.SelectedIndex = -1;
                        ClearUpdatedCustomerInformationTextboxes();
                        if (cboCustomerInfo.SelectedIndex == -1)
                        {
                            cboStockShares.Enabled = false;
                            txtStockChangeAmount.Enabled = false;
                            rbnBuyStock.Enabled = false;
                            rbnSellStock.Enabled = false;
                            btnStockShares.Enabled = false;

                            cboMutualFundShares.Enabled = false;
                            txtMutualFundChangeAmount.Enabled = false;
                            rbnBuyMutualFund.Enabled = false;
                            rbnSellMutualFund.Enabled = false;
                            btnMutualFundShares.Enabled = false;

                            checkBoxCloseAccount.Enabled = false;
                            btnCloseAccount.Enabled = false;
                            btnUpdateCustomer.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You cannot Buy or Sell shares unless you have made an investment. Please visit the investment tab.", "Error");
            }
        }

        private void btnMutualFundShares_Click(object sender, EventArgs e)
        {
            try
            {

                if (rbnBuyMutualFund.Checked == false & rbnSellMutualFund.Checked == false)
                {
                    MessageBox.Show("Please select if you want to buy Mutual Funds or sell Mutual Funds.", "Buy or Sell Mutual Fund Shares");
                    return;
                }

                if (rbnBuyMutualFund.Checked == true)
                {
                    //Set TempStorage value to the selected customer's selected MutualFund's investment shares.
                    Customers[cboCustomerInfo.SelectedIndex].MutualFunds[cboMutualFundShares.SelectedIndex].SetTempShareStorage(Customers[cboCustomerInfo.SelectedIndex].MutualFunds[cboMutualFundShares.SelectedIndex].GetInvestmentShares());
                    //Invoke the Buy Method in Investment class to do the addition
                    Customers[cboCustomerInfo.SelectedIndex].MutualFunds[cboMutualFundShares.SelectedIndex].BuyShares(Convert.ToInt32(txtMutualFundChangeAmount.Text));
                    //Set the NEW tempstorage value to Investment Share for the selected customer's selected mutual fund.
                    Customers[cboCustomerInfo.SelectedIndex].MutualFunds[cboMutualFundShares.SelectedIndex].SetInvestmentShares(Convert.ToInt32(Customers[cboCustomerInfo.SelectedIndex].MutualFunds[cboMutualFundShares.SelectedIndex].GetTempStorageValue()));

                    MessageBox.Show("Congratulations. Your Mutual Funds have been purchased successfully", "Success");
                    txtMutualFundChangeAmount.Clear();
                    rbnBuyMutualFund.Checked = false;
                    cboStockShares.SelectedIndex = -1;
                    ClearUpdatedCustomerInformationTextboxes();
                    ClearUpdatedCustomerInformationTextboxes();
                    if (cboCustomerInfo.SelectedIndex == -1)
                    {
                        cboStockShares.Enabled = false;
                        txtStockChangeAmount.Enabled = false;
                        rbnBuyStock.Enabled = false;
                        rbnSellStock.Enabled = false;
                        btnStockShares.Enabled = false;

                        cboMutualFundShares.Enabled = false;
                        txtMutualFundChangeAmount.Enabled = false;
                        rbnBuyMutualFund.Enabled = false;
                        rbnSellMutualFund.Enabled = false;
                        btnMutualFundShares.Enabled = false;

                        checkBoxCloseAccount.Enabled = false;
                        btnCloseAccount.Enabled = false;
                        btnUpdateCustomer.Enabled = false;
                    }
                }
                else
                {
                    //Set TempStorage value to the selected customer's selected mutualFund's investment share
                    Customers[cboCustomerInfo.SelectedIndex].MutualFunds[cboMutualFundShares.SelectedIndex].SetTempShareStorage(Customers[cboCustomerInfo.SelectedIndex].MutualFunds[cboMutualFundShares.SelectedIndex].GetInvestmentShares());
                    //If statement to make sure that mutual funds that will be sold <= owned mutual funds
                    if (Customers[cboCustomerInfo.SelectedIndex].MutualFunds[cboMutualFundShares.SelectedIndex].GetInvestmentShares() < Convert.ToInt32(txtMutualFundChangeAmount.Text))
                    {
                        MessageBox.Show("You cannot sell more mutual funds than what you currently own", "Insuffecient Mutual Funds");
                        return;
                    }
                    else
                    {
                        //Invoke the Sell method in Investment Class to do the subtraction
                        Customers[cboCustomerInfo.SelectedIndex].MutualFunds[cboMutualFundShares.SelectedIndex].SellShares(Convert.ToInt32(txtMutualFundChangeAmount.Text));
                        //Set the NEW tempstorage value to Investment share for the selected customer's selected mutual fund.
                        Customers[cboCustomerInfo.SelectedIndex].MutualFunds[cboMutualFundShares.SelectedIndex].SetInvestmentShares(Convert.ToInt32(Customers[cboCustomerInfo.SelectedIndex].MutualFunds[cboMutualFundShares.SelectedIndex].GetTempStorageValue()));
                        
                        MessageBox.Show("Congratulations. Your Mutual Funds have been sold successfully", "Success");
                        txtMutualFundChangeAmount.Clear();
                        rbnSellMutualFund.Checked = false;
                        cboStockShares.SelectedIndex = -1;
                        ClearUpdatedCustomerInformationTextboxes();
                        ClearUpdatedCustomerInformationTextboxes();
                        if (cboCustomerInfo.SelectedIndex == -1)
                        {
                            cboStockShares.Enabled = false;
                            txtStockChangeAmount.Enabled = false;
                            rbnBuyStock.Enabled = false;
                            rbnSellStock.Enabled = false;
                            btnStockShares.Enabled = false;

                            cboMutualFundShares.Enabled = false;
                            txtMutualFundChangeAmount.Enabled = false;
                            rbnBuyMutualFund.Enabled = false;
                            rbnSellMutualFund.Enabled = false;
                            btnMutualFundShares.Enabled = false;

                            checkBoxCloseAccount.Enabled = false;
                            btnCloseAccount.Enabled = false;
                            btnUpdateCustomer.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please make sure you input data in expected format. If that doesn't recolve the issues please contact customer service.", "Error");
                return;
            }
        }

        private void ClearStocksSharesTextsboxes()
        {
 
        }

        //Code to clear the Tbas when they are left

        private void ClearControlsWhenTabisLeft(object sender, EventArgs e)
        {
            cboCustomerInvestment.SelectedIndex = -1;
            ClearUpdatedCustomerInformationTextboxes();
            ClearAddInvestmentTextBoxes();
            lboCustomerMutualFundInvestment.Items.Clear();
            lboCustomerStockInvestment.Items.Clear();
        }



        private void DisableEnableControlsViewTab()
        {
            if (Customers[cboCustomerInfo.SelectedIndex].stocks.Count == 0)
            {
                cboStockShares.Enabled = false;
                txtStockChangeAmount.Enabled = false;
                rbnBuyStock.Enabled = false;
                rbnSellStock.Enabled = false;
                btnStockShares.Enabled = false;
            }
            else
            {
                cboStockShares.Enabled = true;
                txtStockChangeAmount.Enabled = true;
                rbnBuyStock.Enabled = true;
                rbnSellStock.Enabled = true;
                btnStockShares.Enabled = true;
            }

            //An IF statement to disable the Buy/Sell textboxes if the customer doesn't have any mutual funds.
            if (Customers[cboCustomerInfo.SelectedIndex].MutualFunds.Count == 0)
            {
                cboMutualFundShares.Enabled = false;
                txtMutualFundChangeAmount.Enabled = false;
                rbnBuyMutualFund.Enabled = false;
                rbnSellMutualFund.Enabled = false;
                btnMutualFundShares.Enabled = false;
            }
            else
            {
                cboMutualFundShares.Enabled = true;
                txtMutualFundChangeAmount.Enabled = true;
                rbnBuyMutualFund.Enabled = true;
                rbnSellMutualFund.Enabled = true;
                btnMutualFundShares.Enabled = true;
            }
        }

        private void ClearBuySellSharesControls()
        {
            cboStockShares.SelectedIndex = -1;
            txtStockChangeAmount.Clear();
            rbnBuyStock.Checked = false;
            rbnSellStock.Checked = false;

            cboMutualFundShares.SelectedIndex = -1;
            txtMutualFundChangeAmount.Clear();
            rbnBuyMutualFund.Checked = false;
            rbnSellMutualFund.Checked = false;
            
        }


        private void ClickViewCustomerTab(object sender, EventArgs e)
        {
            if (cboCustomerInfo.SelectedIndex == -1)
            {
                cboStockShares.Enabled = false;
                txtStockChangeAmount.Enabled = false;
                rbnBuyStock.Enabled = false;
                rbnSellStock.Enabled = false;
                btnStockShares.Enabled = false;
           
                cboMutualFundShares.Enabled = false;
                txtMutualFundChangeAmount.Enabled = false;
                rbnBuyMutualFund.Enabled = false;
                rbnSellMutualFund.Enabled = false;
                btnMutualFundShares.Enabled = false;

                checkBoxCloseAccount.Enabled = false;
                btnCloseAccount.Enabled = false;
                btnUpdateCustomer.Enabled = false;
            }

        }

        private void btnCloseAccount_Click(object sender, EventArgs e)
        {
            if (cboCustomerInfo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a user first.", "Error");
            }
            else
            {
                if (checkBoxCloseAccount.Checked == false)
                {
                    MessageBox.Show("Please check the box to the left to confirm that you agree to the statement.", "Confirmation Needed");
                }
                else
                {
                    Customers[cboCustomerInfo.SelectedIndex].DeleteStock(Customers[cboCustomerInfo.SelectedIndex]);
                    Customers[cboCustomerInfo.SelectedIndex].DeleteMutualFund(Customers[cboCustomerInfo.SelectedIndex]);

                    Customers.Remove(Customers[cboCustomerInfo.SelectedIndex]);
                    

                    MessageBox.Show("The customer has been deleted successfully", "Customer Deleted");
                    checkBoxCloseAccount.Checked = false;
                    ClearUpdatedCustomerInformationTextboxes();
                    PopulateComboBoxesCustomerName();
                    //Disable update customer and close account buttons
                    btnUpdateCustomer.Enabled = false;
                    btnCloseAccount.Enabled = false;
                    checkBoxCloseAccount.Enabled = false;

                }
            }
        }

        private bool IsAccountNumberUnique(string anAccountNumber)
        {
            foreach (CustomerAccount aCustomer in Customers)
            {
                if (anAccountNumber == aCustomer.GetAccountNumber())
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsStockInvestmentIDUnique(string anInvestmentID)
        {
            foreach (Stock aStock in Customers[cboCustomerInvestment.SelectedIndex].GetStock())
            {
                if (anInvestmentID == aStock.GetInvestmentID())
                {
                    return false;
                }
            }
            return true;

        }
        
        private bool IsMutualFundInvestmentIDUnique(string anInvestmentID)
        {
            foreach (MutualFund aMutualFund in Customers[cboCustomerInvestment.SelectedIndex].GetMutualFund())
            {
                if (anInvestmentID == aMutualFund.GetInvestmentID())
                {
                    return false;
                }
            }
            return true;
        }
        








        

        
    }
}
