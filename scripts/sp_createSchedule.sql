USE `suit_polo_dev_erp`;
DROP procedure IF EXISTS `sp_createSchedule`;

DELIMITER $$
USE `suit_polo_dev_erp`$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `sp_createSchedule`(
   _InvoiceId int(11) ,
	_StartDate date,
	_EndDate date,
	_Delivery date,
	_PaymentMethod int
  )
BEGIN 
	 INSERT INTO `tb_schedule`
	(
		`invoceId`,
		`startdate`,
		`enddate`,
		`deliverydate`, 
		`paymentmethod`
    )
	VALUES
	(
    _InvoiceId,
	_StartDate,
	_EndDate,
	_Delivery,
	_PaymentMethod
    );


  
END$$

DELIMITER ;

