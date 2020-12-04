USE `suit_polo_dev_erp`;
DROP procedure IF EXISTS `receta_sps_getConsolidatedReport`;

DELIMITER $$
USE `suit_polo_dev_erp`$$
CREATE DEFINER=`suit_user`@`%` PROCEDURE `receta_sps_getConsolidatedReport`(
IN `_year` INT(11), 
IN `_month` INT(11), 
IN `_sede` INT(11)
)
BEGIN
	SELECT h.`name` as headquartersName 
	   , `headquartersId`
       ,ifnull(( 
			SELECT sum(ifnull(pd.`quantity`,0) *ifnull(`productCost`,0))
			FROM `tb_programationdetail` pd
			inner join tb_programation p  on pd.programationId = p.programationId
			inner join tb_product pro on pro.productId = pd.productId
			where year(p.date) = `_year` and month(p.date) = `_month` and pro.headquartersId = ifnull(`_sede`,pro.headquartersId )
       ) , 0 ) as Cost
       ,ifnull(( 
			SELECT sum(ifnull(pd.`quantity`,0) *ifnull(pro.`salePrice`,0))
			FROM `tb_programationdetail` pd
			inner join tb_programation p  on pd.programationId = p.programationId
			inner join tb_product pro on pro.productId = pd.productId
			where year(p.date) = `_year` and month(p.date) = `_month` and pro.headquartersId = ifnull(`_sede`,pro.headquartersId )
       
       ) , 0 ) as GrossAmount
       ,ifnull(( (
			SELECT sum(ifnull(pd.`quantity`,0) *ifnull(pro.`salePrice`,0))
			FROM `tb_programationdetail` pd
			inner join tb_programation p  on pd.programationId = p.programationId
			inner join tb_product pro on pro.productId = pd.productId
			where year(p.date) = `_year` and month(p.date) = `_month` and pro.headquartersId = ifnull(`_sede`,pro.headquartersId )
		  )- 
          (
			SELECT sum(ifnull(pd.`quantity`,0) *ifnull(`productCost`,0))
			FROM `tb_programationdetail` pd
			inner join tb_programation p  on pd.programationId = p.programationId
			inner join tb_product pro on pro.productId = pd.productId
			where year(p.date) = `_year` and month(p.date) = `_month` and pro.headquartersId = ifnull(`_sede`,pro.headquartersId )
          )
       
       ) , 0) as NetAmount

FROM tb_headquarters h 
where headquartersId  = ifnull(headquartersId , headquartersId)
and isEnabled = 1
;
    
END$$

DELIMITER ;