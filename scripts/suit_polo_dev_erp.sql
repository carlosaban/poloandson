USE `suit_polo_dev_erp`;
DROP procedure IF EXISTS `spu_updateInvoice`;

DELIMITER $$
USE `suit_polo_dev_erp`$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `spu_updateInvoice`(_id varchar(20),
_amountBalance decimal(15, 2),
_amountDetraction decimal(15, 2),
_amountPayment decimal(15, 2),
_amountPaymentDetraction decimal(15, 2),
_amountPaymentFromBank decimal(15, 2),
_amountPaymentPen decimal(15, 2),
_amountTotal decimal(15, 2),
_bankAccountId int(11),
_bankAccountNumber varchar(20),
_bankId int(11),
_budgetFile varchar(255),
_companyCode varchar(20),
_currency varchar(3),
_currencyPayment varchar(3),
_customerBankAccountPen varchar(50),
_customerBankAccountUsd varchar(50),
_customerName varchar(255),
_customerRuc varchar(20),
_documentDate datetime,
_documentId varchar(20),
_dueDate datetime,
_exchangeRate decimal(15, 2),
_invoiceFile varchar(255),
_oCRFile varchar(255),
_userAudit varchar(255),
_customerEmail varchar(60),
_documentType varchar(2),
_customerBankAccountDetraction varchar(50),
_nroComprobante varchar(20),
_nroSerie varchar(5),
_tipoServicio varchar(5),
_customerDocType varchar(2),
_accounting varchar(10),
_amountDetractionUS decimal(18, 2),
_status char(1),
_SourceStore int (11),
_TargetStore int(11)

)
BEGIN

    
    IF _bankId=0 THEN 
	set _bankId = null;
	END IF;
  
  UPDATE invoice
  SET AmountBalance = _amountBalance,
      AmountDetraction = _amountDetraction,
      AmountPayment = _amountPayment,
      AmountPaymentDetraction = _amountPaymentDetraction,
      AmountPaymentFromBank = _amountPaymentFromBank,
      AmountPaymentPen = _amountPaymentPen,
      AmountTotal = _amountTotal,
      BankAccountId = _bankAccountId,
      BankAccountNumber = _bankAccountNumber,
      BankId = _bankId,
      BudgetFile = _budgetFile,
      CompanyCode = _companyCode,
      Currency = _currency,
      CurrencyPayment = _currencyPayment,
      CustomerBankAccountPen = _customerBankAccountPen,
      CustomerBankAccountUsd = _customerBankAccountUsd,
      CustomerName = _customerName,
      CustomerRuc = _customerRuc,
      DocumentDate = _documentDate,
      DocumentId = _documentId,
      DueDate = _dueDate,
      ExchangeRate = _exchangeRate,
      InvoiceFile = _invoiceFile,
      OCRFile = _oCRFile,
      UpdatedDate = CURDATE(),
      CustomerEmail = _customerEmail,
      DocumentType = _documentType,
      CustomerBankAccountDetraction = _customerBankAccountDetraction,
      NroComprobante = _nroComprobante,
      NroSerie = _nroSerie,
      TipoServicio = _tipoServicio,
      CustomerDocType = _customerDocType,
      Accounting = _accounting,
      AmountDetractionUS = _amountDetractionUS,
      SourceStore = _SourceStore ,
	  TargetStore = _TargetStore 

  WHERE Id = _id;

END$$

DELIMITER ;

