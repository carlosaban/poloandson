USE `suit_polo_dev_erp`;
DROP procedure IF EXISTS `sp_getScheduleGeneral`;

DELIMITER $$
USE `suit_polo_dev_erp`$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `sp_getScheduleGeneral`(
   _invoceId int(11)
  )
BEGIN

	SELECT `tb_schedule`.`invoceId`,
			`tb_schedule`.`startdate`,
			`tb_schedule`.`enddate`,
			`tb_schedule`.`deliverydate`,
			`tb_schedule`.`paymentmethod`
	FROM `tb_schedule`
    where `tb_schedule`.`invoceId` = _invoceId ;

  
END$$

DELIMITER ;