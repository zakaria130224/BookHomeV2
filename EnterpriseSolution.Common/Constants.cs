using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Common
{
    public static class Constants
    {
        public const string NewUser = "New User";

        public static int HighestLevelOfGlMatrix = 5;

        public static string LastRowTitle = "Total";

        public static class SessionKeys
        {
            public const string SessionUser = "user";

            public const string UserEmail = "userEmail";

            public const string UserId = "userId";
        }

        public static class Currency
        {
            public const string BDT = "BDT";

            public const string USD = "USD";
        }

        public static class StatusFlags
        {
            public const string Yes = "YES";

            public const string No = "NO";
        }

        public static class DebitCredit
        {
            public const string Debit = "Debit";
            public const string Credit = "Credit";
        }

        public static class Prefix
        {
            public static string Voucher { get { return "Voucher"; } }

            public static string FixedAsset { get { return "Fixed Asset"; } }

            public static string FixedAssetSale { get { return "Fixed Asset Sale"; } }

            public static string SupplierPayment { get { return "Supplier Payment"; } }

            public static string SalesPayment { get { return "Sales Payment"; } }

            public static string WorkOrder { get { return "Work Order"; } }

            public static string UserId { get { return "User Id"; } }

            public static string BranchCode { get { return "Branch Code"; } }

            public static string OtherPayments { get { return "Other Payments"; } }

            public static string OtherSales { get { return "Other Sales"; } }

            public static string SingleEntry { get { return "Single Entry"; } }

            public static string LoanEntry { get { return "Loan Entry"; } }

            public static string LoanInstallmentEntry { get { return "Loan Installment Entry"; } }
        }

        public static class UserRoles
        {
            public static string Admin { get { return "ADMIN"; } }

            public static string Maker { get { return "MAKER"; } }

            public static string Checker { get { return "CHECKER"; } }
        }

        public static class AuthorizationStatus
        {
            public static string Capitalized { get { return "CAPITALIZED"; } }

            public static string Authorised { get { return "AUTHORISED"; } }

            public static string Unauthorised { get { return "UNAUTHORISED"; } }

            public static string Rejected { get { return "REJECTED"; } }

            public static string Submitted { get { return "SUBMITTED"; } }
        }

        //Added By: Zakaria 21.10.2018
        //Loan Status
        public static class LoanStatus
        {
            public static string Active { get { return "ACTIVE"; } }

            public static string TakeOver { get { return "TAKE OVER"; } }

            public static string Closed { get { return "CLOSED"; } }
        }

        //TODO: Need a SalesStatus Table
        public static class SalesStatus
        {
            public static string Authorised { get { return "Authorised"; } }

            public static string Unauthorised { get { return "Unauthorised"; } }

            public static string Rejected { get { return "Rejected"; } }

            public static string Sold { get { return "Sold"; } }
        }

        //TODO: Need an AssetWriteOffStatus Table
        public static class AssetWriteOffStatus
        {
            public static string Authorized { get { return "Authorised"; } }

            public static string Unauthorized { get { return "Unauthorised"; } }

            public static string Reject { get { return "Rejected"; } }
        }

        //TODO: Need a VoucherStatus Table
        public static class VoucherStatus
        {
            public static string Active { get { return "Active"; } }

            public static string Reversed { get { return "Reversed"; } }

            public static string Advance { get { return "Advance"; } }

            public static string Final { get { return "Final"; } }
        }

        //TODO: Need a VoucherAuthorizationStatus Table
        public static class VoucherAuthorizationStatus
        {
            public static string Authorised { get { return "Authorized"; } }

            public static string Unauthorised { get { return "Unauthorize"; } }
        }

        public static class Status
        {
            public static string Active = "AC";
            public static string WorkInProgress = "WIP";
            public static string AssetWriteOff = "WO";
            public static string AssetSaleStatus = "SL";
            public static string AssetTransfer = "TR";
            public static string Reversed = "RV";
            public static string CheckerAmendment = "CA";
            public static string MakerAmendment = "MA";
        }

        public static class JournalPaymentType
        {
            //public static string Active = "AC";
            public static string FixedAssetCapture = "FAC";
            public static string FixedAssetDepreciation = "FAD";
            public static string FixedAssetSell = "FAS";
            public static string FixedAssetWriteOff = "FAW";
            public static string FixedAssetTransfer = "FAT";
            public static string FixedAssetReversed = "FAR";
            public static string Voucher = "V";
            public static string VoucherReleaseSecurityMoney = "VRSM";
            public static string VoucherSupplierPaymentDebit = "SPSPD";
            public static string VoucherAdjustmentHeadCredit = "SPAHC";
            public static string Sales = "SS";
            public static string SalesPayableAdjustment = "SSPA";
            public static string SalesCollectionDetails = "SSCD";
            public static string OtherSupplierPayments = "OPOP";
            public static string OtherSupplierPaymentsBank = "OPO";
            public static string OtherSupplierPaymentsAccountTitle = "OPOPAT";
            public static string OtherSupplierPaymentsCash = "OSPOSPC";
            public static string OtherSales = "OSOS";
            public static string OtherSalesBankPayment = "OSOSBP";
            public static string OtherSalesCollectionDetails = "OSOSCD";
            public static string OtherSalesPayableAdjustment = "OSOSPA";
            public static string OtherSalesPaymentCashPayment = "OSPOSPCP";
            public static string SingleEntry = "SESE";
            public static string LoanEntry = "LELE";
            public static string LoanInstallmentEntry = "LIELI";

        }

        public static class Nature
        {
            public static string Debit = "DEBIT";
            public static string Credit = "CREDIT";
        }

        #region One Way Hash Using SHA256 Algorithm
        public static string GetSecurePassword(string inputPassword)
        {
            var encoder = new UTF8Encoding();
            var sha256hasher = new SHA256Managed();
            byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(inputPassword));
            //var d = Convert.ToBase64String(hashedDataBytes);
            return Convert.ToBase64String(hashedDataBytes);
        }

        public static string GeneratePassword(int pLenght, int pNonAlphaNumericChars)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            string allowedNonAlphaNum = "AxCDyBzE"; //"@#.!"; //"!@#$%^&*()_-+=[{]};:<>|./?";
            var rd = new Random();

            if (pNonAlphaNumericChars > pLenght || pLenght <= 0 || pNonAlphaNumericChars < 0)
                throw new ArgumentOutOfRangeException();

            char[] pass = new char[pLenght];
            int[] pos = new int[pLenght];
            int i = 0, j = 0, temp = 0;
            bool flag = false;

            //Random the position values of the pos array for the string Pass
            while (i < pLenght - 1)
            {
                j = 0;
                flag = false;
                temp = rd.Next(0, pLenght);
                for (j = 0; j < pLenght; j++)
                    if (temp == pos[j])
                    {
                        flag = true;
                        j = pLenght;
                    }

                if (!flag)
                {
                    pos[i] = temp;
                    i++;
                }
            }

            //Random the AlphaNumericChars
            for (i = 0; i < pLenght - pNonAlphaNumericChars; i++)
                pass[i] = allowedChars[rd.Next(0, allowedChars.Length)];

            //Random the NonAlphaNumericChars
            for (i = pLenght - pNonAlphaNumericChars; i < pLenght; i++)
                pass[i] = allowedNonAlphaNum[rd.Next(0, allowedNonAlphaNum.Length)];

            //Set the sorted array values by the pos array for the rigth posistion
            char[] sorted = new char[pLenght];
            for (i = 0; i < pLenght; i++)
                sorted[i] = pass[pos[i]];

            var password = new String(sorted);

            return password;
        }
        #endregion

        public static class CategoryCode
        {
            public static string Land { get { return "L"; } }
            public static string Buildings { get { return "B"; } }
            public static string FurnitureFixtures { get { return "F"; } }
            public static string InteriorDecoration { get { return "D"; } }
            public static string OfficeEquipment { get { return "E"; } }
            public static string ComputerEquipment { get { return "C"; } }
            public static string ComputerSoftware { get { return "S"; } }
            public static string MotorVehicle { get { return "V"; } }
            public static string CapitalMachineries { get { return "M"; } }
        }

        public static class GlType
        {
            public static string PurchasedAsset { get { return "PA"; } }
            public static string Cash { get { return "CASH"; } }
            public static string DepreciationExpense { get { return "DE"; } }
            public static string AccumulatedDepreciation { get { return "AD"; } }
            public static string WriteOffAsset { get { return "WA"; } }
            public static string RetailIncome { get { return "RIFA"; } }
            public static string LossOnSell { get { return "LSOA"; } }
            public static string VoucherBillAmount { get { return "BA"; } }
            public static string VoucherSecurityMoney { get { return "SM"; } }
            public static string VoucherVAT { get { return "VV"; } }
            public static string VoucherAIT { get { return "VA"; } }
            public static string VoucherNetPayableAmount { get { return "NPA"; } }
        }

        public static class AccountingType
        {
            public const string Asset = "Asset";
            public const string AccoumilateDepreciation = "AccoumilateDepreciation";
        }

        public static class IdentiryGenerator
        {
            public static string GuidCode()
            {
                string guid = Guid.NewGuid().ToString().ToUpper();
                guid = guid.Substring(0, guid.Length - 8);
                guid = guid.Substring(4, guid.Length - 4);
                return guid;
            }
        }

        public const String ApplicationCookie = "AppAuthenticationType";
        public const String ProviderName = "EnterpriseSolutionProvider";

        /*
         * Database file names
         * **/
        public const String AssetCategoryStaging = "AssetCategoryStaging";
        public const String AssetStaging = "AssetStaging";
        public const String DepreciationStaging = "DepreciationStaging";
        public const String GlTypeStaging = "GlTypeStaging";
        public const String GlAccountsStaging = "GlAccountsStaging";

        /*
         * Sample file names
         * **/
        public const String AssetCategoryStagingSample = "AssetCategoryStagingSample";
        public const String DepreciationStagingSample = "DepreciationStagingSample";
        public const String AssetStagingSample = "AssetStagingSample";
        public const String GlTypeStagingSample = "GlTypeStagingSample";
        public const String GlAccountsStagingSample = "GlAccountsStagingSample";

        /*
         * Export file name
         * **/
        public const String ExportedAssetCategory = "AssetCategories";//Was singular
        public const String ExportedAsset = "Assets";//Was singular
        public const String ExportedDepreciationConfig = "DepreciationConfig";
        public const String ExportedGlType = "GlTypes";//Was singular
        public const String ExportedGlAccounts = "GlAccounts";
        public const String ExportedLedger = "Ledger";
        public const String ExportedJournal = "Journal";
        public const String ExportedTrialBalance = "TrialBalance";


        public static class Modules
        {
            public const String FixedAsset = "FixedAsset";
            public const String Voucher = "Voucher";
        }

        public static class Screens
        {
            public const String AssetCapture = "AssetCapture";
            public const String Vouchers = "Vouchers";
            public const String AssetSale = "AssetSale";
            public const String AssetWriteOff = "AssetWriteOff";
            public const String ReleaseSecurityMoney = "ReleaseSecurityMoney";
            public const String Sales = "Sales";
            public const String SalesPayableAdjustment = "SalesPayableAdjustment";
            public const String SalesCollectionDetails = "SalesCollectionDetails";
            public const String OtherPayments = "OtherPayments";
            public const String OtherSales = "OtherSales";
            public const String OtherSalesBankPayment = "OtherSalesBankPayment";
            public const String OtherSalesCollectionDetails = "OtherSalesCollectionDetails";
            public const String OtherSalesPayableAdjustment = "OtherSalesPayableAdjustment";


        }

        public static class ScreenFieldsMapKeys
        {
            //Fixed Asset
            public const String AssetMainCategory = "AssetMainCategory";

            public const String AccountTitle = "SupplierPaymentAccountTitle"; //AccountTitle
            public const String PayableAccountTitle = "PayableAccountTitle";
            public const String CollectionAccountTitle = "CollectionAccountTitle";
            public const String AdjustmentHeadOrCredit = "AdjustmentHeadOrCredit"; //AdjustmentHeadOrCredit
            public const String SelectBank = "SelectBank";
            public const String ReleaseSecurityMoneyBanks = "PaymentMethodByBank";
            public const String ReleaseSecurityMoneyReleaseFrom = "ReleaseFrom";
            public const String SalesSelectBank = "SalesSelectBank";
            public const String OtherSupplierPaymentAccountTitle = "OtherPaymentAccountTitle";
            public const String OtherSupplierPaymentSelectBank = "OtherPaymentSelectBank";
            public const String OtherSupplierPaymentCashTitle = "OtherSupplierPaymentsCashTitle";
            public const String OtherSalesPayableAdjustment = "OtherSalesPayableAdjustment";//
            public const String OtherSalesBankPayment = "OtherSalesBankPayment";
            public const String OtherSalesCollectionDetails = "OtherSalesCollectionDetails";
            public const String OtherSalesPaymentCashPayment = "OtherSalesPaymentCashPayment";

            //Added By: Zakaria 21.10.2018
            //Loan Entry
            public const String CashAccount = "CashAccount";
            public const String BankAccount = "BankAccount";
            public const String BankChargeAccount = "BankChargeAccount";
            public const String LiabilityAccount = "LiabilityAccount";
            public const String AITPaid = "AITPaid";

            //Added By: Zakaria 04.11.2018
            //Loan Installment Entry LoanInstallment
            public const String LoanInstallmentCashAccount = "LoanInstallmentCashAccount";
            public const String LoanInstallmentBankAccount = "LoanInstallmentBankAccount";
            public const String LoanInstallmentInterestAccount = "LoanInstallmentInterestAccount";
            public const String LoanInstallmentLiabilityAccount = "LoanInstallmentLiabilityAccount";




        }

        public static class Actions
        {
            public const String VIEW = "VIEW";
            public const String ADD = "ADD";
            public const String DEPRECIATION = "DEPRECIATION";
            public const String REVERSE = "REVERSE";
        }

        public static class AmendmentStatus
        {
            public static string NewRequest { get { return "New Request"; } }

            public static string AwaitingForApproval { get { return "Awaiting For Approval"; } }

            public static string Approved { get { return "Approved"; } }

            public static string Reject { get { return "Reject"; } }
        }

        public static class AccountState
        {
            public static string Insert { get { return "INSERT"; } }
            public static string Depreciation { get { return "DEPRECIATION"; } }
            public static string WriteOff { get { return "WRITEOFF"; } }
            public static string AssetSell { get { return "ASSETSELL"; } }
            public static string Reverse { get { return "REVERSE"; } }
        }

        public static class ReleaseSecurityMoneyPaymentMethod
        {
            public static string Cash { get { return "ByCash"; } }
            public static string Bank { get { return "ByBank"; } }
        }

        public static class IncomeTypesKey
        {
            public static string ForeignSales { get { return "FSales"; } }
            public static string LocalSales { get { return "LSales"; } }
            public static string OtherSales { get { return "OSales"; } }
        }

        public static class ModuleShortCode
        {
            public static string FixedAsset = "FA";

            public static string SupplierPayment = "SE";

            public static string Sales = "SR";

            public static string OtherSupplierPayment = "OE";

            public static string OtherSales = "OR";

            public static string SingleEntry = "SA";

            public static string LoanEntry = "LE";

            public static string LoanInstallmentEntry = "LI";

        }

        public static class ServerStoragePaths
        {
            public static string DocumentAttachmentFolder = "~/Attachments";
        }
    }
}
