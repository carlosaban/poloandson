USE `suit_polo_dev_erp`;
DROP procedure IF EXISTS `spu_updateInvoiceGeneral`;

DELIMITER $$
USE `suit_polo_dev_erp`$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `spu_updateInvoiceGeneral`(_id varchar(20),
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
_documentType varchar(4),
_customerBankAccountDetraction varchar(50),
_nroComprobante varchar(20),
_nroSerie varchar(5),
_tipoServicio varchar(5),
_customerDocType varchar(2),
_accounting varchar(10),
_amountDetractionUS decimal(18, 2),
_status char(1),
_invoiceType char(1),
_reference varchar(500),
_comments varchar(500),

_SourceStore int (11),
_TargetStore int(11)
)
BEGIN

	
    
  UPDATE invoice
  SET AmountBalance = ifnull( _amountBalance,AmountBalance)
      , AmountDetraction =  ifnull( _amountDetraction, amountDetraction)
      ,AmountPayment =  ifnull( _amountPayment,AmountPayment)
      ,AmountPaymentDetraction =  ifnull( _amountPaymentDetraction, AmountPaymentDetraction)
      ,AmountPaymentFromBank =  ifnull( _amountPaymentFromBank, AmountPaymentFromBank)
      ,AmountPaymentPen =  ifnull( _amountPaymentPen, AmountPaymentPen)
      ,AmountTotal =  ifnull( _amountTotal,AmountTotal)
      ,BankAccountId =  ifnull( _bankAccountId,BankAccountId)
      ,BankAccountNumber =  ifnull( _bankAccountNumber,BankAccountNumber)
      ,BankId =  ifnull( _bankId,BankId)
      ,BudgetFile =  ifnull( _budgetFile,BudgetFile)
      ,CompanyCode =  ifnull( _companyCode,CompanyCode)
      ,Currency =  ifnull( _currency,Currency)
      ,CurrencyPayment =  ifnull( _currencyPayment,CurrencyPayment)
      ,CustomerBankAccountPen =  ifnull( _customerBankAccountPen,CustomerBankAccountPen)
      ,CustomerBankAccountUsd = ifnull(_customerBankAccountUsd,CustomerBankAccountUsd)
      ,CustomerName =  ifnull( _customerName,CustomerName)
      ,CustomerRuc =  ifnull( _customerRuc,CustomerRuc)
      ,DocumentDate =  ifnull( _documentDate,DocumentDate)
      ,DocumentId =  ifnull( _documentId,DocumentId)
      ,DueDate =  ifnull( _dueDate,DueDate)
      ,ExchangeRate =  ifnull( _exchangeRate,ExchangeRate)
      ,InvoiceFile =  ifnull( _invoiceFile,InvoiceFile)
      ,OCRFile =  ifnull( _oCRFile,OCRFile)
      ,UpdatedDate = CURDATE()
      ,CustomerEmail =  ifnull( _customerEmail,CustomerEmail)
      ,DocumentType =  ifnull( _documentType,DocumentType)
      ,CustomerBankAccountDetraction =  ifnull(  _customerBankAccountDetraction,CustomerBankAccountDetraction)
      ,NroComprobante =  ifnull( _nroComprobante,NroComprobante)
      ,NroSerie =  ifnull( _nroSerie,NroSerie)
      ,TipoServicio =  ifnull( _tipoServicio,TipoServicio)
      ,CustomerDocType =  ifnull( _customerDocType,CustomerDocType)
      ,Accounting =  ifnull( _accounting,Accounting)
      ,AmountDetractionUS =  ifnull( _amountDetractionUS,AmountDetractionUS)
      ,InvoiceType =  ifnull( _invoiceType, invoiceType)
      ,reference =  ifnull( _reference, reference)
	  ,Comments =  ifnull( _comments , comments )
	  ,SourceStore = ifnull( _SourceStore , SourceStore )
	  ,TargetStore = ifnull( _TargetStore , TargetStore )

  WHERE Id = _id;

END$$

DELIMITER ;

