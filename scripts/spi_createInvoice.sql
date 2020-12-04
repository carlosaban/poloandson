USE `suit_polo_dev_erp`;
DROP procedure IF EXISTS `spi_createInvoice`;

DELIMITER $$
USE `suit_polo_dev_erp`$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `spi_createInvoice`(
  _amountTotal decimal(15, 2),
  _bankAccountId int(11),
  _bankAccountNumber varchar(20),
  _companyCode varchar(20),
  _currency varchar(3),
  _customerName varchar(255),
  _customerRuc varchar(20),
  _documentDate datetime,
  _documentId varchar(20),
  _dueDate datetime,
  _exchangeRate decimal(15, 2),
  _customerEmail varchar(60),
  _documentType varchar(4),
  _nroComprobante varchar(20),
  _nroSerie varchar(5),
  _tipoServicio varchar(5),
  _customerDocType varchar(4),
  _invoiceStatusId bigint, 
  _invoiceType char(1),
  _createdBy varchar(20), 
  _reference varchar(250), 
  _comments varchar(500),
  _SourceStore int(11),
  _TargetStore int(11)
  )
BEGIN
  DECLARE xInvoiceId int;
  
  INSERT  INTO invoice (
  AmountTotal,
  BankAccountId,
  BankAccountNumber,
  CompanyCode,
    CreatedBy,
  CreatedDate,
  Currency,
  CustomerName,
  CustomerRuc,
  DocumentDate,
  DocumentId,
  DueDate,
  ExchangeRate,
  CustomerEmail,
  DocumentType,
  NroComprobante,
  NroSerie,
  TipoServicio,
  CustomerDocType,
  invoiceStatusId,
  invoiceType,
  reference,
  comments,
  UpdatedDate,
  SourceStore ,
  TargetStore 
  )
    VALUES (
    _amountTotal,
    _bankAccountId,
	_bankAccountNumber,
    _companyCode, 
    _createdBy,
    CURDATE(), 
    _currency, 
    _customerName, 
    _customerRuc, 
    _documentDate, 
    _documentId, 
    _dueDate, 
    _exchangeRate, 
    _customerEmail, 
    _documentType, 
    _nroComprobante, 
    _nroSerie, 
    _tipoServicio, 
    _customerDocType, 
    _invoiceStatusId,
    _invoiceType,
    _reference,
    _comments,
    curdate(),
    _SourceStore ,
	_TargetStore 
    
    );

  SET xInvoiceId = LAST_INSERT_ID();

  INSERT INTO invoicelog
  (
    invoiceId
   ,invoiceStatusId
   ,createdDate
   ,createdBy
  )
  VALUES
  (
    xInvoiceId -- invoiceId - BIGINT(20) NOT NULL
   ,1 -- invoiceStatusId - INT(11)
   ,NOW() -- createdDate - DATETIME NOT NULL
   ,_createdBy -- createdBy - VARCHAR(20)
  );

    SELECT
    xInvoiceId AS invoiceId;
END$$

DELIMITER ;