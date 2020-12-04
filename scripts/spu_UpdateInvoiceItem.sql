USE `suit_polo_dev_erp`;
DROP procedure IF EXISTS `spu_UpdateInvoiceItem`;

DELIMITER $$
USE `suit_polo_dev_erp`$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `spu_UpdateInvoiceItem`(
  _invoiceItemId bigint(20),
  _name VARCHAR(100),
  _suggestedPrice DECIMAL(15, 2),
  _companyCode VARCHAR(20),
  _invoiceItemType char(1),
  _createdBy VARCHAR(20),
  _igvAffected bit(1)
  , _isEnabled bit(1)
 )
BEGIN

UPDATE `invoiceitem`
SET
`invoiceItemId` = _invoiceItemId,
`name` = _name,
`suggestedPrice` = _suggestedPrice,
`companyCode` = _companyCode,
`invoiceItemType` = _invoiceItemType,
`createdDate` = _createdDate,
`createdBy` = _createdBy,
`igvAffected` = _igvAffected,
`IsEnabled` = _IsEnabled
WHERE `invoiceItemId` = _invoiceItemId;

END$$

DELIMITER ;

