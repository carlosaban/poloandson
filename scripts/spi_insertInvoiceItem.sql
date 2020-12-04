
DROP procedure IF EXISTS `spi_insertInvoiceItem`;

DELIMITER $$
USE `suit_polo_dev_erp`$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `spi_insertInvoiceItem`(
  _name VARCHAR(100),
  _suggestedPrice DECIMAL(15, 2),
  _companyCode VARCHAR(20),
  _invoiceItemType char(1),
  _createdBy VARCHAR(20),
  _igvAffected bit(1) 
  
 )
BEGIN
INSERT INTO invoiceitem
(
 name
 ,suggestedPrice
 ,companyCode
 ,invoiceItemType
 ,createdDate
 ,createdBy
 ,igvAffected
 , IsEnabled
)
VALUES
(
 _name -- VARCHAR(50)
 ,_suggestedPrice -- suggestedPrice - DECIMAL(15, 2)
 ,_companyCode -- companyCode - VARCHAR(20)
 ,_invoiceItemType -- invoiceItemType - INT(11) NOT NULL
 ,NOW() -- createdDate - DATE NOT NULL
 ,_createdBy -- createdBy - VARCHAR(20)
 ,_igvAffected
 ,1
);

  select last_insert_id() as invoiceItemId; 
END$$

DELIMITER ;

