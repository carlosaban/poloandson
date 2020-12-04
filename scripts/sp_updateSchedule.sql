USE `suit_polo_dev_erp`;
DROP procedure IF EXISTS `sp_updateSchedule`;

DELIMITER $$
USE `suit_polo_dev_erp`$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `sp_updateSchedule`(
   _invoceId int(11) ,
	_startdate date,
	_enddate date,
	_deliverydate date,
	_paymentmethod int
  )
BEGIN

	UPDATE  `tb_schedule`
	SET
		`startdate` = _startdate,
		`enddate` = _enddate,
		`deliverydate` = _deliverydate,
		`paymentmethod` = _paymentmethod
	WHERE `invoceId` = _invoceId;



  
END$$

DELIMITER ;